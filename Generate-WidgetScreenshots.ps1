#!/usr/bin/env pwsh
#Requires -Version 7.0
<#
.SYNOPSIS
    Parallel screenshot generation for the Spectre docs tapes.

.DESCRIPTION
    Drives the globally-installed `vcr` tool over every .tape in the docs example
    projects. The global tool runs VcrSharp's native (browserless) backend — an
    in-process ConPTY + VT parser, no ttyd and no Chromium — so each run is its own
    isolated pseudo-console with no shared terminal server. That removes the
    concurrency bug that once forced serial execution (a stray linefeed injected
    into SVG/GIF output when ttyd was driven in parallel), so the tapes record
    concurrently and parallel output is content-identical to serial modulo
    timing-sampled frames.

    On a 16-logical-core box the full set lands in well under a minute at the
    default throttle, versus many minutes one-at-a-time. The floor is the single
    longest tape (live.tape, ~37s).

.PARAMETER Throttle
    Max concurrent tapes. The tapes spend most of their time idle-waiting on
    Sleep/EndBuffer, so oversubscribing past core count helps. Default: 1.5x
    logical cores.

.PARAMETER VcrExe
    The vcr command (or a path to a specific build). Defaults to the global tool
    resolved from PATH — install with `dotnet tool install --global vcr`. Override
    to point at a local build if you're iterating on VcrSharp itself.

.PARAMETER SkipBuild
    Skip building the example projects. They must already be built — the tapes
    invoke `dotnet run --no-build`.
#>
param(
    [int]$Throttle = [int][math]::Ceiling([Environment]::ProcessorCount * 1.5),
    [string]$VcrExe = 'vcr',
    [switch]$SkipBuild
)

$ErrorActionPreference = 'Stop'
$root = $PSScriptRoot

# Resolve the vcr command up front so a missing tool fails fast with a clear
# message instead of erroring once per tape inside the parallel block. Get-Command
# handles both a command on PATH (the default) and an explicit path override.
$vcr = Get-Command $VcrExe -ErrorAction SilentlyContinue
if (-not $vcr) {
    Write-Error "vcr not found ('$VcrExe'). Install the global tool with 'dotnet tool install --global vcr', or pass -VcrExe <path> to a local build."
    exit 1
}
$VcrPath = $vcr.Source

if (-not $SkipBuild) {
    Write-Host "Building example projects..." -ForegroundColor Cyan
    dotnet build "$root\Spectre.Docs.Examples"     -c Debug --nologo -v q
    if ($LASTEXITCODE -ne 0) { Write-Error "Build failed (Examples)"; exit $LASTEXITCODE }
    dotnet build "$root\Spectre.Docs.Cli.Examples" -c Debug --nologo -v q
    if ($LASTEXITCODE -ne 0) { Write-Error "Build failed (Cli.Examples)"; exit $LASTEXITCODE }
}

$tapeFiles = @(
    Get-ChildItem "$root\Spectre.Docs.Examples\VCR\*.tape"
    Get-ChildItem "$root\Spectre.Docs.Cli.Examples\VCR\*.tape"
)
Write-Host "`nGenerating $($tapeFiles.Count) screenshots via '$VcrPath' — throttle=$Throttle, cores=$([Environment]::ProcessorCount)`n" -ForegroundColor Green

$sw = [System.Diagnostics.Stopwatch]::StartNew()
$results = $tapeFiles | ForEach-Object -ThrottleLimit $Throttle -Parallel {
    $exe = $using:VcrPath; $root = $using:root
    Set-Location $root                                  # tapes use paths relative to the docs root
    $name = $_.Name
    $t = [System.Diagnostics.Stopwatch]::StartNew()
    try {
        & $exe $_.FullName *> $null
        $t.Stop()
        if ($LASTEXITCODE -eq 0) {
            Write-Host ("  ✓ {0,-44} {1,5:N1}s" -f $name, $t.Elapsed.TotalSeconds) -ForegroundColor DarkGreen
            [pscustomobject]@{ Success = $true;  File = $name; Seconds = $t.Elapsed.TotalSeconds }
        } else {
            Write-Warning ("  ✗ {0} (exit {1})" -f $name, $LASTEXITCODE)
            [pscustomobject]@{ Success = $false; File = $name; ExitCode = $LASTEXITCODE }
        }
    } catch {
        $t.Stop()
        Write-Error "  ✗ $name : $_"
        [pscustomobject]@{ Success = $false; File = $name; Error = $_.Exception.Message }
    }
}
$sw.Stop()

$ok   = ($results | Where-Object Success).Count
$fail = ($results | Where-Object { -not $_.Success }).Count

Write-Host "`n========================================" -ForegroundColor Cyan
Write-Host "Screenshot Generation Summary"            -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ("Total: {0} | Success: {1} | Failed: {2} | Wall: {3:N1}s" -f $tapeFiles.Count, $ok, $fail, $sw.Elapsed.TotalSeconds) `
    -ForegroundColor $(if ($fail -eq 0) { 'Green' } else { 'Yellow' })

if ($fail -gt 0) {
    Write-Host "`nFailed files:" -ForegroundColor Red
    $results | Where-Object { -not $_.Success } | ForEach-Object {
        Write-Host "  - $($_.File)" -ForegroundColor Red
        if ($_.Error)    { Write-Host "    Error: $($_.Error)"    -ForegroundColor Gray }
        if ($_.ExitCode) { Write-Host "    Exit:  $($_.ExitCode)" -ForegroundColor Gray }
    }
    exit 1
}
Write-Host "`n✓ All screenshots generated!" -ForegroundColor Green

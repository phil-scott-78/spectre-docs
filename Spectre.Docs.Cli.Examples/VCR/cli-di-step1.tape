Set DisableCursor true
Set Shell "pwsh"
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 70
Set Rows 10
Set WorkingDirectory "Spectre.Docs.Cli.Examples/bin/Debug/net10.0"
Env SPECTRE_APP "M:Spectre.Docs.Cli.Examples.DemoApps.DependencyInjection.NoDI.Demo.RunAsync(System.String[])"

Exec "./example Alice"
Wait
Sleep 1s
Exec "./example Alice --formal"
Wait
Sleep 1s
Screenshot "Spectre.Docs/Content/assets/cli-di-step1.svg"

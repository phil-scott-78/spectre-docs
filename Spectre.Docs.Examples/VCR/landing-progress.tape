Output "Spectre.Docs/Content/assets/landing-progress.svg"

Set FontSize 13
Set Theme "one dark"
Set TransparentBackground "true"
Set DisableCursor true
Set Size fit
Set Cols 39
Set Rows 5

Exec "dotnet run --project .\Spectre.Docs.Examples\ --no-build showcase landing-progress"

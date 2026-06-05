Output "Spectre.Docs/Content/assets/landing-status.svg"

Set FontSize 13
Set Theme "one dark"
Set TransparentBackground "true"
Set DisableCursor true
Set Cols 27
Set Rows 6

Exec "dotnet run --project .\Spectre.Docs.Examples\ --no-build showcase landing-status"

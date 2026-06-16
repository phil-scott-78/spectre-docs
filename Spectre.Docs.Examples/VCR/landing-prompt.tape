Output "Spectre.Docs/Content/assets/landing-prompt.svg"

Set FontSize 13
Set Theme "one dark"
Set TransparentBackground "true"
Set DisableCursor true
Set Cols 39
Set Rows 8
Set Size fit

Exec "dotnet run --project .\Spectre.Docs.Examples\ --no-build showcase landing-prompt"

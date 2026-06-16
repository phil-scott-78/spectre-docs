Output "Spectre.Docs/Content/assets/landing-calendar.svg"

Set StaticOutput true
Set FontSize 13
Set Theme "one dark"
Set TransparentBackground "true"
Set DisableCursor true
Set Cols 52
Set Rows 12

Exec "dotnet run --project .\Spectre.Docs.Examples\ --no-build showcase landing-calendar"

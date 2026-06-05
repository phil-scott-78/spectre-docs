Output "Spectre.Docs/Content/assets/landing-bar-chart.svg"

Set StaticOutput true
Set FontSize 13
Set Theme "one dark"
Set TransparentBackground "true"
Set DisableCursor true
Set Cols 39
Set Rows 7

Exec "dotnet run --project .\Spectre.Docs.Examples\ --no-build showcase landing-bar-chart"

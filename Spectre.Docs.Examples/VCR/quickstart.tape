Output "Spectre.Docs/Content/assets/quickstart.svg"

Set DisableCursor true
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 82
Set Rows 14
Set Size "fit-height"
Set EndBuffer 3s

Exec "dotnet run --project .\Spectre.Docs.Examples\ --no-build showcase quick-start"

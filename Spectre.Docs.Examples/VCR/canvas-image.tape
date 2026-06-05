Output "Spectre.Docs/Content/assets/canvas-image.svg"

Set StaticOutput true
Set FitToContent true
Set DisableCursor true
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 82
Set Rows 40

Exec "dotnet run --project .\Spectre.Docs.Examples\ --no-build showcase canvas-image"

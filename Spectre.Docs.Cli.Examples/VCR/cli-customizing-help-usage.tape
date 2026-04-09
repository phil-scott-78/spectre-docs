Set DisableCursor true
Set Shell "pwsh"
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 80
Set Rows 20
Set WorkingDirectory "Spectre.Docs.Cli.Examples/bin/Debug/net10.0"
Env SPECTRE_APP "M:Spectre.Docs.Cli.Examples.DemoApps.CustomizingHelpText.Demo.RunAsync(System.String[])"

Exec "./example --help"
Wait
Sleep 1s
Screenshot "Spectre.Docs/Content/assets/cli-customizing-help-usage.svg"

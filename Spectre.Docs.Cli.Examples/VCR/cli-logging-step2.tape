Set DisableCursor true
Set Shell "pwsh"
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 70
Set Rows 14
Set WorkingDirectory "Spectre.Docs.Cli.Examples/bin/Debug/net10.0"
Env SPECTRE_APP "M:Spectre.Docs.Cli.Examples.DemoApps.Logging.WithLogging.Demo.RunAsync(System.String[])"

Exec "./example myfile.txt"
Wait
Sleep 1s
Screenshot "Spectre.Docs/Content/assets/cli-logging-step2.svg"

Set DisableCursor true
Set Shell "pwsh"
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 80
Set Rows 14
Set WorkingDirectory "Spectre.Docs.Cli.Examples/bin/Debug/net10.0"
Env SPECTRE_APP "M:Spectre.Docs.Cli.Examples.DemoApps.DictionaryOptions.Demo.RunAsync(System.String[])"

Exec "./example --lookup env=dev --lookup env=staging --lookup env=prod --lookup region=us"
Wait
Sleep 1s
Screenshot "Spectre.Docs/Content/assets/cli-dictionary-lookup-output.svg"

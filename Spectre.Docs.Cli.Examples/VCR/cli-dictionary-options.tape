Output "Spectre.Docs/Content/assets/cli-dictionary-options.svg"

Set Shell "pwsh"
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 82
Set Rows 20
Set Size "fit-height"
Set EndBuffer 5s
Set WorkingDirectory "Spectre.Docs.Cli.Examples/bin/Debug/net10.0"
Env SPECTRE_APP "M:Spectre.Docs.Cli.Examples.DemoApps.DictionaryOptions.Demo.RunAsync(System.String[])"

Type "./example --value port=8080 --value timeout=30 --value retries=3"
Sleep 400ms
Enter
Sleep 2500ms

Type "./example --lookup env=dev --lookup env=staging --lookup region=us"
Sleep 400ms
Enter
Sleep 3s

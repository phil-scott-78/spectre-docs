Output "Spectre.Docs/Content/assets/cli-multi-command-step3.svg"

Set Shell "pwsh"
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 70
Set Rows 18
Set EndBuffer 5s
Set WorkingDirectory "Spectre.Docs.Cli.Examples/bin/Debug/net10.0"
Env SPECTRE_APP "M:Spectre.Docs.Cli.Examples.DemoApps.MultiCommand.Finished.Demo.RunAsync(System.String[])"

Type "./example add package Serilog --version 3.0.0 --verbose"
Sleep 400ms
Enter
Sleep 1s

Type "./example list --verbose"
Sleep 400ms
Enter
Sleep 3s

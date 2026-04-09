Output "Spectre.Docs/Content/assets/cli-multi-command-step2.svg"

Set Shell "pwsh"
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 70
Set Rows 16
Set EndBuffer 5s
Set WorkingDirectory "Spectre.Docs.Cli.Examples/bin/Debug/net10.0"
Env SPECTRE_APP "M:Spectre.Docs.Cli.Examples.DemoApps.MultiCommand.Step2.Demo.RunAsync(System.String[])"

Type "./example add package Newtonsoft.Json"
Sleep 400ms
Enter
Sleep 1s

Type "./example add reference ../MyLib/MyLib.csproj"
Sleep 400ms
Enter
Sleep 1s

Type "./example add --help"
Sleep 400ms
Enter
Sleep 5s

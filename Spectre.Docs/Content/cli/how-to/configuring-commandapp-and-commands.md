---
title: "Configuring CommandApp and Commands"
description: "How to register commands with the CommandApp and configure global settings"
uid: "cli-app-configuration"
order: 2050
---

When building a CLI with multiple commands, use `CommandApp.Configure` to register commands, define aliases, and customize how your application appears in help output.

## What We're Building

A multi-command CLI with `add`, `remove`, and `list`—each with descriptions and examples in help, plus aliases so users can type shorter names like `a` for `add`:

<Screenshot Src="/assets/cli-configuring-app.svg" Alt="Configuring CommandApp demonstration" />

## Register Commands with Metadata

Use `AddCommand<T>("name")` to register each command, then chain methods to add descriptions, aliases, and examples:

```csharp:xmldocid,bodyonly
M:Spectre.Docs.Cli.Examples.DemoApps.ConfiguringCommandApp.Demo.RunAsync(System.String[])
```

Aliases aren't displayed in help output, but they work as alternative names. Users can invoke commands by name or any alias — `myapp rm file.txt` works the same as `myapp remove file.txt`.

## Configure Global Settings

Access `config.Settings` to adjust parsing behavior:

```csharp:xmldocid,bodyonly
M:Spectre.Docs.Cli.Examples.DemoApps.ConfiguringCommandApp.SettingsDemo.RunAsync(System.String[])
```

Common settings include:

| Setting | Purpose |
|---------|---------|
| `CaseSensitivity` | Control whether commands/options are case-sensitive |
| `StrictParsing` | When `false`, unknown flags become remaining arguments instead of errors |

## Development Settings

During development, enable additional validation:

```csharp
#if DEBUG
    config.PropagateExceptions();  // Get full stack traces
    config.ValidateExamples();     // Verify all WithExample calls are valid
#endif
```

`ValidateExamples()` catches typos in your examples at startup rather than confusing users at runtime.

## See Also

- <xref:cli-command-hierarchies> - Nested commands with `AddBranch`
- <xref:cli-help-customization> - Further help customization
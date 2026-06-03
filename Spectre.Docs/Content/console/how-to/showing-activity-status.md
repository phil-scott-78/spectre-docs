---
title: "Show Activity Status"
description: "Display a spinner for operations without measurable progress"
uid: "console-howto-showing-activity-status"
order: 2080
---

When you have an operation without measurable progress, use `AnsiConsole.Status()`.

> [!CAUTION]
> Status spinners are not thread safe. Using them together with other interactive components such as prompts, progress displays, or other status displays is not supported.

## Show a Spinner

To indicate activity, wrap your operation in a status context.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/ShowingActivityStatusHowTo.cs > ShowingActivityStatusHowTo.ShowSpinner
```

## Update the Status Message

To show what's happening, call `ctx.Status()` with new text.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/ShowingActivityStatusHowTo.cs > ShowingActivityStatusHowTo.UpdateStatusMessage
```

## Change the Spinner Style

If you want a different animation, use `.Spinner()` and `.SpinnerStyle()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/ShowingActivityStatusHowTo.cs > ShowingActivityStatusHowTo.ChangeSpinnerStyle
```

## Use Async

To use with async operations, call `.StartAsync()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/ShowingActivityStatusHowTo.cs > ShowingActivityStatusHowTo.UseAsync
```

## See Also

- <xref:console-live-status> - Full Status API reference
- <xref:console-spinner-styles> - All spinner animations

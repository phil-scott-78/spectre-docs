---
title: "Run Tasks with a Spinner"
description: "Show a spinner animation while awaiting async operations"
uid: "console-howto-async-spinner"
order: 2140
---

When you have an async operation, use the `.Spinner()` extension.

## Show a Spinner While Waiting

To display a spinner during an await, call `.Spinner()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/RunningTasksWithSpinnerHowTo.cs > RunningTasksWithSpinnerHowTo.ShowSpinnerWhileWaiting
```

## Change the Animation

To use a different spinner, pass a `Spinner.Known` value.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/RunningTasksWithSpinnerHowTo.cs > RunningTasksWithSpinnerHowTo.ChangeSpinnerAnimation
```

## Get a Result

To get a value back, call `.Spinner()` on a `Task<T>`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/RunningTasksWithSpinnerHowTo.cs > RunningTasksWithSpinnerHowTo.GetResultWithSpinner
```

## See Also

- <xref:console-spinner-styles> - All spinner animations

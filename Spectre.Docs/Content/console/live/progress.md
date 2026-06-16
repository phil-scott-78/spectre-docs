---
title: "Progress Display"
description: "Show progress bars and task status for long-running operations"
uid: "console-live-progress"
order: 4000
---

The Progress display renders animated progress bars for tracking task completion in real-time.

<Screenshot src="/assets/progress.svg" />

## When to Use

Use Progress when you need to **track completion status for long-running operations**. Common scenarios:

- **Multi-step processes**: Show progress across multiple sequential or concurrent tasks
- **File operations**: Display download, upload, or processing progress
- **Build pipelines**: Track compilation, testing, and deployment steps
- **Data processing**: Monitor record processing, imports, or transformations

For **simple status messages without progress tracking**, use [Status](xref:console-live-status) instead. For **real-time data updates**, consider [Live Display](xref:console-live-live-display).

> [!CAUTION]
> Progress display is not thread safe. Using it together with other interactive components such as prompts, status displays, or other progress displays is not supported.

## Basic Usage

Create a progress context and add tasks to track their completion.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.BasicProgressExample
```

## Managing Tasks

### Multiple Tasks

Track several concurrent operations with individual progress bars.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressMultipleTasksExample
```

### Increment vs Value Assignment

Use `Increment()` for relative progress updates or set `Value` directly for absolute positioning.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressIncrementExample
```

### Indeterminate Progress

Use `IsIndeterminate()` when the total duration or size is unknown, showing an animated progress bar without percentage.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressIndeterminateExample
```

### Adding Tasks Dynamically

Add new tasks during execution based on discovered work or changing requirements.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressDynamicTasksExample
```

### Updating Descriptions

Change task descriptions during execution to provide detailed status updates.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressTaskDescriptionUpdateExample
```

## Display Columns

### Custom Column Configuration

Configure which information columns appear in the progress display using `Columns()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressCustomColumnsExample
```

### Available Columns

| Column | Purpose |
|--------|---------|
| `TaskDescriptionColumn` | Shows the task description text |
| `ProgressBarColumn` | Displays the animated progress bar |
| `PercentageColumn` | Shows completion percentage |
| `RemainingTimeColumn` | Estimates time until completion |
| `ElapsedTimeColumn` | Shows time since task started |
| `SpinnerColumn` | Adds an animated spinner indicator |
| `DownloadedColumn` | Shows downloaded bytes (formatted) |
| `TransferSpeedColumn` | Shows transfer rate (bytes/sec) |

### Spinner Animation

Add visual feedback with a spinning animation indicator.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressWithSpinnerExample
```

### Timing Information

Display elapsed time and remaining time estimates for operations.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressTimingColumnsExample
```

### Download Progress

Use specialized columns for file download scenarios with size and speed information.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressDownloadExample
```

## Styling

Customize progress bar appearance with colors to match your application theme or convey meaning.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressBarStylingExample
```

## Refresh Behavior

### Auto Clear

Automatically remove the progress display after all tasks complete using `AutoClear(true)`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressAutoClearExample
```

### Hide Completed Tasks

Remove completed tasks from view while keeping active ones visible using `HideCompleted(true)`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressHideCompletedExample
```

## Async Operations

Use `StartAsync()` for async/await scenarios with Task-based operations.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressAsyncExample
```

### Returning Values

Progress operations can return values for use after completion.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Live/Progress.cs > ProgressExamples.ProgressReturnValueExample
```

## See Also

- <xref:console-howto-showing-progress-bars> - Step-by-step guide
- <xref:console-status-spinners> - Learn progress basics
- <xref:console-live-status> - Simple spinner for indeterminate operations
- <xref:console-spinner-styles> - Available spinner animations

## API Reference

<WidgetApiReference TypeName="Spectre.Console.Progress" />

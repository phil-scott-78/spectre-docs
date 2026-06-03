---
title: "Update Content Live"
description: "Update console output in-place without scrolling"
uid: "console-howto-live-rendering"
order: 2130
---

When you need to update output without scrolling, use `AnsiConsole.Live()`.

> [!CAUTION]
> Live rendering is not thread safe. Using it together with other interactive components such as prompts, progress displays, or status displays is not supported.

## Update in Place

To modify content and refresh the display, call `ctx.Refresh()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/LiveRenderingHowTo.cs > LiveRenderingHowTo.UpdateInPlace
```

## Replace Content

To swap the entire display, use `ctx.UpdateTarget()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/LiveRenderingHowTo.cs > LiveRenderingHowTo.ReplaceContent
```

## Clear on Complete

If you want the display cleared after, use `.AutoClear(true)`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/LiveRenderingHowTo.cs > LiveRenderingHowTo.AutoClearOnComplete
```

## Use Async

To use with async operations, call `.StartAsync()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/LiveRenderingHowTo.cs > LiveRenderingHowTo.UseAsync
```

## See Also

- <xref:console-live-live-display> - Full Live API reference

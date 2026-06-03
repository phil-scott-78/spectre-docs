---
title: "Align Widget"
description: "Control horizontal and vertical alignment of content"
uid: "console-widget-align"
order: 3500
---

The Align widget positions any renderable content within a defined space using horizontal and vertical alignment.

<Screenshot src="/assets/align.svg" />

## When to Use

Use Align when you need to **position content within available space**. Common scenarios:

- **Centering content**: Create title screens, center tables or panels for visual emphasis
- **Right-aligned output**: Align status information, timestamps, or metadata to the right edge
- **Vertical positioning**: Position headers at the top, footers at the bottom, or center dialogs

For **adding spacing around content**, use [Padder](xref:console-widget-padder) instead. For **side-by-side layouts**, use [Columns](xref:console-widget-columns) or [Grid](xref:console-widget-grid).

## Basic Usage

Create aligned content using the static factory methods `Align.Left()`, `Align.Center()`, or `Align.Right()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.BasicAlignExample
```

## Horizontal Alignment

Position content on the left, center, or right. Left alignment is the default for most widgets.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.HorizontalAlignmentExample
```

## Vertical Alignment

### Setting Vertical Position

Use vertical alignment with a specified height to position content vertically within a defined space.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.VerticalAlignmentExample
```

### Combining Alignments

Combine horizontal and vertical alignment to position content in both dimensions simultaneously.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.CombinedAlignmentExample
```

## Using Extension Methods

Use the fluent extension methods like `TopAligned()`, `MiddleAligned()`, and `BottomAligned()` for more readable code.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.FluentExtensionsExample
```

## Controlling Dimensions

### Width

By default, Align uses the content's natural width. Use `Width()` to define the alignment container's width.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.WidthControlExample
```

### Height

Set an explicit height with `Height()` when using vertical alignment to define the vertical space.

## Practical Examples

### Multiple Alignments

Create layouts with different horizontal alignments for visual variety or functional purpose.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.MultipleAlignmentsExample
```

### Centering Tables

Center tables to draw focus and improve presentation for data displays.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.AlignTableExample
```

## Advanced Usage

### Nested Alignment

Combine Align with containers like Panel to create multi-level alignment for complex layouts.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.NestedAlignExample
```

### Title Screens

Use centered alignment for application splash screens or welcome messages.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Align.cs > AlignExamples.TitleScreenExample
```

## See Also

- <xref:console-howto-organizing-layout> - Layout patterns and recipes
- <xref:console-widget-padder> - Add spacing around content
- <xref:console-widget-panel> - Bordered containers with headers
- <xref:console-widget-columns> - Side-by-side layouts
- <xref:console-getting-started> - Learn Spectre.Console basics

## API Reference

<WidgetApiReference TypeName="Spectre.Console.Align" />

---
title: "Table Widget"
description: "Display tabular data with customizable columns, rows, borders, and styling"
uid: "console-widget-table"
order: 3100
---

The Table widget displays structured data in rows and columns with configurable borders, alignment, and styling.

<Screenshot src="/assets/table.svg" />

## When to Use

Use Table when you need to display **structured, multi-column data**. Common scenarios:

- **Data display**: Show records, configuration settings, or query results
- **Comparison**: Side-by-side feature comparisons or specifications
- **Reports**: Formatted output with headers, totals, and alignment

For **simple key-value pairs**, consider using a table with hidden headers or a [Grid](xref:console-widget-grid). For **proportional data visualization**, use [BarChart](xref:console-widget-bar-chart) or [BreakdownChart](xref:console-widget-breakdown-chart).

## Basic Usage

Add columns first, then rows. Each row must have the same number of cells as columns.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.BasicTableExample
```

## Styling

### Border Styles

Choose from 18 built-in border styles. Use `RoundedBorder()` for a modern look or `AsciiBorder()` for maximum compatibility.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.TableBordersExample
```

> [!NOTE]
> See the [Table Border Reference](xref:console-table-border-reference) for a visual guide to all border styles.

### Border Colors

Use `BorderColor()` to match your application's theme. Combine with markup in headers for emphasis.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.TableColorsExample
```

## Column Configuration

### Alignment

Align column content with `LeftAligned()`, `Centered()`, or `RightAligned()`. Right-align numeric data for easier comparison.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.TableAlignmentExample
```

### Width and Padding

Fix column widths with `Width()`, adjust spacing with `PadLeft()` and `PadRight()`, or prevent wrapping with `NoWrap()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.ColumnConfigurationExample
```

## Headers and Footers

Headers display by default. Add footers for totals or summaries. Use `HideHeaders()` for key-value style layouts.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.HeadersAndFootersExample
```

### Hidden Headers

Tables without headers work well for configuration or property displays.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.HiddenHeadersExample
```

## Titles and Captions

Add context with a title above the table and a caption below. Both support markup.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.TitlesAndCaptionsExample
```

## Row Formatting

### Row Separators

Use `ShowRowSeparators()` to add horizontal lines between rows, improving readability for dense data.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.RowSeparatorsExample
```

### Empty Rows

Insert empty rows to group related data visually.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.EmptyRowsExample
```

## Layout

By default, tables use minimum width. Use `Expand()` to fill available console width—useful for reports or dashboards.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.ExpandModeExample
```

## Advanced Usage

### Nested Tables

Embed tables within cells for hierarchical data or sub-groupings.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.NestedTablesExample
```

### Mixed Content

Cells accept any `IRenderable`—combine Markup, Panels, and other widgets for rich layouts.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.MixedContentExample
```

### Dynamic Updates

Modify tables at runtime with `UpdateCell()`, `InsertRow()`, and `RemoveRow()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Table.cs > TableExamples.DynamicTableExample
```

## See Also

- <xref:console-howto-displaying-tabular-data> - Step-by-step guide for common table tasks
- <xref:console-table-border-reference> - All 18 border styles with visual examples
- <xref:console-color-reference> - Available colors for borders and cells
- <xref:console-getting-started> - Learn Spectre.Console basics
- <xref:console-rendering-model> - How tables measure and layout

## API Reference

<WidgetApiReference TypeName="Spectre.Console.Table" />

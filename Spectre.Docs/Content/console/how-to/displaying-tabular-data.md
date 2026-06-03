---
title: "Display Tabular Data"
description: "Display structured data in tables with borders, alignment, and styling"
uid: "console-howto-displaying-tabular-data"
order: 2060
---

When you need to display data in rows and columns, use `Table`.

## Create a Table

To create a table, add columns then rows.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/DisplayingTabularDataHowTo.cs > DisplayingTabularDataHowTo.CreateBasicTable
```

## Style the Borders

If you want rounded borders, call `.RoundedBorder()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/DisplayingTabularDataHowTo.cs > DisplayingTabularDataHowTo.ApplyBorderStyle
```

## Align Columns

To right-align a column, use `.RightAligned()` in the column configuration.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/DisplayingTabularDataHowTo.cs > DisplayingTabularDataHowTo.AlignColumns
```

## Add a Title and Footer

If you need a title, use `.Title()`. For totals, set column footers.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/DisplayingTabularDataHowTo.cs > DisplayingTabularDataHowTo.AddTitleAndFooter
```

## See Also

- <xref:console-widget-table> - Full table API reference
- <xref:console-table-border-reference> - All border styles

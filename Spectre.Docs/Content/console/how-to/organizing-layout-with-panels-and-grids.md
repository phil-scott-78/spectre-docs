---
title: "Organize Layout"
description: "Arrange content using panels, columns, grids, and alignment"
uid: "console-howto-organizing-layout"
order: 2120
---

When you need to structure console output, use layout widgets.

## Wrap in a Panel

To emphasize content with a border, use `Panel`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/OrganizingLayoutHowTo.cs > OrganizingLayoutHowTo.WrapInPanel
```

## Arrange Side by Side

To place content horizontally, use `Columns`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/OrganizingLayoutHowTo.cs > OrganizingLayoutHowTo.ArrangeSideBySide
```

## Create a Grid

To arrange content in rows and columns, use `Grid`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/OrganizingLayoutHowTo.cs > OrganizingLayoutHowTo.CreateGrid
```

## Center Content

To center content horizontally, use `Align.Center()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/OrganizingLayoutHowTo.cs > OrganizingLayoutHowTo.CenterContent
```

## See Also

- <xref:console-widget-panel> - Panel widget reference
- <xref:console-widget-grid> - Grid widget reference
- <xref:console-widget-columns> - Columns widget reference
- <xref:console-box-border-reference> - All border styles

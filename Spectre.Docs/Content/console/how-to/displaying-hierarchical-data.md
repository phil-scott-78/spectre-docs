---
title: "Display Hierarchical Data"
description: "Visualize nested structures using tree views with customizable styling"
uid: "console-howto-displaying-hierarchical-data"
order: 2110
---

When you need to show parent-child relationships, use `Tree`.

## Create a Tree

To create a tree, pass a root label and call `.AddNode()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/DisplayingHierarchicalDataHowTo.cs > DisplayingHierarchicalDataHowTo.CreateBasicTree
```

## Add Nested Levels

To nest deeper, call `.AddNode()` on child nodes.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/DisplayingHierarchicalDataHowTo.cs > DisplayingHierarchicalDataHowTo.AddNestedLevels
```

## Style the Tree

If you want colored nodes, use markup. To change line style, call `.Guide()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/DisplayingHierarchicalDataHowTo.cs > DisplayingHierarchicalDataHowTo.StyleTheTree
```

## Embed Widgets

To embed panels or other widgets, pass them to `.AddNode()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/DisplayingHierarchicalDataHowTo.cs > DisplayingHierarchicalDataHowTo.EmbedRichContent
```

## See Also

- <xref:console-widget-tree> - Full tree API reference
- <xref:console-tree-guide-reference> - All tree line styles

---
title: "Create Custom Renderables"
description: "Build your own widgets by implementing IRenderable"
uid: "console-howto-creating-custom-renderables"
order: 2170
---

When you need a widget that doesn't exist, implement `IRenderable`.

## Implement IRenderable

To create a custom renderable, implement `Measure()` and `Render()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/CreatingCustomRenderablesHowTo.cs > Label
```

## Calculate Size Constraints

To report your widget's size requirements, return a `Measurement` from `Measure()`. The measurement specifies minimum and maximum width in console cells.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/CreatingCustomRenderablesHowTo.cs > Label.Measure
```

## Generate Segments

To produce output, yield `Segment` objects from `Render()`. Each segment contains text and an optional style.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/CreatingCustomRenderablesHowTo.cs > Label.Render
```

## Apply Styles

To add colors and formatting, pass a `Style` when creating segments.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/CreatingCustomRenderablesHowTo.cs > CreatingCustomRenderablesHowTo.ApplyStyles
```

## Wrap Other Renderables

To create container widgets, accept `IRenderable` and delegate rendering.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/CreatingCustomRenderablesHowTo.cs > LabeledValue
```

## See Also

- <xref:console-rendering-model> - How rendering works
- <xref:console-widget-canvas> - Pixel-level rendering example
- <xref:console-widget-panel> - Container widget example

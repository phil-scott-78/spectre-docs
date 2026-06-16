---
title: "Text Widget"
description: "Render styled text with precise control over formatting and overflow"
uid: "console-widget-text"
order: 3000
---

The Text widget renders text content with programmatic control over styling, justification, and overflow behavior.

## When to Use

Use Text when you need **programmatic control over styling** or when styles are determined at runtime. Common scenarios:

- **Status messages**: Apply colors based on success/failure state
- **Computed styles**: Build styles dynamically from variables or configuration
- **Container content**: Embed styled text inside panels, tables, or other widgets

For **inline markup syntax** like `[bold red]text[/]`, use [Markup](xref:console-widget-markup) instead.

## Basic Usage

Create text with a string and optional style.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.BasicTextExample
```

### Multi-line Text

Use newline characters (`\n`) to create multi-line output.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.MultiLineTextExample
```

### Static Members

Use `Text.Empty` and `Text.NewLine` for reusable empty text and line break instances.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.EmptyTextExample
```

## Justification

Use justification to align text within containers like panels.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextJustificationExample
```

Set justification via the property when you need to configure it separately from construction.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextJustificationPropertyExample
```

## Overflow

Control what happens when text exceeds available width.

- **Fold** - Wraps text to the next line (default)
- **Crop** - Truncates text at the boundary
- **Ellipsis** - Truncates and adds an ellipsis character (…)

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextOverflowExample
```

Set overflow via the property for separate configuration.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextOverflowPropertyExample
```

## Styling

### Colors

Apply colors to make text stand out or convey meaning.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextColorsExample
```

> [!NOTE]
> See the [Color Reference](xref:console-color-reference) for all available colors and the [Text Style Reference](xref:console-text-styles) for decoration options.

### Decorations

Use decorations to emphasize text: Bold, Italic, Underline, and Strikethrough.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextDecorationsExample
```

Advanced decorations like Dim, Invert, Conceal, and Blink are available but may not work in all terminals.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextAdvancedDecorationsExample
```

### Combined Styles

Combine multiple decorations using bitwise flags. Styles can include foreground, background, and decorations together.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextCombinedStylesExample
```

### Style Construction

Build styles with the `Style` constructor for full control, or use `Style.Parse()` for a compact string syntax.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextStyleConstructorExample
```

## Properties

Use `Length` and `Lines` to inspect text dimensions when building layouts or calculating sizes.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextPropertiesExample
```

## Working with Containers

Text widgets work well as content inside panels, tables, and other container widgets.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/Text.cs > TextExamples.TextInContainersExample
```

## See Also

- <xref:console-widget-markup> - Inline markup syntax alternative
- <xref:console-color-reference> - All available colors
- <xref:console-text-styles> - Decoration options (bold, italic, etc.)
- <xref:console-getting-started> - Learn markup and styling basics
- <xref:console-rendering-model> - How text rendering works

## API Reference

<WidgetApiReference TypeName="Spectre.Console.Text" />

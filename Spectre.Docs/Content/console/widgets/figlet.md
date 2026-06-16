---
title: "FigletText Widget"
description: "Create large ASCII art text banners using FIGlet fonts"
uid: "console-widget-figlet"
order: 3550
---

The FigletText widget renders text as large ASCII art using FIGlet fonts, creating eye-catching banners and headers.

<Screenshot src="/assets/figlet.svg" />

## When to Use

Use FigletText when you need to **make text stand out dramatically** in console applications. Common scenarios:

- **Application branding**: Display app names and logos at startup
- **Section headers**: Create visual separation between major sections
- **Status announcements**: Highlight important events like "SUCCESS" or "ERROR"

For **simple horizontal dividers**, use [Rule](xref:console-widget-rule) instead. For **regular styled text**, use [Text](xref:console-widget-text).

## Basic Usage

Create figlet text by passing a string to the constructor. The default font renders clear, readable ASCII art.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/FigletText.cs > FigletTextExamples.BasicFigletTextExample
```

## Styling

### Colors

Use the `Color()` method to match your application's theme or emphasize the message.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/FigletText.cs > FigletTextExamples.FigletTextColorExample
```

## Alignment

### Centered Text

Use `Justification` to center figlet text, creating balanced banners and headers.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/FigletText.cs > FigletTextExamples.FigletTextCenterAlignmentExample
```

### All Alignment Options

Control horizontal positioning with left, center, or right alignment.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/FigletText.cs > FigletTextExamples.FigletTextAlignmentExample
```

## Custom Fonts

Load custom FIGlet fonts from `.flf` files to change the appearance. The default font works well for most cases, but custom fonts enable unique branding.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/FigletText.cs > FigletTextExamples.FigletTextCustomFontExample
```

## Advanced Usage

### Creating Banners

Combine figlet text with rules to create bordered announcements.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/FigletText.cs > FigletTextExamples.FigletTextBannerExample
```

### Embedding in Panels

Use panels to add borders and padding around figlet text, perfect for important notifications.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/FigletText.cs > FigletTextExamples.FigletTextInPanelExample
```

### Welcome Screens

Build multi-line welcome messages by combining figlet text with regular text widgets.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/FigletText.cs > FigletTextExamples.FigletTextWelcomeExample
```

## See Also

- <xref:console-widget-rule> - Simple horizontal dividers
- <xref:console-widget-panel> - Wrap figlet text in borders
- <xref:console-color-reference> - Available colors

## API Reference

<WidgetApiReference TypeName="Spectre.Console.FigletText" />

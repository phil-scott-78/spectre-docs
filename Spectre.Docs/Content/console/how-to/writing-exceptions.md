---
title: "Write Exceptions"
description: "Display formatted exception details with stack traces, colors, and clickable links"
uid: "console-howto-writing-exceptions"
order: 2100
---

When you catch an exception and want to display it with formatting and colors, use `WriteException`.

## Write a Basic Exception

To display an exception with default formatting, pass it to `WriteException`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/WritingExceptionsHowTo.cs > WritingExceptionsHowTo.WriteBasicException
```

## Shorten File Paths

To make stack traces more readable, use `ExceptionFormats.ShortenPaths`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/WritingExceptionsHowTo.cs > WritingExceptionsHowTo.ShortenFilePaths
```

## Shorten Everything with Links

For the cleanest output with clickable source links, combine `ShortenEverything` and `ShowLinks`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/WritingExceptionsHowTo.cs > WritingExceptionsHowTo.ShortenEverythingWithLinks
```

## Customize Colors

To match your application's theme, use `ExceptionSettings` with a custom `ExceptionStyle`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/WritingExceptionsHowTo.cs > WritingExceptionsHowTo.CustomizeColors
```

## See Also

- <xref:console-markup-reference> - Style syntax for colors and decorations

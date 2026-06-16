---
title: "SelectionPrompt"
description: "Let users select a single option from a list with keyboard navigation"
uid: "console-prompt-selection"
order: 5050
---

The SelectionPrompt creates interactive menus where users navigate with arrow keys to select one option from a list.

## When to Use

Use SelectionPrompt when you need to **present a clear set of mutually exclusive options**. Common scenarios:

- **Menu navigation**: Main menus, configuration choices, action selection
- **Categorical selection**: Countries, languages, categories with defined options
- **Mode switching**: Environment selection (Dev/Stage/Prod), output formats, themes

For **multiple selections**, use [MultiSelectionPrompt](xref:console-prompt-multi-selection) instead. For **free-form text input**, use [TextPrompt](xref:console-prompt-text) instead.

> [!CAUTION]
> Selection prompts are not thread safe. Using them together with other interactive components such as progress displays, status displays, or other prompts is not supported.

## Basic Usage

The simplest selection prompt needs a title and choices.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.BasicSelectionExample
```

## Adding a Title

Use markup to style the title and draw attention to key information.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.SelectionWithTitleExample
```

## Populating Choices

### Multiple Ways to Add Choices

You can add choices using params arrays, IEnumerable collections, or individual AddChoice calls.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.AddChoicesVariationsExample
```

### Hierarchical Choices

Use `AddChoiceGroup()` to organize choices into categories with parent-child relationships.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.HierarchicalChoicesExample
```

## Navigation

### Pagination

Use `PageSize()` to control how many items display at once, and customize the hint text shown when more choices exist.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.PageSizeExample
```

### Wrap-Around

Enable `WrapAround()` for circular navigation - pressing up at the top jumps to the bottom, and vice versa.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.WrapAroundExample
```

## Search

### Enabling Search

Use `EnableSearch()` to let users type and filter the list instantly - essential for long lists.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.SearchEnabledExample
```

### Search Highlighting

Customize how matched characters are highlighted during search with `SearchHighlightStyle()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.SearchHighlightStyleExample
```

## Styling

### Highlight Style

Use `HighlightStyle()` to customize the appearance of the currently selected item.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.HighlightStyleExample
```

### Disabled Item Style

Use `DisabledStyle()` to style non-selectable items like group headers.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.DisabledStyleExample
```

## Selection Modes

### Leaf Mode

Use `SelectionMode.Leaf` to only allow selecting leaf nodes - parent group headers become non-selectable.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.SelectionModeLeafExample
```

### Independent Mode

Use `SelectionMode.Independent` to allow selecting both parent groups and their children.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.SelectionModeIndependentExample
```

## Working with Complex Objects

Use `UseConverter()` to display custom formatted text for complex objects while returning the actual object.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.CustomConverterExample
```

## Complete Example

This comprehensive example combines search, pagination, wrap-around, custom styling, and complex objects for a realistic project selection menu.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Prompts/SelectionPrompt.cs > SelectionPromptExamples.CompleteExampleWithAllFeatures
```

## See Also

- <xref:console-howto-prompting-for-user-input> - Step-by-step guide
- <xref:console-interactive-prompts> - Learn prompts basics
- <xref:console-prompt-multi-selection> - Select multiple items
- <xref:console-prompt-text> - Free-form text input

## API Reference

<WidgetApiReference TypeName="Spectre.Console.SelectionPrompt`1" />

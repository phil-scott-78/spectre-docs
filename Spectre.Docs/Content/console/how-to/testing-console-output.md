---
title: "Test Console Output"
description: "Write unit tests for console applications using TestConsole"
uid: "console-howto-testing-console-output"
order: 2160
---

When you need to test console output, use `TestConsole` from `Spectre.Console.Testing`.

## Accept IAnsiConsole

To enable testing, accept `IAnsiConsole` as a parameter.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/TestingConsoleOutputHowTo.cs > TestingConsoleOutputHowTo.AcceptConsoleAsParameter
```

## Structure for Testability

To test code, pass `TestConsole` instead of the real console.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/TestingConsoleOutputHowTo.cs > TestingConsoleOutputHowTo.StructureForTestability
```

## Write Testable Methods

To make methods testable, have them accept `IAnsiConsole`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/TestingConsoleOutputHowTo.cs > TestingConsoleOutputHowTo.PrintGreeting
```

## Test Prompts

To test prompts, queue input with `console.Input.PushTextWithEnter()`.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/HowTo/TestingConsoleOutputHowTo.cs > TestingConsoleOutputHowTo.GetUserName
```

## See Also

- [Spectre.Console.Testing](https://www.nuget.org/packages/Spectre.Console.Testing) - Testing package

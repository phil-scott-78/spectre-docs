---
Title: Spectre.Console 0.55.0 released!
Description: Now in Technicolor!
Date: 2026-04-03
---

Version 0.55.0 of Spectre.Console has been released!

This release brings new features, performance improvements, bug fixes, and some important architectural changes.  

> [!CAUTION]
> There are breaking changes in this release, so make sure you review the release notes and try things out before upgrading in production.

## New Spectre.Console.Ansi Library

One of the biggest changes in this release is the introduction of 
[Spectre.Console.Ansi](https://www.nuget.org/packages/spectre.console.ansi), 
a new standalone library for writing ANSI escape
sequences to the terminal without taking a full dependency on `Spectre.Console`.

This makes it easy to add ANSI support to lightweight tools and libraries where
pulling in the full Spectre.Console package would be overkill. Spectre.Console
itself now depends on this library internally.

We've also added some nice convenience methods for the .NET Console class:

```csharp
using Spectre.Console.Ansi;

Console.Markup("[yellow]Hello[/] ");
Console.MarkupLine("[blue]World[/]");
  
Console.Ansi(writer => writer
    .BeginLink("https://spectreconsole.net", linkId: 123)
    .Decoration(Decoration.Bold | Decoration.Italic)
    .Foreground(Color.Yellow)
    .Write("Spectre Console")
    .ResetStyle()
    .EndLink());
```

## Style Is Now a Struct

`Style` has been converted from a class to a struct, and link/URL information
has been extracted into a separate `Link` type. This improves allocation
performance, especially in rendering-heavy scenarios, but is a breaking change
for code that relies on reference semantics.

## Progress Improvements

The `Progress` widget received a lot of love in this release. It now uses
`TimeProvider` instead of the wall clock, making it significantly easier to
write deterministic tests. `ProgressTask` has a new `Tag` property for attaching
arbitrary metadata, and you can now override the global hide-when-completed
behavior on individual tasks. Tasks can also be removed from the progress
context entirely.

Speed calculations have been improved with configurable max sampling age and
sample count, giving you more control over how responsive or smooth the speed
readout is. Speed calculations for stopped tasks have been fixed, and
indeterminate tasks no longer show a meaningless time estimate.

## Prompt Enhancements

Prompts now accept a `CancellationToken`, making it possible to cancel a waiting
prompt programmatically. `TextPrompt` default values can now be edited by the
user instead of being accepted or rejected as a whole. There is also a new
option to clear the prompt line after the user provides input.

## Tables and Rendering

Table body rows now support column spans, and a new minimal border style has
been added for a cleaner look. The `Canvas` widget gained half-block support,
which enables double the vertical resolution when rendering graphics. `JsonText`
now has a configurable indentation depth. Various performance improvements have
also been made to `Markup` instantiation and formatting.

## Bug Fixes

A memory leak related to `Segment` has been fixed, along with
`Segment.SplitLines` ignoring multiple consecutive line breaks. A crash in
`SegmentShape.Calculate` when the lines list was empty has been resolved.
Interactive console detection when output is redirected now works correctly,
and table expand now properly respects fixed column widths. Truncation and
overflow handling for fullwidth characters has been corrected, and locking
performance on .NET 9.0+ has been improved.

## Breaking Changes

This release contains several breaking changes. Please review the following
before upgrading.

`Style` is now a struct. Code relying on reference semantics such as `null`
checks or reference equality will need to be updated. Related to this, link
and URL information has moved from `Style` to a new `Link` type, so any code
that reads or writes links through `Style` will need to be adjusted.

Several previously obsoleted members have been removed. The `Alignment` property
on `Calendar`, `Table`, and `Grid`, as well as the `Render` extension method,
no longer exist. `AnsiConsoleFactory` has been made static and internal, so code
that instantiated this class directly will need an alternative approach.

Finally, ANSI output is now disabled when stdout or stderr is redirected. This
is a behavior change: output that previously included ANSI escape codes when
piped or redirected will now be plain text.

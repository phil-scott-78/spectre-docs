using Spectre.Console;

namespace Spectre.Docs.Examples.Showcase;

/// <summary>Landing-page calendar demo: a static month view with highlighted event days.</summary>
internal class LandingCalendarSample : BaseSample
{
    /// <inheritdoc />
    public override void Run(IAnsiConsole console)
    {
        var calendar = new Calendar(2026, 6)
            .Border(TableBorder.Rounded)
            .HighlightStyle(Style.Parse("yellow bold"))
            .HeaderStyle(Style.Parse("bold"));

        calendar.AddCalendarEvent(2026, 6, 3);
        calendar.AddCalendarEvent(2026, 6, 12);
        calendar.AddCalendarEvent(2026, 6, 24);

        console.Write(calendar);
    }
}

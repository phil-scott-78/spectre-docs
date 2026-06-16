using Spectre.Console;

namespace Spectre.Docs.Examples.Showcase;

/// <summary>Landing-page panel demo: a static release-notes panel.</summary>
internal class LandingPanelSample : BaseSample
{
    /// <inheritdoc />
    public override void Run(IAnsiConsole console)
    {
        var body = new Markup(
            "[green]v0.55.0[/] is now available\n\n" +
            "[grey]•[/] New layout engine\n" +
            "[grey]•[/] 12 additional spinners\n" +
            "[grey]•[/] Faster ANSI output");

        var panel = new Panel(body)
            .Header("[bold]Release notes[/]")
            .RoundedBorder()
            .BorderColor(Color.Grey);

        console.Write(panel);
    }
}

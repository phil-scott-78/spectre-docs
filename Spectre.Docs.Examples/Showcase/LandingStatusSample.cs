using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Docs.Examples.Showcase;

/// <summary>
/// Landing-page status demo: several completed steps with a final step whose spinner spins
/// indefinitely. This is the only animated card in the gallery — the loop runs a whole number
/// of spinner cycles so the recording loops seamlessly.
/// </summary>
internal class LandingStatusSample : BaseSample
{
    /// <inheritdoc />
    public override void Run(IAnsiConsole console)
    {
        var frames = Spinner.Known.Dots.Frames;

        IRenderable Build(string spinner) => new Rows(
            new Markup("[green]✓[/] Restored dependencies"),
            new Markup("[green]✓[/] Compiled [bold]142[/] files"),
            new Markup("[green]✓[/] Bundled assets"),
            new Markup("[green]✓[/] Ran 86 tests"),
            new Markup($"[blue]{spinner}[/] Deploying…"));

        console.Live(Build(frames[0])).Start(ctx =>
        {
            // Five full cycles of the spinner so the recording loops seamlessly.
            for (var i = 0; i < frames.Count * 5; i++)
            {
                ctx.UpdateTarget(Build(frames[i % frames.Count]));
                ctx.Refresh();
                Thread.Sleep(85);
            }
        });
    }
}

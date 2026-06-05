using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Docs.Examples.Showcase;

/// <summary>
/// Landing-page prompt demo: a faithful selection prompt whose highlight sweeps through the
/// choices and back, looping. (A real selection prompt is interactive and cannot be captured
/// non-interactively, so the appearance is composed with real Spectre primitives.)
/// </summary>
internal class LandingPromptSample : BaseSample
{
    /// <inheritdoc />
    public override void Run(IAnsiConsole console)
    {
        string[] choices = ["Build", "Test", "Publish", "Deploy", "Clean"];
        const string title = "What do you want to [green]run[/]?";

        // Sweep down then back up so the recording loops smoothly.
        int[] sequence = [0, 1, 2, 3, 4, 3, 2, 1];

        console.Live(new Text(string.Empty)).AutoClear(false).Start(ctx =>
        {
            foreach (var selected in sequence)
            {
                var rows = new List<IRenderable>
                {
                    new Markup(title),
                    Text.Empty,
                };

                for (var i = 0; i < choices.Length; i++)
                {
                    rows.Add(i == selected
                        ? new Markup($"[blue]> {choices[i]}[/]")
                        : new Markup($"[grey]  {choices[i]}[/]"));
                }

                ctx.UpdateTarget(new Rows(rows));
                ctx.Refresh();
                Thread.Sleep(550);
            }
        });
    }
}

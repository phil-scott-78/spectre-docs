using Spectre.Console;

namespace Spectre.Docs.Examples.Showcase;

/// <summary>Landing-page tree demo: a static project layout.</summary>
internal class LandingTreeSample : BaseSample
{
    /// <inheritdoc />
    public override void Run(IAnsiConsole console)
    {
        var tree = new Tree("[bold]src/[/]")
            .Guide(TreeGuide.Line);

        var lib = tree.AddNode("[green]Spectre.Console/[/]");
        lib.AddNode("AnsiConsole.cs");

        var widgets = tree.AddNode("[green]Widgets/[/]");
        widgets.AddNode("Table.cs");
        widgets.AddNode("BarChart.cs");

        tree.AddNode("README.md");

        console.Write(tree);
    }
}

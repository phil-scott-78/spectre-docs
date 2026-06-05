using Spectre.Console;

namespace Spectre.Docs.Examples.Showcase;

/// <summary>Landing-page bar chart demo: a static throughput chart.</summary>
internal class LandingBarChartSample : BaseSample
{
    /// <inheritdoc />
    public override void Run(IAnsiConsole console)
    {
        var chart = new BarChart()
            .Width(34)
            .Label("[bold]Throughput[/]")
            .AddItem("Rust", 92, Color.Orange1)
            .AddItem("C#", 78, Color.Green)
            .AddItem("Go", 64, Color.Blue)
            .AddItem("Python", 51, Color.Yellow)
            .AddItem("Zig", 35, Color.Red);

        console.Write(chart);
    }
}

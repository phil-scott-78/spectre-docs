using Spectre.Console;

namespace Spectre.Docs.Examples.Showcase;

/// <summary>Landing-page table demo: a static, data-rich service-status table (wide card).</summary>
internal class LandingTableSample : BaseSample
{
    /// <inheritdoc />
    public override void Run(IAnsiConsole console)
    {
        var table = new Table()
            .RoundedBorder()
            .BorderColor(Color.Grey)
            .Expand();

        table.AddColumn("[bold]Service[/]");
        table.AddColumn("[bold]Version[/]");
        table.AddColumn("[bold]Status[/]");
        table.AddColumn("[bold]Region[/]");
        table.AddColumn("[bold]Uptime[/]");
        table.AddColumn(new TableColumn("[bold]CPU[/]") { Alignment = Justify.Right });

        table.AddRow("api-gateway", "v2.4.1", "[green]healthy[/]", "us-east-1", "99.98%", "12%");
        table.AddRow("auth-service", "v1.9.0", "[green]healthy[/]", "us-east-1", "99.95%", "8%");
        table.AddRow("payments", "v3.1.2", "[yellow]degraded[/]", "eu-west-1", "97.20%", "[yellow]64%[/]");
        table.AddRow("search", "v0.8.7", "[green]healthy[/]", "us-west-2", "99.99%", "23%");
        table.AddRow("worker", "v2.0.0", "[red]offline[/]", "eu-west-1", "[red]0.00%[/]", "0%");
        table.AddRow("cache", "v7.2.1", "[green]healthy[/]", "us-east-1", "100.0%", "41%");
        table.AddRow("cdn-edge", "v4.5.0", "[green]healthy[/]", "global", "99.97%", "17%");

        console.Write(table);
    }
}

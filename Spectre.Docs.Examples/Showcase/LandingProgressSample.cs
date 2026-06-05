using Spectre.Console;

namespace Spectre.Docs.Examples.Showcase;

/// <summary>Landing-page progress demo: multi-task bars that fill in place, looping.</summary>
internal class LandingProgressSample : BaseSample
{
    /// <inheritdoc />
    public override void Run(IAnsiConsole console)
    {
        console.Progress()
            .AutoClear(false)
            .Columns(
                new TaskDescriptionColumn(),
                new ProgressBarColumn(),
                new PercentageColumn())
            .Start(ctx =>
            {
                var random = new Random(7);
                var restore = ctx.AddTask("[green]Restoring packages[/]");
                var build = ctx.AddTask("[blue]Compiling sources[/]");
                var test = ctx.AddTask("[yellow]Running tests[/]");

                while (!ctx.IsFinished)
                {
                    restore.Increment(random.NextDouble() * 3.2);
                    build.Increment(random.NextDouble() * 2.4);
                    test.Increment(random.NextDouble() * 1.8);
                    Thread.Sleep(60);
                }
            });
    }
}

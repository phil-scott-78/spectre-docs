using Pennington.FrontMatter;

namespace Spectre.Console;

public abstract record BaseSpectreConsoleFrontMatter : IFrontMatter, ITaggable, ISectionable, IOrderable, IRedirectable
{
    public string Title { get; init; } = "Empty title";
    public string? Description { get; init; }
    public string? Uid { get; init; }
    public DateTime Date { get; init; } = DateTime.Now;
    public bool IsDraft { get; init; }
    public string[] Tags { get; init; } = [];
    public string? RedirectUrl { get; init; }
    public string? SectionLabel { get; init; }
    public int Order { get; init; } = int.MaxValue;

    DateTime? IFrontMatter.Date => Date;
}

public record SpectreConsoleCliFrontMatter : BaseSpectreConsoleFrontMatter;

public record SpectreConsoleFrontMatter : BaseSpectreConsoleFrontMatter;

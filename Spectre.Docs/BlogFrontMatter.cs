using Pennington.FrontMatter;

namespace Spectre.Console;

/// <summary>
/// Front matter for blog posts in the Spectre.Console documentation.
/// </summary>
public record BlogFrontMatter : IFrontMatter, ITaggable, IRedirectable
{
    public string Title { get; init; } = "Empty title";
    public string Author { get; init; } = "Spectre.Console Team";
    public string? Description { get; init; }
    public DateTime Date { get; init; } = DateTime.Now;
    public bool IsDraft { get; init; }
    public string[] Tags { get; init; } = [];
    public string Series { get; init; } = string.Empty;
    public string? RedirectUrl { get; init; }
    public string? SectionLabel { get; init; }
    public string? Uid { get; init; }
    public string? Repository { get; init; }

    DateTime? IFrontMatter.Date => Date;
}

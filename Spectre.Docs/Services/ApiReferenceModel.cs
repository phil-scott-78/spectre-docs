namespace Spectre.Docs.Services;

/// <summary>
/// Presentation view model for a single documented type. Shared by the inline
/// <c>WidgetApiReference</c> Mdazor component and the full <c>/console/api</c> ·
/// <c>/cli/api</c> pages so both render through the same <c>ApiReferenceView</c> markup.
/// <para>
/// Fields suffixed <c>Html</c> are emitted with <c>@((MarkupString)…)</c>: the reflection-
/// backed widget feeds them HTML-encoded plain text, while the Pennington metadata path
/// feeds pre-rendered xmldoc/signature HTML. Plain fields render as auto-encoded text.
/// </para>
/// </summary>
public sealed record ApiReferenceModel(
    string? SummaryHtml,
    IReadOnlyList<ApiMemberView> Constructors,
    IReadOnlyList<ApiPropertyView> Properties,
    IReadOnlyList<ApiMemberView> Methods,
    IReadOnlyList<ApiMemberView> ExtensionMethods)
{
    public bool IsEmpty =>
        string.IsNullOrEmpty(SummaryHtml)
        && Constructors.Count == 0
        && Properties.Count == 0
        && Methods.Count == 0
        && ExtensionMethods.Count == 0;
}

/// <summary>A constructor, method, or extension method rendered as a signature card.</summary>
public sealed record ApiMemberView(
    string SignatureHtml,
    string? SummaryHtml,
    string? ReturnsHtml,
    IReadOnlyList<ApiParamView> Parameters);

/// <summary>A property rendered as a name + type card.</summary>
public sealed record ApiPropertyView(
    string Name,
    string Type,
    string? SummaryHtml);

/// <summary>A single parameter row within a member card.</summary>
public sealed record ApiParamView(
    string Name,
    string? Type,
    string? DescriptionHtml);

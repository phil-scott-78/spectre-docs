using System.Collections.Immutable;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Pennington.ApiMetadata;

namespace Spectre.Docs.Services;

/// <summary>
/// Bridges Pennington's reflection-backed <see cref="IApiMetadataProvider"/> registrations
/// (keyed "console" / "cli", wired in Program.cs) into the site's own
/// <see cref="ApiReferenceModel"/> so the API pages render with the existing widget styling.
/// </summary>
public sealed class ApiReferenceService(IServiceProvider services, IXmlDocHtmlRenderer html)
{
    private IApiMetadataProvider Provider(string area) =>
        services.GetRequiredKeyedService<IApiMetadataProvider>(area);

    /// <summary>
    /// URL slug for a type, derived from its uid so generic and non-generic types with the same
    /// short name (e.g. <c>Command</c> and <c>Command&lt;TSettings&gt;</c>) stay distinct. The
    /// xmldocid arity backtick (<c>`1</c>) is made URL-safe as <c>-1</c>.
    /// </summary>
    public static string SlugFor(ApiTypeSummary type)
    {
        var uid = type.Uid;
        if (uid.StartsWith("T:", StringComparison.Ordinal)) uid = uid[2..];
        return uid.Replace('`', '-');
    }

    /// <summary>Display name including a generic-arity marker (e.g. <c>Command&lt;&gt;</c>) so same-named types are distinguishable in listings.</summary>
    public static string DisplayName(ApiTypeSummary type)
    {
        var tick = type.Uid.IndexOf('`');
        if (tick < 0) return type.Name;
        return type.Name.Contains('<') ? type.Name : type.Name + "<>";
    }

    /// <summary>Site-relative URL prefix for an area's API reference, nested under its Reference section.</summary>
    public static string BaseUrl(string area) => $"/{area}/reference/api/";

    /// <summary>Trailing-slashed page URL for a type (e.g. <c>/console/reference/api/Spectre.Console.Table/</c>).</summary>
    public static string LinkFor(string area, ApiTypeSummary type) => $"{BaseUrl(area)}{SlugFor(type)}/";

    /// <summary>All documented types for an area, already sorted by full type name.</summary>
    public async Task<IReadOnlyList<ApiTypeSummary>> GetTypesAsync(string area) =>
        await Provider(area).GetTypesAsync();

    /// <summary>
    /// Resolves a route slug to a rendered type page, or <see langword="null"/> when the slug
    /// matches no documented type in the area.
    /// </summary>
    public async Task<ApiTypePage?> GetTypePageAsync(string area, string slug)
    {
        slug = slug.Trim('/');
        if (string.IsNullOrEmpty(slug)) return null;

        var provider = Provider(area);
        var types = await provider.GetTypesAsync();
        var summary = types.FirstOrDefault(t =>
            string.Equals(SlugFor(t), slug, StringComparison.OrdinalIgnoreCase));
        if (summary is null) return null;

        var detail = await provider.GetTypeAsync(summary.Uid);
        var ctors = await provider.GetMembersAsync(summary.Uid, MemberKind.Constructors, AccessFilter.Public, MemberOrder.Declaration);
        var props = await provider.GetMembersAsync(summary.Uid, MemberKind.Properties, AccessFilter.Public, MemberOrder.Alphabetical);
        var methods = await provider.GetMembersAsync(summary.Uid, MemberKind.Methods, AccessFilter.Public, MemberOrder.Alphabetical);
        var extensions = await provider.GetExtensionMethodsForAsync(summary.Name);

        var model = new ApiReferenceModel(
            SummaryHtml: detail is not null ? RenderInline(detail.Xmldoc.Summary) : null,
            Constructors: ctors.Select(ToMember).ToList(),
            Properties: props.Select(ToProperty).ToList(),
            Methods: methods.Select(ToMember).ToList(),
            ExtensionMethods: extensions.Select(ToExtension).ToList());

        return new ApiTypePage(summary, model);
    }

    private ApiMemberView ToMember(ApiMember m) => new(
        SignatureHtml: m.SignatureHtml ?? WebUtility.HtmlEncode(m.Name),
        SummaryHtml: RenderInline(m.Xmldoc.Summary),
        ReturnsHtml: m.Xmldoc.HasReturns ? RenderInline(m.Xmldoc.Returns) : null,
        Parameters: m.Parameters.Select(ToParam).ToList());

    private ApiPropertyView ToProperty(ApiMember m) => new(
        Name: m.Name,
        Type: m.TypeDisplay,
        SummaryHtml: RenderInline(m.Xmldoc.Summary));

    private ApiMemberView ToExtension(ExtensionMethodEntry e) => new(
        // ExtensionMethodEntry exposes the full signature inline (params included) but no
        // structured parameter list, so the card shows signature + summary + returns only.
        SignatureHtml: WebUtility.HtmlEncode(e.Signature),
        SummaryHtml: RenderInline(e.Xmldoc.Summary),
        ReturnsHtml: e.Xmldoc.HasReturns ? RenderInline(e.Xmldoc.Returns) : null,
        Parameters: []);

    private ApiParamView ToParam(ApiParameter p) => new(
        Name: p.Name,
        Type: p.TypeDisplay,
        DescriptionHtml: RenderInline(p.Description));

    private string? RenderInline(ImmutableArray<XmlDocNode> nodes) =>
        nodes.IsDefaultOrEmpty ? null : html.RenderInlineHtml(nodes);
}

/// <summary>A resolved type page: the type header plus its rendered member model.</summary>
public sealed record ApiTypePage(ApiTypeSummary Summary, ApiReferenceModel Model);

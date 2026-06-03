using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;
using Pennington.ApiMetadata;
using Pennington.Content;
using Pennington.Pipeline;
using Pennington.Routing;

namespace Spectre.Docs.Services;

/// <summary>
/// Registers the API reference routes (the per-area index plus one page per documented type)
/// with the Pennington pipeline. The published package has no built-in API reference content
/// service, so this supplies the discovery the static build crawler needs to emit the pages and
/// the "API Reference" sidebar entry. The reference lives under each area's existing Reference
/// section (<c>/console/reference/api/</c>, <c>/cli/reference/api/</c>) so it slots into the
/// section nav without disrupting the host's single-root tree flatten. The pages render via the
/// catch-all Razor components (<see cref="RazorPageSource"/>).
/// </summary>
public sealed class ApiReferenceContentService(IServiceProvider services) : IContentService
{
    private static readonly (string Area, string Component)[] Areas =
    [
        ("console", "Spectre.Docs.Components.Pages.ConsoleApiPage"),
        ("cli", "Spectre.Docs.Components.Pages.CliApiPage"),
    ];

    public string DefaultSectionLabel => string.Empty;

    public int SearchPriority => 0;

    public async IAsyncEnumerable<DiscoveredItem> DiscoverAsync()
    {
        using var scope = services.CreateScope();
        foreach (var (area, component) in Areas)
        {
            yield return Page(ApiReferenceService.BaseUrl(area), component);

            var provider = scope.ServiceProvider.GetRequiredKeyedService<IApiMetadataProvider>(area);
            foreach (var type in await provider.GetTypesAsync())
            {
                yield return Page(ApiReferenceService.LinkFor(area, type), component);
            }
        }
    }

    public Task<ImmutableList<ContentTocItem>> GetContentTocEntriesAsync()
    {
        // Only the index gets a nav entry, placed inside the area's existing "reference" folder
        // group (HierarchyParts = [area, "reference"]) so it appears under Reference in the sidebar.
        // Per-type pages stay out of the nav (they are discovered for the build, not listed).
        var items = Areas
            .Select(a => new ContentTocItem(
                "API Reference",
                ContentRouteFactory.FromUrl(new UrlPath(ApiReferenceService.BaseUrl(a.Area)), string.Empty),
                int.MaxValue,
                [a.Area, "reference"],
                a.Area,
                null))
            .ToImmutableList();
        return Task.FromResult(items);
    }

    public Task<ImmutableList<ContentToCopy>> GetContentToCopyAsync() =>
        Task.FromResult(ImmutableList<ContentToCopy>.Empty);

    public Task<ImmutableList<CrossReference>> GetCrossReferencesAsync() =>
        Task.FromResult(ImmutableList<CrossReference>.Empty);

    public Task<ImmutableList<ContentToCreate>> GetContentToCreateAsync() =>
        Task.FromResult(ImmutableList<ContentToCreate>.Empty);

    private static DiscoveredItem Page(string url, string componentType) =>
        new(ContentRouteFactory.FromUrl(new UrlPath(url), string.Empty), new RazorPageSource(componentType));
}

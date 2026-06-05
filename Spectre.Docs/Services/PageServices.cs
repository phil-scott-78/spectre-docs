using System.Collections.Immutable;
using Pennington.Content;
using Pennington.FrontMatter;
using Pennington.Navigation;
using Pennington.Pipeline;
using Pennington.Routing;

namespace Spectre.Docs.Services;

public sealed record MarkdownContentPage<T>(
    T FrontMatter,
    string Url,
    ImmutableList<Tag> Tags,
    OutlineEntry[] Outline) where T : class, IFrontMatter;

public sealed record RenderedMarkdownPage<T>(
    MarkdownContentPage<T> Page,
    string HtmlContent) where T : class, IFrontMatter;

public interface IMarkdownContentService<T> where T : class, IFrontMatter, new()
{
    Task<ImmutableList<MarkdownContentPage<T>>> GetAllContentPagesAsync();

    Task<RenderedMarkdownPage<T>?> GetRenderedContentPageByUrlOrDefault(string url);
}

/// <summary>
/// Shared section-prefix matching used to scope the shared content services to a single
/// markdown source (<c>/console</c>, <c>/cli</c>, <c>/blog</c>). Kept in one place so the
/// content service and the navigation service can't drift apart.
/// </summary>
internal static class SectionPrefix
{
    /// <summary>Leading-slashed, trailing-slash-stripped form; empty/"/" means "match everything".</summary>
    public static string Normalize(string prefix)
    {
        if (string.IsNullOrEmpty(prefix)) return "/";
        var s = prefix.StartsWith('/') ? prefix : "/" + prefix;
        return s.Length > 1 && s.EndsWith('/') ? s[..^1] : s;
    }

    /// <summary>True when <paramref name="path"/> is the section root or sits beneath it (case-insensitive).</summary>
    public static bool Contains(string normalizedPrefix, string path)
    {
        if (string.IsNullOrEmpty(normalizedPrefix) || normalizedPrefix == "/") return true;
        return path.StartsWith(normalizedPrefix + "/", StringComparison.OrdinalIgnoreCase)
               || string.Equals(path, normalizedPrefix, StringComparison.OrdinalIgnoreCase)
               || string.Equals(path, normalizedPrefix + "/", StringComparison.OrdinalIgnoreCase);
    }
}

/// <summary>
/// A typed view over Pennington's content pipeline for the site's Razor components. Each instance
/// is scoped to one markdown source (<c>/console</c>, <c>/cli</c>, <c>/blog</c>) by URL-prefix, and
/// pulls already-parsed <see cref="ParsedItem"/>s from the shared <see cref="IContentService"/>
/// pipeline (<see cref="IContentService.ParseContentAsync"/>) rather than re-reading and re-parsing
/// files itself — the parser/cache lives in the pipeline. Rendering reuses the shared
/// <see cref="IContentRenderer"/>, so output matches the engine's own pages.
/// </summary>
public sealed class MarkdownContentService<T>(
    IEnumerable<IContentService> contentServices,
    IContentRenderer renderer,
    string basePageUrlPrefix)
    : IMarkdownContentService<T> where T : class, IFrontMatter, new()
{
    private readonly string _prefix = SectionPrefix.Normalize(basePageUrlPrefix);

    public async Task<ImmutableList<MarkdownContentPage<T>>> GetAllContentPagesAsync()
    {
        var builder = ImmutableList.CreateBuilder<MarkdownContentPage<T>>();
        foreach (var service in contentServices)
        {
            await foreach (var item in service.ParseContentAsync())
            {
                if (!BelongsToSource(item.Route)) continue;
                if (item.Metadata is not T typed || typed.IsDraft) continue;

                var tags = (typed as ITaggable)?.Tags ?? [];
                var tagList = tags
                    .Select(t => new Tag(t, t.ToLowerInvariant().Replace(' ', '-')))
                    .ToImmutableList();

                builder.Add(new MarkdownContentPage<T>(
                    typed,
                    item.Route.CanonicalPath.Value,
                    tagList,
                    []));
            }
        }
        return builder.ToImmutable();
    }

    public async Task<RenderedMarkdownPage<T>?> GetRenderedContentPageByUrlOrDefault(string url)
    {
        var input = NormalizeUrl(url);
        var candidates = new[] { input, input.EnsureTrailingSlash(), input.RemoveTrailingSlash() };

        foreach (var service in contentServices)
        {
            await foreach (var item in service.ParseContentAsync())
            {
                if (!BelongsToSource(item.Route)) continue;
                if (!candidates.Any(c => item.Route.CanonicalPath.Matches(c))) continue;
                if (item.Metadata is not T typed || typed.IsDraft) continue;

                var rendered = await renderer.RenderAsync(item);
                if (rendered is not RenderedItem r) continue;

                var page = new MarkdownContentPage<T>(
                    typed,
                    item.Route.CanonicalPath.Value,
                    r.Content.Tags,
                    r.Content.Outline);
                return new RenderedMarkdownPage<T>(page, r.Content.Html);
            }
        }
        return null;
    }

    private bool BelongsToSource(ContentRoute route)
        => SectionPrefix.Contains(_prefix, route.CanonicalPath.Value);

    private static UrlPath NormalizeUrl(string url)
    {
        var s = url ?? string.Empty;
        return new UrlPath(s.StartsWith('/') ? s : "/" + s);
    }
}

public sealed class TableOfContentsService(
    IEnumerable<IContentService> contentServices,
    NavigationBuilder navigationBuilder)
{
    public async Task<ImmutableList<NavigationTreeItem>> GetNavigationTreeAsync(string currentPath, string sectionKey)
    {
        var allItems = ImmutableList.CreateBuilder<ContentTocItem>();
        foreach (var service in contentServices)
        {
            allItems.AddRange(await service.GetContentTocEntriesAsync());
        }

        var prefix = SectionPrefix.Normalize(sectionKey);
        var filtered = allItems
            .Where(i => SectionPrefix.Contains(prefix, i.Route.CanonicalPath.Value))
            .ToList();

        var currentUrl = ToUrlPath(currentPath);
        var tree = await navigationBuilder.BuildTreeAsync(filtered, currentUrl);

        // The tree typically wraps everything in a single root section whose Title matches the
        // section label; flatten that so the sidebar shows the entries themselves.
        if (tree.Count == 1 && tree[0].Children.Count > 0)
        {
            return tree[0].Children;
        }
        return tree;
    }

    public async Task<NavigationInfo> GetNavigationInfoAsync(string url)
    {
        var allItems = ImmutableList.CreateBuilder<ContentTocItem>();
        foreach (var service in contentServices)
        {
            allItems.AddRange(await service.GetContentTocEntriesAsync());
        }

        var currentUrl = ToUrlPath(url);
        return await navigationBuilder.BuildNavigationInfoAsync(allItems.ToImmutable(), currentUrl);
    }

    private static UrlPath ToUrlPath(string url)
    {
        var normalized = string.IsNullOrEmpty(url) ? "/" : (url.StartsWith('/') ? url : "/" + url);
        return new UrlPath(normalized);
    }
}

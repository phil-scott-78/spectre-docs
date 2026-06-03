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
/// A typed wrapper over Pennington's content pipeline. Filters the shared
/// <see cref="IContentService"/> enumerable by URL-prefix so each typed service
/// only sees pages from its own markdown source, then re-parses each file with
/// the correct <typeparamref name="T"/> via <see cref="FrontMatterParser"/>.
/// </summary>
public sealed class MarkdownContentService<T>(
    IEnumerable<IContentService> contentServices,
    FrontMatterParser frontMatterParser,
    IContentRenderer renderer,
    string basePageUrlPrefix)
    : IMarkdownContentService<T> where T : class, IFrontMatter, new()
{
    private readonly string _prefix = NormalizePrefix(basePageUrlPrefix);

    public async Task<ImmutableList<MarkdownContentPage<T>>> GetAllContentPagesAsync()
    {
        var builder = ImmutableList.CreateBuilder<MarkdownContentPage<T>>();
        foreach (var service in contentServices)
        {
            await foreach (var discovered in service.DiscoverAsync())
            {
                if (!BelongsToSource(discovered.Route)) continue;
                var parsed = await TryParseAsync(discovered);
                if (parsed is null) continue;

                var tags = (parsed.Metadata as ITaggable)?.Tags ?? [];
                var tagList = tags
                    .Select(t => new Tag(t, t.ToLowerInvariant().Replace(' ', '-')))
                    .ToImmutableList();

                builder.Add(new MarkdownContentPage<T>(
                    parsed.Metadata,
                    discovered.Route.CanonicalPath.Value,
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
            await foreach (var discovered in service.DiscoverAsync())
            {
                if (!BelongsToSource(discovered.Route)) continue;
                if (!candidates.Any(c => discovered.Route.CanonicalPath.Matches(c))) continue;

                var parsed = await TryParseAsync(discovered);
                if (parsed is null) continue;

                var parsedItem = new ParsedItem(discovered.Route, parsed.Metadata, parsed.Body);
                var rendered = await renderer.RenderAsync(parsedItem);
                if (rendered is not RenderedItem r) continue;

                var page = new MarkdownContentPage<T>(
                    parsed.Metadata,
                    discovered.Route.CanonicalPath.Value,
                    r.Content.Tags,
                    r.Content.Outline);
                return new RenderedMarkdownPage<T>(page, r.Content.Html);
            }
        }
        return null;
    }

    private bool BelongsToSource(ContentRoute route)
    {
        if (string.IsNullOrEmpty(_prefix) || _prefix == "/") return true;
        var path = route.CanonicalPath.Value;
        return path.StartsWith(_prefix + "/", StringComparison.OrdinalIgnoreCase)
               || string.Equals(path, _prefix, StringComparison.OrdinalIgnoreCase)
               || string.Equals(path, _prefix + "/", StringComparison.OrdinalIgnoreCase);
    }

    private async Task<ParsedFrontMatter<T>?> TryParseAsync(DiscoveredItem discovered)
    {
        if (discovered.Route.SourceFile is not { } sourceFile) return null;
        var filePath = sourceFile.Value;
        if (!File.Exists(filePath)) return null;

        var content = await File.ReadAllTextAsync(filePath);
        var result = frontMatterParser.Parse<T>(content);
        if (result.Metadata is null) return null;
        if (result.Metadata.IsDraft) return null;
        return new ParsedFrontMatter<T>(result.Metadata, result.Body);
    }

    private static UrlPath NormalizeUrl(string url)
    {
        var s = url ?? string.Empty;
        return new UrlPath(s.StartsWith('/') ? s : "/" + s);
    }

    private static string NormalizePrefix(string prefix)
    {
        if (string.IsNullOrEmpty(prefix)) return "/";
        var s = prefix.StartsWith('/') ? prefix : "/" + prefix;
        return s.Length > 1 && s.EndsWith('/') ? s[..^1] : s;
    }

    private sealed record ParsedFrontMatter<TMeta>(TMeta Metadata, string Body) where TMeta : class, IFrontMatter;
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

        var prefix = "/" + sectionKey.Trim('/').ToLowerInvariant();
        var filtered = allItems
            .Where(i =>
            {
                var p = i.Route.CanonicalPath.Value;
                return p.StartsWith(prefix + "/", StringComparison.OrdinalIgnoreCase)
                       || string.Equals(p, prefix, StringComparison.OrdinalIgnoreCase)
                       || string.Equals(p, prefix + "/", StringComparison.OrdinalIgnoreCase);
            })
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

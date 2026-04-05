using MyLittleContentEngine.Services.Content;
using MyLittleContentEngine.Services.Spa;
using Spectre.Console;

namespace Spectre.Docs.Slots;

internal class SpectreArticleIslandRenderer(
    IMarkdownContentService<SpectreConsoleFrontMatter> consoleContentService,
    IMarkdownContentService<SpectreConsoleCliFrontMatter> cliContentService,
    ComponentRenderer renderer) : RazorIslandRenderer<Components.SpectreArticle>(renderer)
{
    public override string IslandName => "content";

    protected override async Task<IDictionary<string, object?>?> BuildParametersAsync(string url)
    {
        // Try console content first, then CLI
        var consoleResult = await consoleContentService.GetRenderedContentPageByUrlOrDefault(url);
        if (consoleResult is not null)
        {
            return BuildParams(
                consoleResult.Value.Page.FrontMatter.Title,
                consoleResult.Value.Page.FrontMatter.Description,
                consoleResult.Value.HtmlContent);
        }

        var cliResult = await cliContentService.GetRenderedContentPageByUrlOrDefault(url);
        if (cliResult is not null)
        {
            return BuildParams(
                cliResult.Value.Page.FrontMatter.Title,
                cliResult.Value.Page.FrontMatter.Description,
                cliResult.Value.HtmlContent);
        }

        return null;
    }

    private static Dictionary<string, object?> BuildParams(string title, string description, string htmlContent) =>
        new()
        {
            [nameof(Components.SpectreArticle.Title)] = title,
            [nameof(Components.SpectreArticle.Description)] = description,
            [nameof(Components.SpectreArticle.HtmlContent)] = htmlContent,
        };
}

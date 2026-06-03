# Spectre.Docs - Documentation Site Guide

This is the documentation website for **Spectre.Console** (rich console UI library) and **Spectre.CLI** (command-line application framework). This guide will help you contribute documentation, add samples, and work with the site effectively.

## Technology Stack

- **.NET 11.0** - Blazor Server application
- **Pennington** - Markdown-based content engine for .NET
- **MonorailCss** - Utility-first CSS framework
- **Pennington.TreeSitter** - Tree-sitter code-fragment extraction for live code samples

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- For creating animated samples (optional):
    - [VCR#](https://github.com/phil-scott-78/vcr)
    - [ffmpeg](https://ffmpeg.org/download.html) - Media conversion tool
    - [ttyd](https://github.com/tsl0922/ttyd) - Terminal sharing over the web

### Running the Site Locally

Navigate to the `Spectre.Docs` directory and run:

```bash
dotnet watch
```

The application will be available at `https://localhost:5203` (or check console output for the exact port).

The project is configured with **hot reload** - changes to markdown files in `Content/**/*` will automatically refresh the site during development.

### Deploying

```bash
dotnet run -- build <outputfolder>
```

## Content Organization

The site uses a multi-service content architecture with three main sections:

```
Content/
├── console/          # Spectre.Console documentation
│   ├── how-to/
│   ├── tutorials/
│   ├── widgets/
│   ├── live/
│   ├── prompts/
│   ├── reference/
│   └── explanation/
├── cli/              # Spectre.CLI documentation
│   ├── how-to/
│   ├── tutorials/
│   ├── reference/
│   └── explanation/
├── blog/             # Blog posts and release notes
└── assets/           # Images, SVG animations, etc.
```

Each section has its own content service and front matter model, configured in `Program.cs`.

## Adding Documentation

### Console or CLI Documentation

Create a `.md` file in the appropriate subdirectory (e.g., `Content/console/how-to/my-guide.md`):

```markdown
---
title: "Your Page Title"
description: "SEO-friendly description of the page"
date: 2025-01-15
tags: ["tag1", "tag2"]
section: "Console"
uid: "console-unique-id"
order: 100
---

# Your Content Here

Start writing your documentation using standard markdown...
```

**Front Matter Fields:**

- `title` (required) - Page title shown in navigation and browser
- `description` (required) - Used for SEO and metadata
- `order` (required) - Sidebar navigation order (lower = higher in list)
- `uid` - Unique identifier for cross-referencing

The file path determines the URL:
- `Content/console/how-to/example.md` → `/console/how-to/example`

### Blog Posts

Create a `.md` file in `Content/blog/`:

```markdown
---
title: "Spectre.Console 0.51.0: Amazing New Features"
author: "Your Name"
description: "Brief summary of the blog post"
date: 2025-01-15
tags: ["release", "features"]
series: "Release Notes"
isDraft: false
---

Your blog content here...
```

**Additional Blog Fields:**

- `author` - Author name
- `series` - Groups related posts together (optional)

Blog posts are automatically sorted by date (newest first) and appear at `/blog/your-file-name`.

## Linking to Code with `:symbol` fences

The site uses **Pennington.TreeSitter** to embed live code from your source files directly into documentation. This ensures code samples are always up-to-date with the actual implementation.

### Syntax

Use the special code fence `` ```csharp:symbol ``. The body is a source file path (relative to the repo root) optionally followed by `> Type.Member`:

````markdown
```csharp:symbol
Spectre.Docs.Examples/Showcase/ProgressSample.cs > ProgressSample.Run
Spectre.Docs.Examples/Showcase/ProgressSample.cs > ProgressSample.CreateTasks
```
````

### Reference format

Address code by **file path + name path** — a name path survives the line shifts that break hard-coded ranges:

| Target | Body shape | Example |
|--------|------------|---------|
| Whole file | `<path>` | `Spectre.Docs.Examples/Showcase/ProgressSample.cs` |
| A type | `<path> > Type` | `... > ProgressSample` |
| A member | `<path> > Type.Member` | `... > ProgressSample.Run` |
| Nested member | `<path> > Outer.Inner.Member` | `... > DrawCommand.Settings` |

Modifiers (comma-separated, order-independent) follow the suffix:

| Modifier | Effect |
|----------|--------|
| `,bodyonly` | Render only the member body, stripping the declaration and braces |
| `,imports` | Prepend the file's top-of-file `using` statements |
| `,signatures` | Replace member bodies with `{ … }` for an outline view |
| `symbol-diff` | Emit a unified diff between two members (exactly two references) |

**Example from progress.md:**

````markdown
```csharp:symbol,bodyonly
Spectre.Docs.Examples/Showcase/ProgressSample.cs > ProgressSample.Run
```
````

This extracts the body of the `Run` method from `ProgressSample.cs` and renders it with syntax highlighting.

### How It Works

Tree-sitter is wired in `Program.cs`, reading source files directly — no MSBuild workspace, no compilation:

```csharp
builder.Services.AddTreeSitter(treeSitter =>
{
    treeSitter.ContentRoot = ".."; // repo root, so fence paths resolve against the sibling example projects
});
```

When Pennington encounters a `csharp:symbol` fence:
1. Resolves the file path relative to `ContentRoot`
2. Uses tree-sitter to locate the named member within the file
3. Extracts the source text (applying any modifiers)
4. Renders as syntax-highlighted HTML

This approach provides:
- **Always up-to-date code** - Changes in source automatically reflect in docs
- **Rename-safe references** - A name path tolerates line shifts; broken references surface in the build report
- **No duplication** - Single source of truth for code


## Creating SVG Animated Samples

Animated samples show your library features in action using VCR tape recordings. The project supports two types of samples: **Console samples** (widget demonstrations) and **CLI samples** (command-line application tutorials).

### Prerequisites

Install VCR from [GitHub](https://github.com/phil-scott-78/vcr).

### Console Samples

Console samples demonstrate Spectre.Console widgets and features. They run with no command-line arguments and assume the project has been built.

#### Step 1: Write a Sample Class

Create a new sample in `Spectre.Docs.Examples/Showcase/`:

```csharp
public class MyFeatureSample : BaseSample
{
    public override void Run(IAnsiConsole console)
    {
        console.Write(
            new Panel("[bold yellow]Hello, Spectre![/]")
                .BorderColor(Color.Blue));

        Thread.Sleep(2000);
    }
}
```

The class name determines the sample name (`MyFeatureSample` → `my-feature`).

#### Step 2: Create a VCR Tape

Create a `.tape` file in `Spectre.Docs.Examples/VCR/`:

```
Output "Spectre.Docs/Content/assets/my-feature.svg"

Set DisableCursor true
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 82
Set Rows 12
Set EndBuffer 5s

Exec "dotnet run --project .\Spectre.Docs.Examples\ --no-build showcase my-feature"
```

**Key points:**
- Use `--no-build` because the build script compiles the project first
- The sample name in `showcase <name>` matches the kebab-case class name (minus "Sample")

### CLI Samples

CLI samples demonstrate Spectre.CLI command-line application patterns. They use an environment variable to select which demo to run from the compiled `example.exe`.

#### Step 1: Create a Demo App

Create a demo in `Spectre.Docs.Cli.Examples/DemoApps/[Tutorial]/[SubFolder]/`:

```csharp
namespace Spectre.Docs.Cli.Examples.DemoApps.MyTutorial.Complete;

public class Demo
{
    public static async Task<int> RunAsync(string[] args)
    {
        var app = new CommandApp<MyCommand>();
        return await app.RunAsync(args);
    }
}
```

#### Step 2: Create a VCR Tape

Create a `.tape` file in `Spectre.Docs.Cli.Examples/VCR/`:

```
Output "Spectre.Docs/Content/assets/cli-my-tutorial.svg"

Set Shell "pwsh"
Set FontSize 22
Set Theme "one dark"
Set TransparentBackground "true"
Set Cols 70
Set Rows 12
Set EndBuffer 5s
Set WorkingDirectory "Spectre.Docs.Cli.Examples/bin/Debug/net10.0"
Env SPECTRE_APP "M:Spectre.Docs.Cli.Examples.DemoApps.MyTutorial.Complete.Demo.RunAsync(System.String[])"

Type "./example --help"
Sleep 400ms
Enter
Sleep 2s

Type "./example Alice"
Sleep 400ms
Enter
Sleep 1s
```

**Key points:**
- `SPECTRE_APP` is set to the XmlDocId of the demo's `RunAsync` method
- Use `Type` and `Enter` commands to simulate interactive terminal input
- The working directory points to the compiled binary location

### Generate SVG Files

Run the build script from the repository root:

```powershell
.\Generate-WidgetScreenshots.ps1
```

This script:
1. Builds both `Spectre.Docs.Examples` and `Spectre.Docs.Cli.Examples`
2. Finds all `.tape` files in both VCR directories
3. Executes each tape with VCR to generate SVG files
4. Outputs SVG files to `Spectre.Docs/Content/assets/`

### Reference in Documentation

Use the <Screenshot> razor component

```html
<Screenshot Src="/assets/my-image.svg" Alt="Alt Text" />
```

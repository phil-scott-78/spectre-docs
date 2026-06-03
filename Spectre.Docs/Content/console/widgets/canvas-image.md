---
title: "CanvasImage Widget"
description: "Display image files in the console using pixel-based rendering"
uid: "console-widget-canvas-image"
order: 3900
---

The CanvasImage widget loads and displays image files in the console by converting them to colored character blocks.

> [!IMPORTANT]  
> SixLabors.ImageSharp, a library which Spectre.Console relies upon, is licensed under Apache 2.0 when distributed as
> part of Spectre.Console. The [Six Labors Split License](https://github.com/SixLabors/ImageSharp/blob/master/LICENSE) 
> covers all other usage.

<Screenshot src="/assets/canvas-image.svg" />


## When to Use

Use CanvasImage when you need to **display visual content from image files** in your console application. Common
scenarios:

- **Application branding**: Show logos or banners at startup
- **Data visualization**: Display charts, graphs, or diagrams generated as images
- **Preview functionality**: Show thumbnails or previews of image files
- **Visual feedback**: Display icons or status images during operations

For **drawing custom graphics programmatically** (shapes, lines, patterns), use [Canvas](xref:console-widget-canvas)
instead. For **ASCII art from text**, use the [FigletText](xref:console-widget-figlet) widget.

## Basic Usage

`CanvasImage` is not shipped with the default Spectre.Console package. It will need to be installed seperately.


```bash
dotnet add package Spectre.Console.ImageSharp
```

Load an image from a file path. The widget automatically handles color conversion and scaling.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.BasicCanvasImageExample
```

## Loading Images

### From File Path

The simplest approach loads an image directly from the filesystem.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.BasicCanvasImageExample
```

### From Byte Array

Use byte arrays when working with images from memory, databases, or network sources.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageFromBytesExample
```

### From Stream

Use streams for efficient processing of large images or when reading from network resources.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageFromStreamExample
```

## Sizing the Image

### Setting Maximum Width

Use `MaxWidth()` to constrain images to fit within your console layout while maintaining aspect ratio.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageMaxWidthExample
```

### Removing Width Constraints

Use `NoMaxWidth()` to remove size constraints and display the image at full resolution (limited by console dimensions).

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageNoMaxWidthExample
```

### Adjusting Pixel Width

Use `PixelWidth()` to control the character-to-pixel ratio. Lower values create taller, narrower images; higher values
create shorter, wider ones.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImagePixelWidthExample
```

## Resampling Methods

When images are scaled, different resampling algorithms affect quality and performance.

### Bicubic Resampling (Default)

Use `BicubicResampler()` for the highest quality when scaling images. This is the default and works well for most
scenarios.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageBicubicResamplerExample
```

### Bilinear Resampling

Use `BilinearResampler()` for a balance between quality and performance when rendering many images.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageBilinearResamplerExample
```

### Nearest Neighbor Resampling

Use `NearestNeighborResampler()` for the fastest scaling, which creates a pixelated effect. Good for retro aesthetics or
pixel art.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageNearestNeighborResamplerExample
```

### Comparing Resampling Methods

Compare the visual differences between resampling methods to choose the right one for your needs.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageResamplerComparisonExample
```

## Advanced Image Processing

### Basic Mutations

Use `Mutate()` to apply ImageSharp transformations like rotation, flipping, or cropping before rendering.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageMutateExample
```

### Combining Multiple Transformations

Chain multiple mutations together for complex image processing effects.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageAdvancedMutateExample
```

### Complete Configuration

Combine sizing, resampling, and mutations for complete control over image appearance.

```csharp:symbol,bodyonly
Spectre.Docs.Examples/SpectreConsole/Reference/Widgets/CanvasImage.cs > CanvasImageExamples.CanvasImageCompleteExample
```

## See Also

- <xref:console-widget-canvas> - Draw custom graphics programmatically
- <xref:console-widget-figlet> - ASCII art text banners

## API Reference

<WidgetApiReference TypeName="Spectre.Console.CanvasImage" />

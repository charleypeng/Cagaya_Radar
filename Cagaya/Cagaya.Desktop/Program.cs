using System;
using Avalonia;
using Avalonia.Controls.Platform;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;

namespace Cagaya.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        LiveChartsSkiaSharp.DefaultSKTypeface = SKFontManager.Default.MatchCharacter('汉');

        var options = new FontManagerOptions();

        if(OperatingSystem.IsLinux())
        {
            options.DefaultFamilyName = "ubuntu";
        }

        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();

    }
}
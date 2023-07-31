using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaBlazorWebView;
using Cagaya.ViewModels;
using Cagaya.Views;
using Cagaya.BlazorView;
using Toolbelt.Blazor.Extensions.DependencyInjection;
namespace Cagaya;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public override void RegisterServices()
    {
        base.RegisterServices();
        
        // Or
 
        // if you use BlazorWebView, please setting for blazor 
        AvaloniaBlazorWebViewBuilder.Initialize(default, setting =>
        {
            //this is setting for blazor 
            setting.ComponentType = typeof(BlazorView.RockStar);
            setting.Selector = "#app";

            //because avalonia support the html css and js for resource ,so you must set the ResourceAssembly 
            //setting.IsAvaloniaResource = true;
            setting.ResourceAssembly = typeof(BlazorView.RockStar).Assembly;
        }, inject =>
        {
            inject.AddSpeechSynthesis();
            //you can inject the resource in this
            //inject.AddSingleton<WeatherForecastService>();
        });
    }
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
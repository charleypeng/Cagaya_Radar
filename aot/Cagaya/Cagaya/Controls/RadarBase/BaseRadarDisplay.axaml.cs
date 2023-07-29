using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Cagaya.Controls.RadarBase.Models;

namespace Cagaya.Controls.RadarBase;

public partial class BaseRadarDisplay : UserControl
{
    public BaseRadarDisplay()
    {
        InitializeComponent();
        DataContext = new BaseRadarDisplayViewModel();
#if DEBUG
        AttachDevTools();
#endif
    }

    private void AttachDevTools()
    {
        //throw new NotImplementedException();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        btntest = this.FindControl<Button>("btntest");
    }

    private async void Btntest_OnClick(object? sender, RoutedEventArgs e)
    {
        var wid = new[] { 100, 500, 900 };
        await Task.Delay(TimeSpan.FromSeconds(1));
        foreach (var w in wid)
        {
            Canvas.SetLeft(btntest, w);
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
        
    }
}
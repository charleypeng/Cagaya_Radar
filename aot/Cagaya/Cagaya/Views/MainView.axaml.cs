using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Speech.Synthesis;
using Avalonia;

namespace Cagaya.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        this.btn.IsEnabled = false;
        var spk = new Cagaya.Synthesis.Speech();
        //await spk.Speek("福建杜康");
        this.btn.IsEnabled = true;
        this.Background = Brushes.BurlyWood;
        
        //var mapControl = new Mapsui.UI.Avalonia.V0.MapControl();
        //mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        //Content = mapControl;
    }

    private static bool changed = false;
    private void MenuItem_OnClick(object? sender, RoutedEventArgs e)
    {
        if (changed == false)
        {
            SukiUI.ColorTheme.LoadDarkTheme(Application.Current);
        }
        else
        {
            SukiUI.ColorTheme.LoadLightTheme(Application.Current);
        }
        
        changed = !changed;
    }
}
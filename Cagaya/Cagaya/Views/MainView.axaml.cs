using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Cagaya.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {

        await Task.Delay(TimeSpan.FromSeconds(2));
        this.Background = Brushes.BurlyWood;
        
        //var mapControl = new Mapsui.UI.Avalonia.V0.MapControl();
        //mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        //Content = mapControl;
    }
}
using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Speech.Synthesis;
namespace Cagaya.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {

        var spk = new Cagaya.Synthesis.Speech();
        await spk.Speek("福建杜康");
        this.Background = Brushes.BurlyWood;
        
        //var mapControl = new Mapsui.UI.Avalonia.V0.MapControl();
        //mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        //Content = mapControl;
    }
}
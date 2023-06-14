using System;
using System.Threading.Tasks;
using ReactiveUI;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Cagaya.Controls.RadarBase;

public partial class BaseRadarDisplayViewModel : ObservableObject
{
    public string? LookIntoYou { get; set; }
    public double? CWidth { get; set; } = 500;
    public double? CHeight { get; set; } = 400;

    public double? OWidth { get; set; } = 20;
    public double? OHeight { get; set; } = 20;
    public BaseRadarDisplayViewModel()
    {

        this.LookIntoYou = "fjdksjfakl福建对空射击饭卡了";
        
        this.ShowMeTheMoney();
    }

    private async void ShowMeTheMoney()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        var widths = new[] { 12, 33, 111, 21 };
        foreach (var w in widths)
        {
            this.CWidth = w;
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }
}
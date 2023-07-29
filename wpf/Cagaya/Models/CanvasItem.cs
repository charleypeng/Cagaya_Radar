using Cagaya.Controls.RadarBase.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Cagaya.Models;

public partial class CanvasItem<T> : ObservableObject
{
    [ObservableProperty]
    private double? _bottom;

    [ObservableProperty]
    
    private double? _left;

    [ObservableProperty]

    private double? _top;
    public T? Item { get; init; }

    public CanvasItem(double left, double top, double bottom, T item)
    {
        Left = left;
        Top = top;
        Bottom = bottom;
        Item = item;
    }
}

public class CanvasItem : CanvasItem<Target>
{
    public CanvasItem(double left, double top, double bottom, Target item):base( left,  top,  bottom,  item)
    {
       
    }
}
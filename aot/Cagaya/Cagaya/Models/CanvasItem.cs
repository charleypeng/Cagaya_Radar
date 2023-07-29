using Cagaya.Controls.RadarBase.Models;
using ReactiveUI;

namespace Cagaya.Models;

public class CanvasItem<T> : ReactiveObject
{
    public double? Bottom { get; set; }
    
    private double? _left;
    public double? Left
    {
        get => _left;
        set => this.RaiseAndSetIfChanged(ref _left, value);
    }

    private double? _top;
    public double? Top
    {
        get => _top;
        set => this.RaiseAndSetIfChanged(ref _top, value);
    }
    
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
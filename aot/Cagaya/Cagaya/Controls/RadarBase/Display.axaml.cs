using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Cagaya.Controls.RadarBase;

public partial class Display : UserControl
{
    public Display()
    {
        InitializeComponent();

        var myLine = new Line();
        myLine.Stroke = Brushes.Aqua;
        myLine.StartPoint = new Point(1, 50);
        myLine.EndPoint = new Point(1, 50);
        myLine.HorizontalAlignment = HorizontalAlignment.Left;
        myLine.VerticalAlignment = VerticalAlignment.Center;
        myLine.StrokeThickness = 2;
        this.myGrid.Children.Add(myLine);
    }
}
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Cagaya.Controls.RadarBase;

public partial class BaseRadarDisplay : UserControl
{
    public BaseRadarDisplay()
    {
        InitializeComponent();
        cvs = new Canvas();
        cvs.Width = 1920;
        cvs.Height = 1080;
        cvs.Background = Brushes.Aqua;
        var circle = new Ellipse
        {
            Width = 10,
            Height = 10,
            Fill = Brushes.Red,
            
        };
        cvs.Children.Add(circle);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        
    }
}
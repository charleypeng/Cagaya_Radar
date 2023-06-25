using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Cagaya.Controls.RadarBase;

public partial class RadarTarget : UserControl
{
    public RadarTarget()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
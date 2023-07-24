using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cagaya.Controls.Charts;

public partial class RacingChart : UserControl
{
    private RacingChartViewModel _vm;
    public RacingChart()
    {
        InitializeComponent();
        _vm = new RacingChartViewModel();
        this.DataContext = _vm;
        update();
    }

    private async void update()
    {
        while (true)
        {
            _vm.RandomIncrement();
            await Task.Delay(100);
        }
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        
    }
}
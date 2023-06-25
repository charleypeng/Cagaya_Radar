using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
       // this.cvs = this.FindControl<Canvas>("cvs");
        
        //var ss = DragDrop.GetAllowDrop(cvs);
    }

    public double? Lat { get; set; }
    public double? Lon { get; set; }
}
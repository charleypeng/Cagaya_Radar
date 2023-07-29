using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cagaya.Controls.RadarBase
{
    /// <summary>
    /// BaseRadarDisplay.xaml 的交互逻辑
    /// </summary>
    public partial class BaseRadarDisplay : UserControl
    {
        public BaseRadarDisplay()
        {
            InitializeComponent();
            DataContext = new BaseRadarDisplayViewModel();
        }

        private void btntest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("frejrwklw!!");
        }
    }
}

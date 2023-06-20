using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cagaya.Controls.RadarBase.Models;
using Cagaya.Models;

namespace Cagaya.Controls.RadarBase
{
    public partial class BaseRadarDisplayViewModel : ViewModels.ViewModelBase
    {
        public ObservableCollection<CanvasItem<Target>> Targets { get; set; }
        public string LookIntoYou { get; set; }
        public double CWidth { get; set; } = 500;
        public double CHeight { get; set; } = 400;

        public double OWidth { get; set; } = 10;
        public double OHeight { get; set; } = 10;
        public BaseRadarDisplayViewModel()
        {

            this.LookIntoYou = "fjdksjfakl福建对空射击饭卡了";
            initTargets();
            this.ShowMeTheMoney();
        }

        private async void initTargets()
        {
            Targets = new ObservableCollection<CanvasItem<Target>>();
            var rd1 = new Random();
            for (int i = 0; i < 6000; i++)
            {
                var target = new Target
                {
                    StrokeColor = "Red",
                    Width = 10,
                    Height = 10,
                    CallSign = General.NameGenerator.GenerateName(7)
                };

                Targets.Add(new CanvasItem(rd1.Next(20, 1900), rd1.Next(20, 1000), 0, target));
            }

            await StartNow();
        }

        private async Task StartNow()
        {
            var rd1 = new Random();
            rd1.Next(20, 50);
            var rd2 = new Random();
            if (Targets == null)
            {
                return;
            }

            while (true)
            {
                foreach (var t in Targets)
                {
                    if (t.Top > 1080)
                    {
                        t.Top = 10;
                    }

                    if (t.Left > 1920)
                    {
                        t.Left = 10;
                    }
                    var left = rd1.Next(3, 100);
                    var top = rd1.Next(20, 50);
                    t.Left += left;
                    t.Top += top;
                }

                await Task.Delay(TimeSpan.FromSeconds(0.8));
            }

        }
        private async void starter(Target target)
        {
            if (target == null)
            {
                return;
            }
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
}


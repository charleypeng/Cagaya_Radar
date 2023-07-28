using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Cagaya.Controls.RadarBase.Models;
using Cagaya.Models;
using ReactiveUI;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData;

namespace Cagaya.Controls.RadarBase;

public partial class BaseRadarDisplayViewModel : ObservableObject
{
    public ObservableCollection<CanvasItem<Target>>? Targets { get; set; }
    public string? LookIntoYou { get; set; }
    public double? CWidth { get; set; } = 500;
    public double? CHeight { get; set; } = 400;
    private event EventHandler? radarOutput;
    public double? OWidth { get; set; } = 10;
    public double? OHeight { get; set; } = 10;
    public BaseRadarDisplayViewModel()
    {

        this.LookIntoYou = "Rust me!";
        initTargets();
        this.ShowMeTheMoney();
        this.radarOutput += OnradarOutput;
    }

    private void OnradarOutput(object? sender, EventArgs e)
    {
        var _target = sender as CanvasItem<Target>;
        if (_target == null) return;
        var target = Targets?.SingleOrDefault(x => x.Item?.Id == _target.Item?.Id);
        if (target != null)
        {
            if (target?.Equals(_target) == true) return;
            var index = Targets?.IndexOf(target!);
            if (index == null) return;
            target!.Left = _target?.Left;
            target.Top = _target?.Top;
        }
    }

    private async void initTargets()
    {
        Targets = new ObservableCollection<CanvasItem<Target>>();
        var rd1 = new Random();
        for (int i = 0; i < 60; i++)
        {
            var target = new Target
            {
                StrokeColor = "Red",
                Width = 10,
                Height = 10,
                CallSign = General.NameGenerator.GenerateName(7)
            };
            
            Targets.Add(new CanvasItem(rd1.Next(20,1900),rd1.Next(20,1000),0,target));
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
                var _t = new CanvasItem(t.Left!.Value, t.Top!.Value, 0, new Target()
                {
                    StrokeColor = t.Item?.StrokeColor,
                    CallSign = t.Item?.CallSign,
                    Id = t.Item?.Id
                });
                if (_t.Top > 1080)
                {
                    _t.Top = 10;
                }

                if (_t.Left > 1920)
                {
                    _t.Left = 10;
                }
                var left = rd1.Next(3,100);
                var top = rd1.Next(20, 50);
                _t.Left += left;
                _t.Top += top;
                
                radarOutput?.Invoke(_t, null!);
                await Task.Delay(100);
            }
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
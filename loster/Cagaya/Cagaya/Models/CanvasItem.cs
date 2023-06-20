using Cagaya.Controls.RadarBase.Models;

namespace Cagaya.Models
{
    public class CanvasItem<T> : ViewModels.ViewModelBase
    {
        public double Bottom { get; set; }

        private double _left;
        public double Left
        {
            get
            {
                return _left;
            }
            set
            {
                
                this.SetProperty(ref _left, value);
            }
        }

        private double _top;
        public double Top
        {
            get
            {
                return _top;
            }
            set
            {
                
                this.SetProperty(ref _top, value);
            }
        }

        public T Item { get; set; }

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
        public CanvasItem(double left, double top, double bottom, Target item) : base(left, top, bottom, item)
        {
        }
    }
}


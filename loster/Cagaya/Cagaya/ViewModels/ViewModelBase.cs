using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cagaya.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// To raise a property changed event by the given property type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        public virtual void RaisePropertyChanged<T>(T property)
        {
            var type = typeof(T);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(type.Name));
        }

        /// <summary>
        /// To raise a property changed event by the given property name
        /// </summary>
        /// <param name="propertyName"></param>
        public virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// To raise a property changed event by the given property name
        /// </summary>
        /// <param name="propertyName"></param>
        public virtual void RaisePropertyChanging(string propertyName)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if(propertyName == null) 
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            RaisePropertyChanging(propertyName);
            backingStore = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}


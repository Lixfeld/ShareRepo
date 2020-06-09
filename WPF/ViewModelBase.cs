using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PROJECT.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(T value, ref T backingField, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(value, backingField))
            {
                backingField = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}

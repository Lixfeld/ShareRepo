using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WpfApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int selectedMonth;
        public int SelectedMonth
        {
            get => selectedMonth;
            set
            {
                selectedMonth = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<int, string> AllMonths { get; } = new Dictionary<int, string>()
        {
            { 1, "January" },
            { 2, "February" },
            { 3, "March" },
            { 4, "April" },
            { 5, "May" },
            { 6, "June" },
            { 7, "July" },
            { 8, "August" },
            { 9, "September" },
            { 10, "October" },
            { 11, "November" },
            { 12, "December" }
        };

        /* XAML
        <ComboBox ItemsSource="{Binding AllMonths, Mode=OneTime}"
                  SelectedValue="{Binding SelectedMonth, Mode=TwoWay}"
                  SelectedValuePath="Key"
                  DisplayMemberPath="Value" />
        */

        public ViewModel()
        {
            SelectedMonth = AllMonths.Keys.First();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

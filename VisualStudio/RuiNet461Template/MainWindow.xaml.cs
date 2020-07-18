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
using ReactiveUI;
using $safeprojectname$.ViewModels;

namespace $safeprojectname$
{
    public abstract class MainWindowBase : ReactiveWindow<MainWindowViewModel>
    {
        //Use abstract class instead of Xaml:
        //<reactiveui:ReactiveWindow ...
        //x:TypeArguments="MainWindowViewModel"
    }

    public partial class MainWindow : MainWindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();

            this.WhenActivated(d =>
            {

            });
        }
    }
}

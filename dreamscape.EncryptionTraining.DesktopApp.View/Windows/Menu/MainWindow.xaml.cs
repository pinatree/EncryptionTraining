using System.Windows;
using dreamscape.EncryptionTraining.DesktopApp.DefaultViewModel.Windows.Menu;
using dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.Menu;

namespace dreamscape.EncryptionTraining.DesktopApp.View
{
    public partial class MainWindow : Window
    {
        IMainWindowViewModel _dataContext;

        public MainWindow()
        {
            InitializeComponent();

            _dataContext = new MainWindowViewModel();
            this.DataContext = _dataContext;
        }
    }
}

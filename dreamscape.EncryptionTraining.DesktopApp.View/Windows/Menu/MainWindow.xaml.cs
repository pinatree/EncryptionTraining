using dreamscape.EncryptionTraining.DesktopApp.DefaultViewModel.Windows.Menu;
using dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.Menu;
using dreamscape.EncryptionTraining.DesktopApp.View.Windows.Transposition;
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

namespace dreamscape.EncryptionTraining.DesktopApp.View
{
    public partial class MainWindow : Window
    {
        IMainWindowViewModel _dataContext;

        public MainWindow()
        {
            InitializeComponent();

            Action showTransposition =
                () =>
                {
                    new TranspositionEncryption().Show();
                };

            _dataContext = new MainWindowViewModel(showTransposition);
            this.DataContext = _dataContext;
        }
    }
}

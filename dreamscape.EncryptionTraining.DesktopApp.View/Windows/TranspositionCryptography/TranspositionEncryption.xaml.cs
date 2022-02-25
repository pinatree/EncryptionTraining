using dreamscape.EncryptionTraining.DesktopApp.DefaultViewModel.Windows.TranspositionEncryption;
using dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.TranspositionEncryption;
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
using System.Windows.Shapes;

namespace dreamscape.EncryptionTraining.DesktopApp.View.Windows.Transposition
{
    /// <summary>
    /// Interaction logic for TranspositionEncryption.xaml
    /// </summary>
    public partial class TranspositionEncryption : Window
    {
        private ITranspositionEncryptionViewModel _dataContext;

        public TranspositionEncryption()
        {
            InitializeComponent();

            _dataContext = new TranspositionEncryptionViewModel();
            this.DataContext = _dataContext;
        }
    }
}

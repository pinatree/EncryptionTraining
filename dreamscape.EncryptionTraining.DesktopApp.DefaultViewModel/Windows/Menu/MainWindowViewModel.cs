using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.Menu;
using dreamscape.EncryptionTraining.DesktopApp.ViewModel.Helpers;

namespace dreamscape.EncryptionTraining.DesktopApp.DefaultViewModel.Windows.Menu
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private Action _showTranspostion;

        public MainWindowViewModel(Action showTranspostion)
        {
            this._showTranspostion = showTranspostion;
        }

        public RelayCommand GoToTranspositionEncryption
        {
            get
            {
                Action onExecute =
                    () =>
                    {
                        _showTranspostion?.Invoke();
                    };

                return new RelayCommand(onExecute);
            }
        }
    }
}

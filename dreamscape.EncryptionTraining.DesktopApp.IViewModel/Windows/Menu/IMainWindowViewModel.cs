using dreamscape.EncryptionTraining.DesktopApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.Menu
{
    public interface IMainWindowViewModel
    {
        RelayCommand GoToTranspositionEncryption { get; }
    }
}

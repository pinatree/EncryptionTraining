using dreamscape.EncryptionTraining.DesktopApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.TranspositionEncryption
{
    public interface ITranspositionEncryptionViewModel
    {
        string OriginalText { set; }

        string Key { set; }

        string ProcessedText { get; }

        RelayCommand EncryptCommand { get; }
        RelayCommand DecryptCommand { get; }
    }
}

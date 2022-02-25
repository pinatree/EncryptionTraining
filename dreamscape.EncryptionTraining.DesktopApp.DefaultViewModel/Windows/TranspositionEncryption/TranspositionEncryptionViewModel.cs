using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

using dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.TranspositionEncryption;
using dreamscape.EncryptionTraining.DesktopApp.ViewModel.Helpers;
using dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption;

namespace dreamscape.EncryptionTraining.DesktopApp.DefaultViewModel.Windows.TranspositionEncryption
{
    public class TranspositionEncryptionViewModel : ITranspositionEncryptionViewModel, INotifyPropertyChanged
    {
        private string _originalText = "";
        public string OriginalText
        {
            set
            {
                _originalText = value;
            }
            private get => _originalText;
        }

        private string _key = "";
        public string Key
        {
            set
            {
                _key = value;
            }
            private get => _key;
        }

        private string _processedText = "";
        public string ProcessedText
        {
            private set
            {
                if (_processedText != value)
                {
                    _processedText = value;
                    OnPropertyChanged();
                }
            }
            get => _processedText;
        }

        public RelayCommand EncryptCommand { get; }
        public RelayCommand DecryptCommand { get; }

        public TranspositionEncryptionViewModel()
        {
            EncryptCommand = new RelayCommand(Encrypt);
            DecryptCommand = new RelayCommand(Decrypt);
        }

        private void Encrypt()
        {
            ProcessedText = new TranspositionEncryptor().Encrypt(OriginalText, Key);
        }

        private void Decrypt()
        {
            ProcessedText = new TranspositionDecryptor().Decrypt(OriginalText, Key);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}



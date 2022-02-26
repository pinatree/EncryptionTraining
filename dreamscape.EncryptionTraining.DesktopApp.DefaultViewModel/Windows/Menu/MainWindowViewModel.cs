using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using dreamscape.EncryptionTraining.DesktopApp.ViewModel.Helpers;
using dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.Menu;
using dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Cryptographer;

namespace dreamscape.EncryptionTraining.DesktopApp.DefaultViewModel.Windows.Menu
{
    public sealed class MainWindowViewModel : IMainWindowViewModel
    {
        public ObservableCollection<EncryptionInfo> AvailableEncryptions { get; private set; }

        private EncryptionInfo _selectedEncryption = null;
        public EncryptionInfo SelectedEncryption
        {
            get => _selectedEncryption;
            private set
            {
                if(value != _selectedEncryption)
                {
                    _selectedEncryption = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public MainWindowViewModel()
        {
            AvailableEncryptions = new ObservableCollection<EncryptionInfo>()
            {
                new EncryptionInfo("1. Шифрование транспозиции",
                                    new TranspositionCryptographer(),
                                    "Шифр перестановки (транспозиции) — это метод симметричного шифрования, в котором элементы исходного открытого текста меняют местами.",
                                    SetSelectedEncryption),

                new EncryptionInfo("2. Шифр Виженера",
                                    new VigenereCryptographer(),
                                    "",
                                    SetSelectedEncryption),
            };

            EncryptCommand = new RelayCommand(Encrypt);
            DecryptCommand = new RelayCommand(Decrypt);
        }

        private void Encrypt()
        {
            ProcessedText = SelectedEncryption.Cryptographer.Encryptor.Encrypt(OriginalText, Key);
        }

        private void Decrypt()
        {
            ProcessedText = SelectedEncryption.Cryptographer.Decryptor.Decrypt(OriginalText, Key);
        }

        private void SetSelectedEncryption(EncryptionInfo sender)
        {
            //Check if OLD selector is the same selector
            if (SelectedEncryption == sender)
                return;

            //Set selection status for OLD selection
            if (SelectedEncryption != null)
                SelectedEncryption.IsSelected = false;

            //Set current selector
            SelectedEncryption = sender;

            //Set selection status for NEW selection
            SelectedEncryption.IsSelected = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }


    
}

using dreamscape.EncryptionTraining.DesktopApp.ViewModel.Helpers;
using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.DesktopApp.IViewModel.Windows.Menu
{
    public interface IMainWindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<EncryptionInfo> AvailableEncryptions { get; }

        EncryptionInfo SelectedEncryption { get; }

        string OriginalText { set; }

        string Key { set; }

        string ProcessedText { get; }

        RelayCommand EncryptCommand { get; }
        RelayCommand DecryptCommand { get; }
    }

    public sealed class EncryptionInfo : INotifyPropertyChanged
    {
        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _additionalInfo;
        public string AdditionalInfo
        {
            get => _additionalInfo;
            set
            {
                if (_additionalInfo != value)
                {
                    _additionalInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        //Not bindable
        public ICryptographer Cryptographer { get; private set; }

        public RelayCommand OpenCommand { get; }

        public EncryptionInfo(string name, ICryptographer cryptographer, string additionalInfo = "", Action<EncryptionInfo> onOpen = null)
        {
            this.Name = name;
            this.AdditionalInfo = additionalInfo;
            this.Cryptographer = cryptographer;

            if (onOpen != null)
                OpenCommand = new RelayCommand(() => { onOpen.Invoke(this); });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

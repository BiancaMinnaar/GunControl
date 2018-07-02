using System.ComponentModel;

namespace GunControl.Trunk.ViewModel.Data
{
    public class UserMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _UserName;
        public string UserName 
        { 
            get { return _UserName; } 
            set
            {
                _UserName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
            }
        }
    }
}

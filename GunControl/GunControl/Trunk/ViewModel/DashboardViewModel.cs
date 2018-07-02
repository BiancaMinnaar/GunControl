using System.ComponentModel;
using GunControl.Root.ViewModel;
using GunControl.Trunk.ViewModel.Data;

namespace GunControl.Implementation.ViewModel
{
    public class DashboardViewModel : ProjectBaseViewModel, INotifyPropertyChanged
    {
		public new event PropertyChangedEventHandler PropertyChanged;

        UserMode _User;
        public UserMode User 
        { 
            get { return _User; } 
            set 
            { 
                _User = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User"));
            } 
        }
    }
}
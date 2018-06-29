using GunControl.Implementation.ViewModel;
using GunControl.Trunk.ViewModel.Data;
using Xamarin.Forms;

namespace GunControl.Interface.Repository
{
    public interface IMasterRepository
    {
        UserMode User { get; }

        void SetRootView(Page rootView);
        Page GetRootView();
        void PushLogOut();
        void PopView();
        void PopModal();
        void ShowLoading();
        void HideLoading();
        void DumpJson<T>(string heading, T objectToDump);
        void PushHomeView();

        void SetUserModel(LoginViewModel model);
    }
}


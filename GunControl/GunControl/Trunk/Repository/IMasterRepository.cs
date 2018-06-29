using Xamarin.Forms;

namespace GunControl.Interface.Repository
{
    public interface IMasterRepository
    {
        void SetRootView(Page rootView);
        Page GetRootView();
        void PushLogOut();
        void PopView();
        void PopModal();
        void ShowLoading();
        void HideLoading();
        void DumpJson<T>(string heading, T objectToDump);
        void PushHomeView();
    }
}


using System;
using System.Collections.Generic;
using GunControl.Implementation.ViewModel;
using GunControl.Root.ViewModel;
using GunControl.Trunk.Injection.Base;
using GunControl.Trunk.ViewModel.Data;
using Xamarin.Forms;

namespace GunControl.Interface.Repository
{
    public interface IMasterRepository
    {
        UserMode User { get; }
        MasterModel DataSource { get; set; }
        void SetRootView(Page rootView);
        Page GetRootView();
        void PushLogOut();
        void PopView();
        void PopModal();
        void ShowLoading();
        void HideLoading();
        void DumpJson<T>(string heading, T objectToDump);
        void ReportToAllListeners(string serviceKey, IPlatformModelBase model);
        void PushHomeView();
        void SetUserModel(LoginViewModel model);
        Action<string[]> OnError { get; set; }
        List<Action<string, IPlatformModelBase>> OnPlatformServiceCallBack { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CorePCL;
using GunControl.Implementation.View;
using GunControl.Implementation.ViewModel;
using GunControl.Interface.Repository;
using GunControl.Root.Repository;
using GunControl.Root.ViewModel;
using GunControl.Trunk.Injection.Base;
using GunControl.Trunk.ViewModel.Data;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GunControl.Trunk.Repository.Implementation
{
    public class MasterRepository : ProjectBaseRepository, IMasterRepository
    {
        private static MasterRepository _Reposetory = new MasterRepository();
        private static readonly object syncronisationLock = new object();
        public MasterModel DataSource { get; set; }
        private INavigation _Navigation;
        private Page _RootView;
        public Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> NetworkInterface { get; set; }
        public Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> NetworkInterfaceWithTypedParameters { get; set; }
        public List<Action<string, IPlatformModelBase>> OnPlatformServiceCallBack { get; set; }

        MasterRepository()
            : base(null)
        {
            DataSource = new MasterModel();
            OnPlatformServiceCallBack =
                new List<Action<string, IPlatformModelBase>>();
        }

        public static MasterRepository MasterRepo
        {
            get { return _Reposetory; }
        }

        public UserMode User => DataSource.User;


        public void SetRootView(Page rootView)
        {
            _RootView = rootView;
            _Navigation = rootView.Navigation;
            
        }

        public Page GetRootView()
        {
            return _RootView;
        }

        public void PushLogOut()
        {
            DataSource.Authenticated = false;
            _Navigation.PopToRootAsync();
        }

        public void PopView()
        {
            _Navigation.PopAsync();
        }

        public void PopModal()
        {
            _Navigation.PopModalAsync();
        }

        public void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading();
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public void DumpJson<T>(string heading, T objectToDump)
        {
            Debug.WriteLine(heading);
            Debug.WriteLine(JsonConvert.SerializeObject(objectToDump));
        }
        public void ReportToAllListeners(string serviceKey, IPlatformModelBase model)
        {
            foreach (var listener in OnPlatformServiceCallBack)
            {
                listener?.Invoke(serviceKey, model);
            }
        }

        public void SetUserModel(LoginViewModel model)
        {
            DataSource.User = new UserMode { UserName = model.UserName };
        }

        public void PushHomeView()
        {
           _Navigation.PushAsync(new DashboardView());
        }
    }
}


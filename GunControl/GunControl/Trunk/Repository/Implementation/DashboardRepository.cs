using System;
using System.Threading.Tasks;
using CorePCL;
using GunControl.Implementation.ViewModel;
using GunControl.Interface.Repository;
using GunControl.Interface.Service;
using GunControl.Root.Repository;
using GunControl.Trunk.Injection.Base;
using GunControl.Trunk.Repository.Implementation;
using Xamarin.Forms;

namespace GunControl.Implementation.Repository
{
    public class DashboardRepository<T> : ProjectBaseRepository, IDashboardRepository<T>
        where T : BaseViewModel
    {
        IDashboardService<T> _Service;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public DashboardRepository(IMasterRepository masterRepository, IDashboardService<T> service)
            : base(masterRepository)
        {
            _Service = service;
            _PlatformBonsai = DependencyService.Get<IPlatformBonsai<IPlatformModelBonsai>>();
            var platform = new PlatformRepository<DashboardViewModel>(masterRepository);
            platform.OnError = (errs) =>
            {
                OnError?.Invoke(errs);
            };
        }

        public void OnFingerPrintRead()
        {
            foreach(var service in _PlatformBonsai.GetBonsaiServices)
            {
                if (service.PlatformHarness.ServiceKey == "FingerPrintService")
                    service.PlatformHarness.Activate();
            }
        }

        public void OnNFCRead()
        {
            foreach (var service in _PlatformBonsai.GetBonsaiServices)
            {
                if (service.PlatformHarness.ServiceKey == "NFCService")
                    service.PlatformHarness.Activate();
            }
        }

        public async Task Refresh(DashboardViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Refresh(model);
            completeAction(serviceReturnModel);
        }
    }
}
using GunControl.Interface.Repository;
using GunControl.Root.Repository;
using GunControl.Trunk.Injection.Base;
using CorePCL;
using Xamarin.Forms;

namespace GunControl.Trunk.Repository.Implementation
{
    public class PlatformRepository<T> : ProjectBaseRepository, IPlatformRepository<T>
        where T : BaseViewModel
    {
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public PlatformRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
            _PlatformBonsai = DependencyService.Get<IPlatformBonsai<IPlatformModelBonsai>>();
            //??
            _PlatformBonsai.OnError = (obj) =>
            {
                OnError(obj);
            };
            AddCallBackToAllPlatformServices();
        }

        void AddCallBackToAllPlatformServices()
        {
            foreach (var platformService in _PlatformBonsai.GetBonsaiServices)
            {
                platformService.PlatformHarness.ServiceCallBack = (platformModel) =>
                {
                    SetPlatformModelAndReportToAllListeners(platformService, platformModel);

                };
                platformService.PlatformHarness.OnError = (errorList) =>
                {
                    Errors = errorList;
                    OnError?.Invoke(errorList);
                };
                //Only activate on demand
                //platformService.PlatformHarness.Activate();
            }
        }

        void SetPlatformModelAndReportToAllListeners(BonsaiPlatformServiceRegistrationStruct platformService, IPlatformModelBase platformModel)
        {
            _MasterRepo.DataSource.PlatformModel = platformModel;
            _MasterRepo.ReportToAllListeners(platformService.PlatformHarness.ServiceKey, platformModel);
        }
    }
}

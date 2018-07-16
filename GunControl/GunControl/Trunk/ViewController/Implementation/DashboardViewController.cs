using System.Threading.Tasks;
using GunControl.Implementation.Repository;
using GunControl.Implementation.Service;
using GunControl.Implementation.ViewModel;
using GunControl.Interface.Repository;
using GunControl.Interface.Service;
using GunControl.Interface.ViewController;
using GunControl.Root.ViewController;

namespace GunControl.Implementation.ViewController
{
    public class DashboardViewController : ProjectBaseViewController<DashboardViewModel>, IDashboardViewController
    {
        IDashboardRepository<DashboardViewModel> _Repository;
        IDashboardService<DashboardViewModel> _Service;

        public DashboardViewController()
        {
            //InputObject.User = _MasterRepo.User;
        }

        public override void SetRepositories()
        {
            _Service = new DashboardService<DashboardViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DashboardViewModel>(U, P, C, A));
            _Repository = new DashboardRepository<DashboardViewModel>(_MasterRepo, _Service);
            _Repository.OnError = (errs) =>
            {
                for (var count = 0; count < errs.Length; count++)
                {
                    if (errs[count] != "")
                        ShowError(errs[count]);
                }
            };
        }

        public async Task Refresh()
        {
            InputObject.User = _MasterRepo.User;
        }

        public void PresentFingerPrintScan()
        {
            _Repository.OnFingerPrintRead();
        }

        public void ScanNFCTag()
        {
            throw new System.NotImplementedException();
        }
    }
}
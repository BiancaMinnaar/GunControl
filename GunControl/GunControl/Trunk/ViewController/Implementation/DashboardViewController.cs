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
        IDashboardRepository<DashboardViewModel> _Reposetory;
        IDashboardService<DashboardViewModel> _Service;

        public DashboardViewController()
        {
            InputObject.User = _MasterRepo.User;
        }

        public override void SetRepositories()
        {
            _Service = new DashboardService<DashboardViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DashboardViewModel>(U, P, C, A));
            _Reposetory = new DashboardRepository<DashboardViewModel>(_MasterRepo, _Service);
        }

        public async Task Refresh()
        {
        }
    }
}
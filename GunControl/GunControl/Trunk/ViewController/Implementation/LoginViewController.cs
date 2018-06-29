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
    public class LoginViewController : ProjectBaseViewController<LoginViewModel>, ILoginViewController
    {
        ILoginRepository<LoginViewModel> _Reposetory;
        ILoginService<LoginViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new LoginService<LoginViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<LoginViewModel>(U, P, C, A));
            _Reposetory = new LoginRepository<LoginViewModel>(_MasterRepo, _Service);
        }

        public async Task Login()
        {
            await _Reposetory.Login(InputObject, (model) => 
            {
                _MasterRepo.SetUserModel(model);
            });
        }
    }
}
using System;
using System.Threading.Tasks;
using CorePCL;
using GunControl.Implementation.ViewModel;
using GunControl.Interface.Repository;
using GunControl.Interface.Service;
using GunControl.Root.Repository;

namespace GunControl.Implementation.Repository
{
    public class LoginRepository<T> : ProjectBaseRepository, ILoginRepository<T>
        where T : BaseViewModel
    {
        ILoginService<T> _Service;

        public LoginRepository(IMasterRepository masterRepository, ILoginService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Login(LoginViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Login(model);
            completeAction(serviceReturnModel);
        }
    }
}
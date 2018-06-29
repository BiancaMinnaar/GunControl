using System;
using System.Threading.Tasks;
using CorePCL;
using GunControl.Implementation.ViewModel;

namespace GunControl.Interface.Repository
{
    public interface ILoginRepository<T>
        where T : BaseViewModel
    {
        Task Login(LoginViewModel model, Action<T> completeAction);
    }
}

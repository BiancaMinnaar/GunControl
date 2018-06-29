using System.Threading.Tasks;
using CorePCL;
using GunControl.Implementation.ViewModel;

namespace GunControl.Interface.Service
{
    public interface ILoginService<T>
        where T : BaseViewModel
    {
        Task<T> Login(LoginViewModel model);
    }
}


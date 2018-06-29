using System.Threading.Tasks;
using CorePCL;
using GunControl.Implementation.ViewModel;

namespace GunControl.Interface.Service
{
    public interface IDashboardService<T>
        where T : BaseViewModel
    {
        Task<T> Refresh(DashboardViewModel model);
    }
}


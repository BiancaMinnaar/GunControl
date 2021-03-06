using System;
using System.Threading.Tasks;
using CorePCL;
using GunControl.Implementation.ViewModel;

namespace GunControl.Interface.Repository
{
    public interface IDashboardRepository<T>
        where T : BaseViewModel
    {
        Action<string[]> OnError { get; set; }
        Task Refresh(DashboardViewModel model, Action<T> completeAction);
        void OnFingerPrintRead();
        void OnNFCRead();
    }
}

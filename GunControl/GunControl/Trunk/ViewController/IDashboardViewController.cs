using System.Threading.Tasks;

namespace GunControl.Interface.ViewController
{
    public interface IDashboardViewController
    {
        Task Refresh();
        void PresentFingerPrintScan();
        void ScanNFCTag();
    }
}

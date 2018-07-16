using GunControl.Trunk.Injection.Base;

namespace GunControl.Trunk.Injection.FingerPrint
{
    public interface IFingerPrint : IPlatformModelBase
    {
        bool IsValid { get; set; }
    }
}

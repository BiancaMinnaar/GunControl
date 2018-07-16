using GunControl.Trunk.Injection.Base;

namespace GunControl.Trunk.Injection.NFC
{
    public interface INFCService<T> : IPlatformService<T> where T : IPlatformModelBase
    {
    }
}

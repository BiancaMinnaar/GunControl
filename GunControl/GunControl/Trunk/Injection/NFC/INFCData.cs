using GunControl.Trunk.Injection.Base;

namespace GunControl.Trunk.Injection.NFC
{
    public interface INFCData : IPlatformModelBase
    {
        string TagData { get; set; }
    }
}

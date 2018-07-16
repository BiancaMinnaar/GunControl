using GunControl.Trunk.Injection.NFC;

namespace GunControl.Droid.Injection.NFC
{
    public class NFCData : INFCData
    {
        public string ErrorMessage { get; }
        public string TagData { get; set; }
    }
}

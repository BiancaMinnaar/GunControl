using GunControl.Trunk.Injection.FingerPrint;

namespace GunControl.Droid.Injection.FingerPrintScanner
{
    public class FingerPrint : IFingerPrint
    {
        public string ErrorMessage { get; }
        public bool IsValid { get; set; }
    }
}

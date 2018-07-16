using System.Threading.Tasks;
using GunControl.Droid.Injection.FingerPrintScanner;
using GunControl.Trunk.Injection.Base;
using Plugin.Fingerprint;
using Xamarin.Forms;

[assembly: Dependency(typeof(FingerPrintService))]
namespace GunControl.Droid.Injection.FingerPrintScanner
{
    public class FingerPrintService : PlatformServiceBonsai<IPlatformModelBase>
    {
        public override string ServiceKey => "FingerPrintService";

        public override void Activate()
        {
            base.Activate();
            Task.Run(async () => await method());
        }

        async Task method()
        {
            var result = await CrossFingerprint.Current.AuthenticateAsync("Prove you have fingers!");
            if (result.Authenticated)
            {
                ExecuteCallBack(new FingerPrint{IsValid=true});
            }
            else
            {
                OnError(new string[] { ServiceKey + " Reported " + result.Status.ToString(), result.ErrorMessage });
            }
        }
    }
}

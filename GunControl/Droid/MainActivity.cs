using Android.App;
using Android.Content;
using Android.OS;
using Acr.UserDialogs;
using Android.Nfc;
using Poz1.NFCForms.Droid;
using Poz1.NFCForms.Abstract;
using GunControl.Droid.Injection.Base;
using GunControl.Trunk.Injection.Base;
using GunControl.Droid.Injection.FingerPrintScanner;
using GunControl.Droid.Injection.NFC;

namespace GunControl.Droid
{
    [Activity(Theme = "@style/MyTheme", Label = "MyApp", MainLauncher = true)]
    [IntentFilter(new[] { NfcAdapter.ActionTechDiscovered })]
    [MetaData(NfcAdapter.ActionTechDiscovered, Resource = "@xml/nfc")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public NfcAdapter NFCdevice;
        public NfcForms x;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            NfcManager NfcManager = (NfcManager)Android.App.Application.Context.GetSystemService(Context.NfcService);
            NFCdevice = NfcManager.DefaultAdapter;

            Xamarin.Forms.DependencyService.Register<INfcForms, NfcForms>();
            PlatformSingleton.Instance.PlatformServiceList.Add
                             <FingerPrintService>(null);
            PlatformSingleton.Instance.PlatformServiceList.Add
                             <NFCService>(NfcManager);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            x = Xamarin.Forms.DependencyService.Get<INfcForms>() as NfcForms;
            UserDialogs.Init(this);
            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (NFCdevice != null)
            {
                var intent = new Intent(this, GetType()).AddFlags(ActivityFlags.SingleTop);
                NFCdevice.EnableForegroundDispatch
                (
                    this,
                    PendingIntent.GetActivity(this, 0, intent, 0),
                    new[] { new IntentFilter(NfcAdapter.ActionTechDiscovered) },
                    new string[][] {new string[] {
                            NFCTechs.Ndef,
                        },
                        new string[] {
                            NFCTechs.MifareClassic,
                        },
                    }
                );
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            NFCdevice.DisableForegroundDispatch(this);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            x.OnNewIntent(this, intent);
        }

        protected override void OnStart()
        {
            base.OnStart();
            PlatformBonsai.NotifyOfBackgroundChange(
                new PlatformModelBonsai { IsBackgroundAvailable = true });
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}


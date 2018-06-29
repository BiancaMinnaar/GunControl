using Android.App;
using Android.Content;
using Android.OS;
using Acr.UserDialogs;

namespace GunControl.Droid
{
    [Activity(Theme = "@style/MyTheme", Label = "MyApp", MainLauncher = true)]  
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //global::Xamarin.Forms.Forms.Init(this, bundle);
            //UserDialogs.Init(this);
            //LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}


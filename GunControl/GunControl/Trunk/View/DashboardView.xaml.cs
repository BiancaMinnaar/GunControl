using System;
using GunControl.Implementation.ViewController;
using GunControl.Implementation.ViewModel;
using GunControl.Root.View;
using Xamarin.Forms;

namespace GunControl.Implementation.View
{
    public partial class DashboardView : ProjectBaseContentPage<DashboardViewController, DashboardViewModel>
    {
        public DashboardView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewController.Refresh();
        }

        public async void On_Refresh_Event(object sender, EventArgs e)
        {
            await _ViewController.Refresh();
        }

        void Handle_FingerPrintClicked(object sender, System.EventArgs e)
        {
            _ViewController.PresentFingerPrintScan();
        }
    }
}



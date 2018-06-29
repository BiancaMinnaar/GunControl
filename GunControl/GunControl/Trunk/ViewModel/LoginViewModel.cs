using System;
using GunControl.Root.ViewModel;

namespace GunControl.Implementation.ViewModel
{
    public class LoginViewModel : ProjectBaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
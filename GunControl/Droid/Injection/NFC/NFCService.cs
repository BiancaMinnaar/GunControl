﻿using GunControl.Trunk.Injection.Base;
using GunControl.Trunk.Injection.NFC;
using Poz1.NFCForms.Abstract;
using Xamarin.Forms;

namespace GunControl.Droid.Injection.NFC
{
    public class NFCService : PlatformServiceBonsai<IPlatformModelBase>, INFCService<IPlatformModelBase>
    {
        public override string ServiceKey => "NFCService";
        public override void Activate()
        {
            base.Activate();
            INfcForms device = DependencyService.Get<INfcForms>();
            device.NewTag += HandleNewTag;
        }

        private void HandleNewTag(object sender, NfcFormsTag e)
        {
            var message = e.NdefMessage;
            ExecuteCallBack(new NFCData { TagData = message.ToString()});
        }
    }
}

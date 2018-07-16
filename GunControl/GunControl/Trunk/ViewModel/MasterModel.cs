using System.Collections.Generic;
using GunControl.Trunk.Injection.Base;
using GunControl.Trunk.ViewModel.Data;

namespace GunControl.Root.ViewModel
{
    public sealed class MasterModel
    {
        public bool Authenticated { get; set; }
        public UserMode User {get;set;}
        public IPlatformModelBase PlatformModel { get; set; }
        public IEnumerable<PlatformServiceBonsai<IPlatformModelBase>> PlatformServiceList { get; }
    }
}


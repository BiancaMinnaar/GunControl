using GunControl.Trunk.ViewModel.Data;

namespace GunControl.Root.ViewModel
{
    public sealed class MasterModel
    {
        public bool Authenticated { get; set; }
        public UserMode User {get;set;}
    }
}


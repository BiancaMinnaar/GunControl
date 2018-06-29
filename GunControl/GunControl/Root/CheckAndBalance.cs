using System;

namespace GunControl.Root
{
    public class CheckAndBalance
    {
        public Func<bool> Check { get; set; }
        public string Balance { get; set; }
    }
}


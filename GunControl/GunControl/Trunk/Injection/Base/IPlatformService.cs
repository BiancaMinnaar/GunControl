using System;

namespace GunControl.Trunk.Injection.Base
{
    public interface IPlatformService<T>
    {
        Action<T> ServiceCallBack { set; }
        Action<string[]> OnError { get; set; }
    }
}

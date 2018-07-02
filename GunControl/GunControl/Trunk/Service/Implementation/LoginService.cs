using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using GunControl.Implementation.ViewModel;
using GunControl.Interface.Service;

namespace GunControl.Implementation.Service
{
        public class LoginService<T> : BaseService<T>, ILoginService<T>
            where T : BaseViewModel
        {
        public LoginService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> networkInterface)
                :base(networkInterface)
            {
            }

        public async Task Login(LoginViewModel model)
        {
			string requestURL = "/login";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"username", new ParameterTypedValue(model.UserName)},
                {"password", new ParameterTypedValue(model.Password)}
            };
            await _NetworkInterface(requestURL, parameters, null, httpMethod);
        }
    }
}

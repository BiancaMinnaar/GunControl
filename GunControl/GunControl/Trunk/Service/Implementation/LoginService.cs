using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using GunControl.Implementation.ViewModel;
using GunControl.Interface.Service;

namespace GunControl.Implementation.Service
{
        public class LoginService<T> : BaseService, ILoginService<T>
            where T : BaseViewModel
        {
            public LoginService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
                :base(networkInterface)
            {
            }

        public async Task Login(LoginViewModel model)
        {
			//string requestURL = "/login";
            string requestURL = "/get";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                //{"username", new ParameterTypedValue(model.UserName)},
                //{"password", new ParameterTypedValue(model.Password)}
            };
            await _NetworkInterfaceWithTypedParameters(requestURL, parameters, httpMethod);
        }
    }
}

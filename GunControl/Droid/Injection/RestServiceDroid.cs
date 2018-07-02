using CorePCL;
using RestSharp;
using Xamarin.Forms;
using System.Threading.Tasks;
using BasePCL.Networking;
using System.Net;
using GunControl.Droid.Injection;
using GunControl.Root;
using System;
using System.Collections.Generic;

[assembly: Dependency(typeof(RestServiceDroid))]
namespace GunControl.Droid.Injection
{
    public class RestRqst : RestRequest, INetworkRequest
    {
        public RestRqst(string urlExtention, Method httpMethodType)
            : base(urlExtention, httpMethodType)
        {
        }

        public static Method GetHttpMethod(BaseNetworkAccessEnum httpMethodType)
        {
            switch (httpMethodType)
            {
                default:
                    return Method.GET;
                case BaseNetworkAccessEnum.Post:
                    return Method.POST;
                case BaseNetworkAccessEnum.Put:
                    return Method.PUT;
            }
        }

        public void AddFile(string name, byte[] value, string fileName)
        {
            base.AddFile(name, value, fileName);
        }

        public new void AddHeader(string name, string value)
        {
            base.AddHeader(name, value);
        }

        public void AddJsonBody(BaseViewModel body)
        {
            base.AddJsonBody(body);
        }

        void INetworkRequest.AddParameter(string name, object value)
        {
            base.AddParameter(name, value);
        }
    }

    public class RestRspns : INetworkResponse
    {
        IRestResponse _RestResponse;
        public HttpStatusCode StatusCode
        {
            get;set;
        }
        public string StatusDescription
        {
            get; set;
        }
        public string Content
        {
            get; set;
        }
        public byte[] RawBytes
        {
            get; set;
        }
        public RestRspns(){}

        public RestRspns(IRestResponse response)
        {
            _RestResponse = response;
            StatusCode = response.StatusCode;
            StatusDescription = response.StatusDescription;
            Content = response.Content;
            RawBytes = response.RawBytes;
        }
    }

    public class RestRspns<T> : RestRspns, INetworkResponse<T> where T : BaseViewModel
    {
        IRestResponse<T> _RestResponse;

        public RestRspns(IRestResponse response)
            : base(response)
        {
        }

        public RestRspns(IRestResponse<T> response)
            : base(response)
        {
            _RestResponse = response;
        }

        public T Data { get => _RestResponse.Data; set => _RestResponse.Data = value; }
    }

    public class RestServiceDroid : INetworkInteraction
    {
        public INetworkRequest GetNetworkRequest(string urlExtention, BaseNetworkAccessEnum httpMethodType)
        {
            return new RestRqst(urlExtention, RestRqst.GetHttpMethod(httpMethodType));
        }

        public INetworkRequest GetNetworkRequestForJson(string urlExtention, BaseNetworkAccessEnum httpMethodType)
        {
            return new RestRqst(urlExtention, RestRqst.GetHttpMethod(httpMethodType));
        }

        public async Task<INetworkResponse> ExecuteTaskAsync(INetworkRequest req)
        {
            var client = new RestClient(Constants.BASE_URL);
            INetworkResponse response;
            try
            {
                response = new RestRspns(await client.ExecuteTaskAsync((IRestRequest)req));
            }
            catch (Exception)
            {
                var resp = new RestRspns
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Content = "",
                    RawBytes = new byte[0],
                    StatusDescription = "The network URL " + Constants.BASE_URL + " is unreachable."
                };
                response = (INetworkResponse)resp;
            }
            return response;
        }

        public async Task<INetworkResponse<T>> ExecuteTaskAsync<T>(INetworkRequest req) where T : BaseViewModel
        {
            var client = new RestClient(Constants.BASE_URL);
            INetworkResponse<T> response;
            try
            {
                throw new Exception("");
                response = new RestRspns<T>(await client.ExecuteTaskAsync<T>((IRestRequest)req));
            }
            catch (Exception excp)
            {
                var resp = new RestRspns
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Content = "",
                    RawBytes = new byte[0],
                    StatusDescription="There was a terrible mistake"
                };
                response = new RestRspns<T>(response: (RestSharp.IRestResponse)resp);
            }
            return response;
        }
    }
}


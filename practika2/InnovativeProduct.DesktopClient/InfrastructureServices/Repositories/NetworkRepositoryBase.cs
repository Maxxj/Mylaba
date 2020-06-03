using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InnovativeProduct.InfrastructureServices.Repositories 
{
    public class NetworkRepositoryBase
    {
        private string _host;
        private ushort _port;
        private bool _useTls;

        protected NetworkRepositoryBase(string host, ushort port, bool useTls)
        {
            _host = host;
            _port = port;
            _useTls = useTls;
        }

        protected async Task<T> ExecuteHttpRequest<T>(string path)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri($"{ConvertToProtocol(_useTls)}://{_host}:{_port}");
                    var jsonString = await httpClient.GetStringAsync(path);
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        private string ConvertToProtocol(bool useTls)
            => useTls ? "https" : "http";
    }
}

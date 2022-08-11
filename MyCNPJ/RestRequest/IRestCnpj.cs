using RestSharp;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MyCNPJ.RestRequest
{
    public interface IRestCnpj
    {
        public Task<RestResponse> ExecuteRequestAsync(string baseUrl, [Optional] string resource, Method method, [Optional] object body);
    }
}

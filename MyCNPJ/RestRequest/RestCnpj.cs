using RestSharp;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MyCNPJ.RestRequest
{
    public class RestCnpj : IRestCnpj
    {
        /// <summary>
        /// Executa requests públicas
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<RestResponse> ExecuteRequestAsync(string baseUrl, [Optional] string resource, Method method, [Optional] object body)
        {
            var client = new RestClient(baseUrl);
            var request = new RestSharp.RestRequest(resource ?? "", method);
            request.AddHeader("Content-Type", "application/json");

            if (body != null)
                request.AddBody(body);

            return await client.ExecuteAsync(request);
        }
    }
}

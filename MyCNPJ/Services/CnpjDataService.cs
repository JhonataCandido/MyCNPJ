using MyCNPJ.Models;
using MyCNPJ.RestRequest;
using MyCNPJ.Utils;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyCNPJ.Services
{
    sealed class CnpjDataService : ICnpjDataService
    {
        private readonly IRestCnpj _restCnpj;
        public CnpjDataService(IRestCnpj restCnpj) => _restCnpj = restCnpj;

        /// <summary>
        /// Busca todas as informações do CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public async Task<CnpjDataViewModel> GetCnpjAsync(string cnpj)
        {
            var cnpjDataModel = new CnpjDataViewModel();

            if (!string.IsNullOrEmpty(cnpj) && cnpj.ParseCnpj().Length == 14)
            {
                var response = await _restCnpj.ExecuteRequestAsync("https://receitaws.com.br/v1/cnpj/", cnpj.ParseCnpj(), RestSharp.Method.Get);

                if (response.IsSuccessful)
                {
                    if (!string.IsNullOrEmpty(response.Content))
                        cnpjDataModel = JsonConvert.DeserializeObject<CnpjDataViewModel>(response.Content);

                    else
                        cnpjDataModel.Message = "Falha ao executar a request! Retorno vazio!";
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                        cnpjDataModel.Message = "Várias solicitações seguidas, favor aguardar alguns segundos!";
                    
                    else
                        cnpjDataModel.Message = $"Falha ao executar a request: {response.ErrorMessage}";
                }
            }
            else
                cnpjDataModel.Message = "CNPJ inválido favor verifique!";

            return cnpjDataModel;
        }
    }
}

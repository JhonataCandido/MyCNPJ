using MyCNPJ.Models;
using System.Threading.Tasks;

namespace MyCNPJ.Services
{
    public interface ICnpjDataService
    {
        public Task<CnpjDataViewModel> GetCnpjAsync(string cnpj);
    }
}

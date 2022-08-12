using MyCNPJ.Entities;
using System.Threading.Tasks;
using X.PagedList;

namespace MyCNPJ.Repositories
{
    public interface ICnpjDataRepository
    {
        public Task<IPagedList<CnpjData>> List(int page);
        public Task<CnpjData> GetCnpjDataDetailsAsync(string cnpj);
        public Task Add(CnpjData cnpjData);
        public Task<bool> Exist(string cnpj);
    }
}

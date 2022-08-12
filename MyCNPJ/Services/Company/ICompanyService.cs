using MyCNPJ.Entities;
using MyCNPJ.Models;
using System.Threading.Tasks;
using X.PagedList;

namespace MyCNPJ.Services.Company
{
    public interface ICompanyService
    {
        public Task<IPagedList<CnpjData>> List(int page); 
        public Task<CompanyDetailsViewModel> GetCnpjDetails(string cnpj);
        public Task Add(CnpjData cnpjData);
        public Task<bool> Exist(string cnpj);
    }
}

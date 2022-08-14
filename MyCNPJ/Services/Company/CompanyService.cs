using MyCNPJ.Entities;
using MyCNPJ.Models;
using MyCNPJ.Repositories;
using System.Threading.Tasks;
using X.PagedList;

namespace MyCNPJ.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly ICnpjDataRepository _cnpjDataRepository;
        public CompanyService(ICnpjDataRepository cnpjDataRepository)
        {
            _cnpjDataRepository = cnpjDataRepository;
        }

        public async Task<IPagedList<CnpjData>> List(int page) => await _cnpjDataRepository.List(page);

        public async Task<CompanyDetailsViewModel> GetCompanyDetails(string cnpj) => new CompanyDetailsViewModel(await _cnpjDataRepository.GetCompanyDetailsAsync(cnpj));

        public async Task Add(CnpjData cnpjData) => await _cnpjDataRepository.Add(cnpjData);

        public async Task<bool> Exist(string cnpj) => await _cnpjDataRepository.Exist(cnpj);
    }
}

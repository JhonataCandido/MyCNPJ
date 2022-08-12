using Microsoft.EntityFrameworkCore;
using MyCNPJ.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyCNPJ.Repositories
{
    public class CnpjDataRepository : ICnpjDataRepository
    {
        private readonly DataContext.DataContext _dataContext;

        public CnpjDataRepository(DataContext.DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Busca todas as empresas cadastradas
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<CnpjData>> List(int page)
        {
            return await Task.FromResult(_dataContext.CnpjData
                 .OrderBy(a => a.Fantasia)
                 .ToPagedList(page, 8));
        }

        /// <summary>
        /// Busca somente uma empresa no banco
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public async Task<CnpjData> GetCnpjDataDetailsAsync(string cnpj)
        {
            return await _dataContext.CnpjData
                .Include(a => a.AtividadePrincipal)
                .Include(a => a.AtividadesSecundarias)
                .Include(a => a.Qsa)
                .Include(a => a.Billing)
                .Where(a => a.Cnpj == cnpj)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adiciona um novo cadastro de empresa
        /// </summary>
        /// <param name="cnpjData"></param>
        /// <returns></returns>
        public async Task Add(CnpjData cnpjData)
        {
            cnpjData.Id = Guid.NewGuid();
            await _dataContext.AddAsync(cnpjData);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(string cnpj) => await _dataContext.CnpjData.AnyAsync(a => a.Cnpj == cnpj);

    }
}

using MyCNPJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCNPJ.Services
{
    public interface ICnpjDataService
    {
        public Task<CnpjDataViewModel> GetCnpjAsync(string cnpj);
    }
}

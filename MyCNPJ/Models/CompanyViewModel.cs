using MyCNPJ.Entities;
using System.Collections.Generic;

namespace MyCNPJ.Models
{
    public class CompanyViewModel
    {
        public CompanyViewModel(IEnumerable<CnpjData> listCnpjData, int page)
        {
            ListCnpjData = listCnpjData;
            Page = page;
        }
        public IEnumerable<CnpjData> ListCnpjData { get; set; }
        public int Page { get; set; }
    }
}

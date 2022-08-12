using MyCNPJ.Entities;

namespace MyCNPJ.Models
{
    public class CompanyDetailsViewModel : CnpjData
    {
        public CompanyDetailsViewModel(CnpjData cnpjData)
        {
            CnpjData = cnpjData;
        }
        public CnpjData CnpjData  { get;set;}
    }
}

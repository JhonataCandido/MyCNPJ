using MyCNPJ.Entities;
using System.Threading.Tasks;

namespace MyCNPJ.Services
{
    public interface ICreatePdf
    {
        public Task<string> HtmlGenerateAsync(CnpjData cnpjDataViewModel);
        public Task<PdfData> CreatePdfAsync(string html);
    }
}

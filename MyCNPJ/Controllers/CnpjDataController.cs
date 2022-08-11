using Microsoft.AspNetCore.Mvc;
using MyCNPJ.Models;
using MyCNPJ.Services;
using MyCNPJ.Utils;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyCNPJ.Controllers
{
    public class CnpjDataController : Controller
    {
        private ICnpjDataService _cnpjDataService;
        private ICreatePdf _createPdf;

        public CnpjDataController(ICnpjDataService CnpjDataService, ICreatePdf createPdf)
        {
            _cnpjDataService = CnpjDataService;
            _createPdf = createPdf;
        }

        [HttpGet]
        public async Task<IActionResult> CnpjData()
        {
            var cnpjDataViewModel = new CnpjDataViewModel();

            if (TempData["CnpjData"] != null)
            {
                var cnpjviewmodel = JsonConvert.DeserializeObject<CnpjDataViewModel>((string)TempData["CnpjData"]);
                return View(await Task.FromResult(cnpjviewmodel));
            }

            return View(cnpjDataViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePdf(string cnpj)
        {
            var cnpjClientDetails = await _cnpjDataService.GetCnpjAsync(cnpj);

            if (cnpjClientDetails.Status == "OK")
            {
                string html = await _createPdf.HtmlGenerateAsync(cnpjClientDetails);
                var pdf = await _createPdf.CreatePdfAsync(html);

                Response.Headers.Add("Content-Length", pdf.ContentLength);
                Response.Headers.Add("Content-Disposition", "inline; filename=Document_" + cnpjClientDetails.Cnpj.ParseCnpj() + ".pdf");

                return File(pdf.BinaryData, "application/pdf");
            }

            var indexModel = new IndexViewModel() { MessageError = $"Falha ao gerar PDF! Motivo: {cnpjClientDetails.Message}",Cnpj = cnpj};
            return RedirectToAction("Index", "Home", indexModel);
        }
    }
}

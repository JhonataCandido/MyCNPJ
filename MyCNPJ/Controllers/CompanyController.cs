using Microsoft.AspNetCore.Mvc;
using MyCNPJ.Models;
using MyCNPJ.Services;
using MyCNPJ.Services.Company;
using System.Threading.Tasks;

namespace MyCNPJ.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly ICnpjDataService _cnpjDataService;
        public CompanyController(ICompanyService companyService, ICnpjDataService cnpjDataService)
        {
            _companyService = companyService;
            _cnpjDataService = cnpjDataService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _companyService.List(page));
        }

        [HttpGet]
        public async Task<IActionResult> CompanyDetails(string cnpj)
        {
            return View(await _companyService.GetCompanyDetails(cnpj));
        }

        public async Task<IActionResult> Add(string cnpj)
        {
            var exist = await _companyService.Exist(cnpj);
            if (!exist)
            {
                var cnpjData = await _cnpjDataService.GetCnpjAsync(cnpj);
                if (cnpjData.Status == "OK")
                {
                    await _companyService.Add(cnpjData);
                }
                else
                {
                    var indexModel = new IndexViewModel($"Falha ao salvar empresa! Motivo: {cnpjData.Message}", cnpj);
                    return RedirectToAction("Index", "Home", indexModel);
                }
            }
            else
            {
                var indexModel = new IndexViewModel($"Empresa já existente na base!", cnpj);
                return RedirectToAction("Index", "Home", indexModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

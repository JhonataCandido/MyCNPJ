using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCNPJ.Entities;
using MyCNPJ.Models;
using MyCNPJ.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyCNPJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ICnpjDataService _cnpjDataService;

        public HomeController(ILogger<HomeController> logger, ICnpjDataService cnpjDataService)
        {
            _logger = logger;
            _cnpjDataService = cnpjDataService;
        }


        public IActionResult Index(IndexViewModel indexViewModel) => View(indexViewModel);

        [HttpPost]
        public async Task<IActionResult> GetCnpj(string cnpj)
        {
            var dataresult = await _cnpjDataService.GetCnpjAsync(cnpj); 
            if (dataresult.Status != "OK")
            {
                var model = new IndexViewModel() { MessageError = dataresult.Message, Cnpj = cnpj };
                return RedirectToAction("Index", model);
            }

            TempData["CnpjData"] = JsonConvert.SerializeObject(dataresult);
            return RedirectToAction("CnpjData", "CnpjData");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

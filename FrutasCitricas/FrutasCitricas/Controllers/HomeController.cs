using FrutasCitricas.Models;
using FrutasCitricas.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FrutasCitricas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPrivacyService _privacyService;

        public HomeController(IPrivacyService privacyService)
        {
            _privacyService = privacyService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Criar(FrutasModel fruta, IFormFile File)
        {
            if (ModelState.IsValid)
            {
                string IdUrl = "";
                using (var mems = new MemoryStream())
                {
                    File.CopyTo(mems);
                    var fileBytes = mems.ToArray();
                    IdUrl = Convert.ToBase64String(fileBytes);
                }
                fruta.IdUrl = IdUrl;
                _privacyService.Adicionar(fruta);
                return RedirectToAction("Index", "Frutas");
            }

            return View(fruta);
        }
    }
}

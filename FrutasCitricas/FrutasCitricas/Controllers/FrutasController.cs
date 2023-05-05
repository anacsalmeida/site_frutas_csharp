using FrutasCitricas.Models;
using FrutasCitricas.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace FrutasCitricas.Controllers
{
    public class FrutasController : Controller
    {
        private readonly IPrivacyService _privacyService;
        public FrutasModel fruta;


        public FrutasController(IPrivacyService privacyService)
        {
            _privacyService = privacyService;
        }
        public IActionResult Index()
        {
            List<FrutasModel> listaFrutas = _privacyService.FrutasLista();
            foreach (FrutasModel item in listaFrutas)
            {
                item.IdUrl = "data:image/png;base64," + item.IdUrl;
            }

            return View(listaFrutas);
        }

        public IActionResult Editar(int id)
        {
            FrutasModel fruta = _privacyService.BuscarFruta(id);
            List<FrutasModel> frutas = new List<FrutasModel> { fruta };
            return View(fruta);

        }

        [HttpPost]
        public IActionResult Editar(FrutasModel fruta, IFormFile File)
        {
            if (ModelState.IsValid)
            {
                string IdUrl = "";
                using (var mms = new System.IO.MemoryStream())
                {
                    if (File != null )
                    {
                        File.CopyTo(mms);
                        var fileBytes = mms.ToArray();
                        IdUrl = Convert.ToBase64String(fileBytes);
                    }

                    fruta.IdUrl = IdUrl;

                }
                _privacyService.Editar(fruta);
                return RedirectToAction("Index", "Frutas");
            }
            return View(fruta);
        }
        public IActionResult Deletar(int id)
        {
            _privacyService.Deletar(id);
            return RedirectToAction("Index", "Frutas");
        }

        public IActionResult Selecionar(int id)
        {
            FrutasModel fruta = _privacyService.BuscarFruta(id);
            List<FrutasModel> frutas = new List<FrutasModel> { fruta };
            foreach (FrutasModel item in frutas)
            {
                item.IdUrl = "data:image/png;base64," + item.IdUrl;
            }
            return View(frutas);
        }


    }
}

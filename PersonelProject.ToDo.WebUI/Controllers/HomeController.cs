using Microsoft.AspNetCore.Mvc;
using PersonelProject.ToDo.WebUI.CustomFilters;
using PersonelProject.ToDo.WebUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.WebUI.Controllers
{
    //[Route("kisiler/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.Id = id;
            ViewBag.Isim = "Onur";
            TempData["Isim"] = "Giray";
            ViewData["Isimm"] = "Ahmet";
            return View();
        }

        public IActionResult Sonuc()
        {
            return View();
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [AdOlamaz]
        [HttpPost]
        public IActionResult KayitOl2(KullaniciKayitViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            ModelState.AddModelError(nameof(KullaniciKayitViewModel.Ad), "Ad alanı gereklidir.");
            ModelState.AddModelError("", "Modelle ilgili hata");
            return View("KayitOl",model);
        }


    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelProject.ToDo.Business.Interfaces;
using PersonelProject.ToDo.Entities.Concrete;
using PersonelProject.ToDo.Web1.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        public UrgencyController(IUrgencyService urgencyService)
        {
            _urgencyService = urgencyService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "urgency";
            List<Urgency> urgencies = _urgencyService.GetirButunu();

            List<UrgencyListViewModel> model = new List<UrgencyListViewModel>();

            foreach (var item in urgencies)
            {
                UrgencyListViewModel urgencymodel = new UrgencyListViewModel();
                urgencymodel.Id = item.Id;
                urgencymodel.Definition = item.Definition;

                model.Add(urgencymodel);

            }
            return View(model);
        }

        public IActionResult AddUrgency()
        {
            TempData["Active"] = "urgency";
            return View(new UrgencyAddViewModel());
        }

        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Kaydet(new Urgency()
                {
                    Definition = model.Definition

                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = "urgency";
            var urgency=_urgencyService.GetirIdCalisma(id);
            UrgencyUpdateViewModel model = new UrgencyUpdateViewModel
            {
                Id = urgency.Id,
                Definition = urgency.Definition

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Guncelle(new Urgency
                {
                    Id = model.Id,
                    Definition = model.Definition

                });

                return RedirectToAction("Index");
            }
            return View(model);
        }



    }
}

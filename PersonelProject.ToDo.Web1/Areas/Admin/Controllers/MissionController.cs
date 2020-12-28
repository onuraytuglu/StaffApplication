using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class MissionController : Controller
    {
        private readonly IMissionService _missionService;
        private readonly IUrgencyService _urgencyService;
        public MissionController(IMissionService missionService, IUrgencyService urgencyService)
        {
            _urgencyService = urgencyService;
            _missionService = missionService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "mission";
            List<Mission> missions = _missionService.BringUrgencyWithIncomplete();

            List<MissionListViewModel> models = new List<MissionListViewModel>();

            foreach (var item in missions)
            {
                MissionListViewModel model = new MissionListViewModel
                {
                    Id = item.Id,
                    Ad=item.Ad,
                    Aciklama=item.Aciklama,
                    Ozet=item.Ozet,
                    Urgency=item.Urgency,
                    UrgencyId=item.UrgencyId,
                    OlusturulmaTarih=item.OlusturulmaTarih
                    
                };

                models.Add(model);
            }
            return View(models);
        }

        public IActionResult AddMission()
        {
            TempData["Active"] = "mission";
            ViewBag.Urgencies = new SelectList(_urgencyService.GetirButunu(), "Id", "Definition");
            return View(new MissionAddViewModel());

        }
        
        [HttpPost]
        public IActionResult AddMission(MissionAddViewModel model)
        {

            if (ModelState.IsValid)
            {
                _missionService.Kaydet(new Mission 
                { 
                
                    Aciklama = model.Aciklama,
                    Ad=model.Ad,
                    UrgencyId=model.UrgencyId,
                
                
                
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateMission(int id)
        {
            TempData["Active"] = "mission";
            var mission =_missionService.GetirIdCalisma(id);
            MissionUpdateViewModel model = new MissionUpdateViewModel
            {

                Id = mission.Id,
                Aciklama = mission.Aciklama,
                UrgencyId=mission.UrgencyId,
                Ad=mission.Ad


            };
            ViewBag.Urgencies = new SelectList(_urgencyService.GetirButunu(), "Id", "Definition",mission.UrgencyId);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateMission(MissionUpdateViewModel model)
        {
            if(ModelState.IsValid)
            {
                _missionService.Guncelle(new Mission()
                {

                    Id = model.Id,
                    Aciklama = model.Aciklama,
                    UrgencyId = model.UrgencyId,
                    Ad = model.Ad


                });
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public IActionResult DeleteMission(int id)
        {

            _missionService.Sil(new Mission { Id = id });
            return Json(null);

        }
    }
}

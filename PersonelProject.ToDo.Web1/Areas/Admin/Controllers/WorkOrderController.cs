using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WorkOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IMissionService _missionService;
        private readonly UserManager<AppUser> _userManager;
        public WorkOrderController(IAppUserService appUserService, IMissionService missionService, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _missionService = missionService;
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "workorder";
            //var model = _appUserService.BringIsNotAdmmins();
            List<Mission> missions = _missionService.BringAllWithTables();
            List<MissionAllListViewModel> models = new List<MissionAllListViewModel>();
            foreach (var item in missions)
            {
                MissionAllListViewModel model = new MissionAllListViewModel();
                model.Id = item.Id;
                model.Aciklama = item.Aciklama;
                model.Urgency = item.Urgency;
                model.Ad = item.Ad;
                model.AppUser = item.AppUser;
                model.OlusturulmaTarih = item.OlusturulmaTarih;
                model.Reports = item.Reports;
                models.Add(model);
            }


            return View(models);
        }

        public IActionResult ShowDetail(int id)
        {
            TempData["Active"] = "workorder";
            var mission = _missionService.BringReportsWithID(id);
            MissionAllListViewModel model = new MissionAllListViewModel();
            model.Id = mission.Id;
            model.Reports = mission.Reports;
            model.Ad = mission.Ad;
            model.Aciklama = mission.Aciklama;
            model.AppUser = mission.AppUser;

            return View(model);
        }

        public IActionResult AssignPersonel(int id, string s, int page = 1)
        {
            TempData["Active"] = "workorder";

            ViewBag.ActivePage = page;
            //ViewBag.TotalPage = (int)Math.Ceiling((double)_appUserService.BringIsNotAdmmins().Count / 3);

            ViewBag.Search = s;

            int totalPage;
            var mission = _missionService.BringUrgencyWithId(id);

            
            var personels = _appUserService.BringIsNotAdmmins(out totalPage,s, page);

            ViewBag.TotalPage = totalPage;

            List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            foreach (var item in personels)
            {
                AppUserListViewModel model = new AppUserListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.SurName = item.SurName;
                model.Email = item.Email;
                model.Picture = item.Picture;
                appUserListModel.Add(model);


            }

            ViewBag.Personeller = appUserListModel;

            MissionListViewModel missionModel = new MissionListViewModel();
            missionModel.Id = mission.Id;
            missionModel.Ad = mission.Ad;
            missionModel.Aciklama = mission.Aciklama;
            missionModel.Urgency = mission.Urgency;
            missionModel.OlusturulmaTarih = mission.OlusturulmaTarih;


            return View(missionModel);


        }

        [HttpPost]
        public IActionResult AssignPersonel(PersonelAssignViewModel model)
        {
            var updateMission = _missionService.GetirIdCalisma(model.MissionId);
            updateMission.AppUserId = model.PersonelId;
            _missionService.Guncelle(updateMission);
            return RedirectToAction("Index");
        }


        public IActionResult AssignmentPersonel(PersonelAssignViewModel model)
        {
            TempData["Active"] = "workorder";
            var user =_userManager.Users.FirstOrDefault(I => I.Id == model.PersonelId);

            var mission = _missionService.BringUrgencyWithId(model.MissionId);

            AppUserListViewModel userModel = new AppUserListViewModel();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.SurName = user.SurName;
            userModel.Picture = user.Picture;
            userModel.Email = user.Email;


            MissionListViewModel missionModel = new MissionListViewModel();
            missionModel.Id = mission.Id;
            missionModel.Aciklama = mission.Aciklama;
            missionModel.Urgency = mission.Urgency;
            missionModel.Ad = mission.Ad;


            PersonelAssignListViewModel personelAssignViewModel = new PersonelAssignListViewModel();


            personelAssignViewModel.AppUser = userModel;
            personelAssignViewModel.Mission = missionModel;

            return View(personelAssignViewModel);

        }
    }

}

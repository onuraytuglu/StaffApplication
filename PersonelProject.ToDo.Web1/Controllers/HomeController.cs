using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonelProject.ToDo.Business.Interfaces;
using PersonelProject.ToDo.Entities.Concrete;
using PersonelProject.ToDo.Web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMissionService _missionService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(IMissionService missionService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _missionService = missionService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Giris(AppUserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user!=null)
                {
                    var identityResult =await _signInManager.PasswordSignInAsync(model.UserName,
                        model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                        var rols = await _userManager.GetRolesAsync(user);
                        if (rols.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new {area="Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Personel" });
                        }
                    }

                }
                ModelState.AddModelError("", "Username or password is not true");
            }
            return View("Index", model);

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    SurName = model.SurName,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {

                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Personel");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var item in addRoleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");

        }
    }
}

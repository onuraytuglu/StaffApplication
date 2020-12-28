using Microsoft.AspNetCore.Mvc;
using PersonelProject.ToDo.WebUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.WebUI.ViewComponents
{
    public class Products : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("New",new List<CustomersViewModel>() {
                new CustomersViewModel(){Ad="Onur1"},
                new CustomersViewModel(){Ad="Onur1"},
                new CustomersViewModel(){Ad="Onur1"},
                new CustomersViewModel(){Ad="Onur1"},
                new CustomersViewModel(){Ad="Onur1"},
            });
        }



    }
}

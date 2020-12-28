using Microsoft.AspNetCore.Identity;
using PersonelProject.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITablo
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public string Picture { get; set; } = "icon.png";

        public List<Mission> Missions { get; set; }

    }
}

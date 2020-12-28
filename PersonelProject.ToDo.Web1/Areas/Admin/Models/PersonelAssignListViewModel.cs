using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Areas.Admin.Models
{
    public class PersonelAssignListViewModel
    {
        public MissionListViewModel Mission { get; set; }
        public AppUserListViewModel AppUser { get; set; }

    }
}

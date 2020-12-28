using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Areas.Admin.Models
{
    public class MissionAllListViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarih { get; set; }



        public Urgency Urgency { get; set; }
        
        public AppUser AppUser { get; set; }

        public List<Report> Reports { get; set; }

    }
}

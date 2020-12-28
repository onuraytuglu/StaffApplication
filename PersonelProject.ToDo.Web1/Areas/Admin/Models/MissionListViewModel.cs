using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Areas.Admin.Models
{
    public class MissionListViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Ozet { get; set; }
        public DateTime OlusturulmaTarih { get; set; }


        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
    }
}

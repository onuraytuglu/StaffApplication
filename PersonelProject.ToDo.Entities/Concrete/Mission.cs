using PersonelProject.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonelProject.ToDo.Entities.Concrete
{
    public class Mission:ITablo
    {
        public int Id { get; set; }       
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Ozet { get; set; }
        public DateTime OlusturulmaTarih { get; set; } = DateTime.Now;


        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
        public Nullable<int> AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Report> Reports { get; set; }

    }
}

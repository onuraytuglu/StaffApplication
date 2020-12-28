using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Areas.Admin.Models
{
    public class MissionAddViewModel
    {
        [Required(ErrorMessage = "This field cannot be blank.")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        [Range(0,int.MaxValue,ErrorMessage = "Please select an urgency")]
        public int UrgencyId { get; set; }


        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.WebUI.Model
{
    public class KullaniciKayitViewModel
    {
        [Required]
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}

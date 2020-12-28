﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Areas.Admin.Models
{
    public class UrgencyAddViewModel
    {
        [Display(Name ="Definition")]
        [Required(ErrorMessage = "This field cannot be blank.")]
        public string Definition { get; set; }
    }
}

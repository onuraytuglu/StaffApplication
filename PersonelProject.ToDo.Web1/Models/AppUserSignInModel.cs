using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Models
{
    public class AppUserSignInModel
    {
        [Required(ErrorMessage = "Username cannot be blank")]
        [Display(Name = "Username :")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be blank")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me :")]
        public bool RememberMe { get; set; }

    }
}

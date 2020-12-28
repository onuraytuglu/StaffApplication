using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.Models
{
    public class AppUserViewModel
    {
        [Required(ErrorMessage = "Username cannot be blank")]
        [Display(Name ="Username :")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password",ErrorMessage= "Passwords do not match")]
        [Display(Name = "Confirm password :")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Name cannot be blank")]
        [Display(Name = "Name :")]
        
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Surname cannot be blank")]
        [Display(Name = "Surname :")]
        public string SurName { get; set; }
    }
}

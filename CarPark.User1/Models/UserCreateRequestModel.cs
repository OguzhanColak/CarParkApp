using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Models
{
    public class UserCreateRequestModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "NameSurname")]
        public string NameSurname { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "JobTitle")]
        public string JobTitle { get; set; }
    }
}

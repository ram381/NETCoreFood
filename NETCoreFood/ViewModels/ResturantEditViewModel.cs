using NETCoreFood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreFood.ViewModels
{
    public class ResturantEditViewModel
    {
        [Required]
        [Display(Name = "Resturant Name")]
        public string Name { get; set; }

        public CusineType cusineType { get; set; }
    }
}

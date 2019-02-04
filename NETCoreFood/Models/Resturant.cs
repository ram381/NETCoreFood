using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreFood.Models
{
    public class Resturant
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Resturant Name")]
        public string Name { get; set; }

        public CusineType CusineType { get; set; }
    }
}

using NETCoreFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreFood.ViewModels
{
    public class HomeIndexViewModel :IHomeIndexViewModel
    {

        public IEnumerable<Resturant> Resturants { get; set; }

        public string  CurrentMessage { get; set; }
    }
}

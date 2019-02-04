using NETCoreFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreFood.ViewModels
{
    public interface IHomeIndexViewModel
    {

        IEnumerable<Resturant> Resturants { get; set; }

        string CurrentMessage { get; set; }
    }
}

using NETCoreFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreFood.Services
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetAll();

        Resturant GetResturant(int id);
        Resturant AddResturant(Resturant resturant);
        Resturant UpdateResturant(Resturant resturant);
    }
}

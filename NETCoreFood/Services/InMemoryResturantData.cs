using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETCoreFood.Models;

namespace NETCoreFood.Services
{
    //public class InMemoryResturantData:IResturantData
    //{
    //    public InMemoryResturantData()
    //    {
    //        _resturants = new List<Resturant>
    //        {
    //            new Resturant { Id=1, Name=  "Bhargava"},
    //            new Resturant { Id=2, Name=  "Pizza"},
    //             new Resturant { Id=3, Name=  "Burger"},

    //        };
    //    }

    //    public IEnumerable<Resturant> GetAll()
    //    {
    //        return _resturants.OrderBy(o => o.Name);
    //    }

    //    public Resturant GetResturant(int id)
    //    {
    //        return _resturants.FirstOrDefault(o => o.Id == id);
    //    }

    //    public Resturant AddResturant(Resturant resturant)
    //    {
    //        resturant.Id = _resturants.Max(o => o.Id) + 1;
    //        _resturants.Add(resturant);
    //        return resturant;
    //    }

    //    private List<Resturant> _resturants;
    //}
}

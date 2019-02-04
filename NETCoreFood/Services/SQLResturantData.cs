using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETCoreFood.Data;
using NETCoreFood.Models;

namespace NETCoreFood.Services
{
    public class SQLResturantData : IResturantData
    {
        private NETCoreFoodDbContext _netcorefoodContext;

        public SQLResturantData(NETCoreFoodDbContext coreFoodDbContext  )
        {
            _netcorefoodContext = coreFoodDbContext;
        }

        public Resturant AddResturant(Resturant resturant)
        {
            _netcorefoodContext.Resturant.Add(resturant);
            _netcorefoodContext.SaveChanges();
            return resturant;
        }

        public IEnumerable<Resturant> GetAll()
        {
            return _netcorefoodContext.Resturant.OrderBy(o => o.Name);
        }

        public Resturant GetResturant(int id)
        {
            return _netcorefoodContext.Resturant.FirstOrDefault(o => o.Id == id);
        }

        public Resturant UpdateResturant(Resturant resturant)
        {
              _netcorefoodContext.Attach(resturant).State 
                =                 Microsoft.EntityFrameworkCore.EntityState.Modified;

            _netcorefoodContext.SaveChanges();
            return resturant;
        }
    }
}

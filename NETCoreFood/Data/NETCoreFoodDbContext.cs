using Microsoft.EntityFrameworkCore;
using NETCoreFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreFood.Data
{
    public class NETCoreFoodDbContext : DbContext
    {
       

        public NETCoreFoodDbContext(DbContextOptions options)
            :base(options)
        {
           
        }

        public DbSet<Resturant> Resturant { get; set; }

    }
}

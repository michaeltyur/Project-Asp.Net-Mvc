using DAL.DBInitializer;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext():base("ShopDB")
        {
            //Database.SetInitializer(new ShopDBInitializer());

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Item> Items { get; set; }

    }
}

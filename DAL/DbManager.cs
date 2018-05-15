using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbManager:IDisposable

    {
        ShopDbContext context;



        ItemRepository itemRepository;

        UserRepository userRepository;


        public ItemRepository ItemRepository
        {
            get
            {
                return itemRepository ?? new ItemRepository(context);
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                return userRepository ?? new UserRepository(context);
            }
        }

        public DbManager()
        {
            context = new ShopDbContext();         

            //context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}

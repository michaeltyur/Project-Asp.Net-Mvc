using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IItemRepositiry:IDisposable
    {
        void Additem(Item item, User owner);

        void UpdateItem(int id, Item item);

        bool DeletItem(int id);

        IEnumerable<Item> GettItems();

        Item FindItemById(int id);

        IEnumerable<Item> SortByName();

        IEnumerable<Item> SortByDate();

        //void SetOwner(User user);
    }
}

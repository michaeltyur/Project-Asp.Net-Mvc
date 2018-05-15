using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.Repositories
{
    public class ItemRepository : IItemRepositiry
    {
        private ShopDbContext context;

        public ItemRepository(ShopDbContext context)
        {
            this.context = context;
        }
        public void Additem(Item item, User owner)
        {
            item.Owner = owner;
            context.Items.Add(item);
            Save();
        }

        public bool DeletItem(int id)
        {
            try
            {
                var _item = FindItemById(id);
                if (_item != null)
                {
                    context.Items.Remove(_item);
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public void Dispose()
        {
            Dispose();
        }

        public Item FindItemById(int id)
        {
            return context.Items.Include(x => x.Owner).Include(b => b.Byer).FirstOrDefault(i => i.ItemId == id);
        }

        public IEnumerable<Item> GettItems()
        {

            return context.Items.Include(x => x.Owner).ToList();
        }

        public void UpdateItem(int id, Item item)
        {
            Item _item = FindItemById(id);
            if (_item != null)
            {
                _item.Name = item.Name;
                _item.Price = item.Price;
                _item.Image1 = item.Image1;
                _item.Image2 = item.Image2;
                _item.Image3 = item.Image3;
                Save();
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Item> SortByName()
        {
            return context.Items.Include(i => i.Byer).Include(i => i.Owner).OrderBy(i => i.Name).ToList();
        }

        public IEnumerable<Item> SortByDate()
        {
            return context.Items.Include(i=>i.Byer).Include(i=>i.Owner).OrderBy(i => i.TimeCreation).ToList();
        }

        public IEnumerable<Item> LastThreeItems()
        {

            List<Item> allItems = GettItems().ToList();

            List<Item> result = new List<Item>();

            Item tmp = new Item()
            {
                TimeCreation=new DateTime(1700,01,01)
            };


            while (result.Count < 3 && allItems.Count>0)
            {
                foreach (var item in allItems)
                {
                    if (item != null && item.ItemState != State.saled)
                    {
                        if (DateTime.Compare(item.TimeCreation, tmp.TimeCreation) > 0)
                        {
                            tmp = item;
                        }
                    }
                }
                if(tmp.ItemState!=State.saled) result.Add(tmp);
                allItems.Remove(tmp);
                tmp = allItems[0];

            }

            foreach (var item in result)
            {
                yield return item;
            }

        }
    }
}

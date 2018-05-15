using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopSecondHand.Extension
{
   public static class CartMethodExtention
    {
        public static int ItemsInCart(string userName)
        {
            string[] keys = HttpContext.Current.Application.AllKeys;
            int count = 0;

            if (userName == string.Empty)
            {
                foreach (var key in keys)
                {
                    Item item = (Item)(HttpContext.Current.Application[key]);

                    if (item.Byer == null) count++;
                }
                return count;
            }
            else
            {
               foreach (var key in keys)
               {
                   Item item = (Item)(HttpContext.Current.Application[key]);
              
                   if (item.Byer!=null&& item.Byer.UserName==userName)
                   {
                       count++ ;
                   }
               }
                return count;
            }

        }
        public static double TotalPrice( string userName)
        {
            string[] keys = HttpContext.Current.Application.AllKeys;

            double totalPrice = 0;

            if (userName == string.Empty)
            {
                foreach (var key in keys)
                {
                    Item item = (Item)(HttpContext.Current.Application[key]);

                    if (item.Byer == null) totalPrice+=item.Price;
                }
                return totalPrice;
            }
            else
            {
                foreach (var key in keys)
                {
                    Item item = (Item)(HttpContext.Current.Application[key]);

                    if (item.Byer != null && item.Byer.UserName == userName)
                    {
                        totalPrice += item.Price;
                    }
                }
                return totalPrice*0.9;
            }
        }

        public static IEnumerable<Item> ShoppingCollection( string userName)
        {
            string[] keys = HttpContext.Current.Application.AllKeys;

            //IEnumerable<Item> shoppingCollection;

            if (userName == string.Empty)
            {
                foreach (var key in keys)
                {
                    Item item = (Item)(HttpContext.Current.Application[key]);

                    if (item.Byer == null) yield return item;
                }

            }
            else
            {
                foreach (var key in keys)
                {
                    Item item = (Item)(HttpContext.Current.Application[key]);

                    if (item.Byer != null && item.Byer.UserName == userName)
                    {
                        yield return item;
                    }
                }
            }
        }
        public static void ShoppingCartClear(string userName)
        {
            string[] keys = HttpContext.Current.Application.AllKeys;

            //IEnumerable<Item> shoppingCollection;

            if (userName == string.Empty)
            {
                foreach (var key in keys)
                {
                    HttpContext.Current.Application.Remove(key);
                }

            }
            else
            {
                foreach (var key in keys)
                {
                    Item item = (Item)(HttpContext.Current.Application[key]);

                    if (item.Byer != null && item.Byer.UserName == userName)
                    {
                        HttpContext.Current.Application.Remove(key);
                    }
                }
            }
        }
    }

}

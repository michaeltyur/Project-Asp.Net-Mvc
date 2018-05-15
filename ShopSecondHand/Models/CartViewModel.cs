using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSecondHand.Models
{
    public class CartViewModel
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public State ItemState { get; set; }

        public User Byer { get; set; }
    }
}
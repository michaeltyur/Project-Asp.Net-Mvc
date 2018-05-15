using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSecondHand.Models
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public byte[] Image3 { get; set; }

        public DateTime TimeCreation { get; set; }

        public User Owner { get; set; }

        public string ShortDescription { get; set; }
    }
}
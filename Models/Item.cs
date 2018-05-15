using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Name of Item is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Length must be greater than 2 and lass than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 999999999999999999.0, ErrorMessage = "Please enter valid integer number")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Short description is required")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Length must be greater than 3 and lass than 500 characters")]
        public string ShortDescription { get; set; }

        [StringLength(4000, MinimumLength = 3, ErrorMessage = "Length must be greater than 3 and lass than 4000 characters")]
        public string LongDescription { get; set; }

        public State ItemState { get; set; }

        [Display(Name = "First Image")]
        public byte[] Image1 { get; set; }

        [Display(Name = "Second Image")]
        public byte[] Image2 { get; set; }

        [Display(Name = "Third Image")]
        public byte[] Image3 { get; set; }


        [Display(Name = "Time of Creation")]
        [DataType(DataType.Date)]
        public DateTime TimeCreation { get; set; }

        public User Owner { get; set; }

        public User Byer { get; set; }

        public Item()
        {           
            ItemState = State.in_stock;
            TimeCreation = DateTime.Now;
        }
        public Item(DateTime date)
        {
            ItemState = State.in_stock;
            TimeCreation = date;
        }

    }
    public enum State
    {
        in_stock=1,
        in_cart=2,
        saled=3
    }


}

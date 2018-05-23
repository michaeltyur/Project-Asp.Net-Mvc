using DAL;
using Models;
using ShopSecondHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ShopSecondHand.Controllers
{
    public class CartController : Controller
    {
       private DbManager _dbManager;

        //constractor
        public CartController()
        {
            _dbManager = new DbManager();
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Cart()
        {
            TempData["Title"] = "Shopping Cart";

            TempData["CartButtonColor"] = "#3c1d06";

            ViewBag.Message = TempData["Message"];

            List<CartViewModel> userItems = new List<CartViewModel>();
            List<CartViewModel> guestItems = new List<CartViewModel>();

            string[] keys = new string[HttpContext.Application.Count];
            keys = HttpContext.Application.AllKeys;

            foreach (var key in keys)
            {
                Item item = (Item)HttpContext.Application[key];

                if (item.Byer != null
                    && User.Identity.Name == item.Byer.UserName
                    && User.Identity.IsAuthenticated
                    && item.ItemState == State.in_cart)
                {
                    userItems.Add(new CartViewModel()
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        Price = item.Price,
                        ItemState = item.ItemState,
                        Byer = item.Byer
                    });
                }
                else if (item.Byer == null && item.ItemState == State.in_cart)
                {
                    guestItems.Add(new CartViewModel()
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        Price = item.Price,
                        ItemState = item.ItemState,
                        Byer = item.Byer
                    });

                }
            }
            if (User.Identity.IsAuthenticated)
            {
                ViewData["CartItemsList"] = userItems;
                return View(userItems);
            }
            else
            {
                ViewData["CartItemsList"] = guestItems;
                return View(guestItems);
            }
        }

        public ActionResult AddToCart(int id)
        {
            Item _item = _dbManager.ItemRepository.FindItemById(id);

            if (_item != null)
            {
                //_item.ItemState = State.in_cart;
                _item.ItemState = State.in_cart;
                _item.Byer = _dbManager.UserRepository.FindUserByName(User.Identity.Name);
                _dbManager.ItemRepository.Save();

                HttpContext.Application.Lock();
                HttpContext.Application[$"{id}"] = _item;
                HttpContext.Application.UnLock();

            }
            return RedirectToAction("Cart");
        }

        //Remove item from items for buy and sending email to seller
        public ActionResult CheckOut()
        {
            TempData["Message"] = null;

            var cartList = Extension.CartMethodExtention.ShoppingCollection(User.Identity.Name);

            if (cartList.Count() == 0)
            {
                TempData["Message"] = "Your Cart is Empty";

                return RedirectToAction("Cart");
            }

            if (cartList != null && cartList.Count() > 0)
            {
                foreach (var item in cartList)
                {
                    Item dbItem = _dbManager.ItemRepository.FindItemById(item.ItemId);
                    dbItem.ItemState = State.saled;
                    _dbManager.ItemRepository.Save();
                    try
                    {
                        HttpContext.Application.Remove(item.ItemId.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in clear Shopping Cart(): {0}",
                                    ex.ToString());
                    }
                }

                if (User.Identity.IsAuthenticated)
                {
                    User byer = _dbManager.UserRepository.FindUserByName(User.Identity.Name);

                    SmtpClient client = new SmtpClient();

                    MailAddress from = new MailAddress("shopsecondhand2018@gmail.com", "Shop Team");

                    MailAddress to = new MailAddress($"{byer.Email}", "Dear Looser");

                    MailMessage mailMessage = new MailMessage(from, to)
                    {
                        Subject = "The good buy",
                        Body = "Thank you for spending money.\n" +
                        "Recommend us to others loosers,please\n" +
                        "Good Luck!"
                    };
                    try
                    {
                        client.Send(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateCopyMessage(): {0}",
                                    ex.ToString());
                    }
                }
            }
            return RedirectToAction("Index","Home");

        }

        public ActionResult DeleteFromCart(int id)
        {
            Item _item = _dbManager.ItemRepository.FindItemById(id);

            if (_item != null)
            {
                _item.ItemState = State.in_stock;
                _item.Byer = null;
                _dbManager.ItemRepository.Save();

                HttpContext.Application.Lock();
                HttpContext.Application.Remove($"{id}");
                HttpContext.Application.UnLock();

            }
            return RedirectToAction("Cart");
        }
    }
}
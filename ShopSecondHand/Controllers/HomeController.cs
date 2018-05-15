using DAL;
using Models;
using ShopSecondHand.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace ShopSecondHand.Controllers
{
    public class HomeController : Controller
    {
        private DbManager _dbManager;

        //constractor
        public HomeController()
        {
            _dbManager = new DbManager();
        }

        // GET: Home
        [Route("")]
        public ActionResult Index()
        {          
            TempData["Title"] = "Home";

            TempData["HomeButtonColor"] = "#3c1d06";

            var _items = _dbManager.ItemRepository.GettItems();
            List<ItemViewModel> _shortItems = new List<ItemViewModel>();
            foreach (var item in _items)
            {
                if (item.ItemState == State.in_stock)
                {
                    _shortItems.Add(new ItemViewModel()
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        ShortDescription = item.ShortDescription,
                        Price = item.Price,
                        TimeCreation = item.TimeCreation,
                        Owner=item.Owner,
                        Image1 = item.Image1,
                        Image2 = item.Image2,
                        Image3 = item.Image3
                    });
                }
            }
            return View(_shortItems);
        }

        //Create New
        [Authorize]
        public ActionResult Ad()
        {
            TempData["Title"] = "Advert";

            Item _newItem = new Item();
            return View(_newItem);
        }

        //Add Owner
        [Authorize]
        [HttpPost]
        public ActionResult Ad(Item item, List<HttpPostedFileBase> files)
        {
            try
            {
                if (item == null)
                {
                    ModelState.AddModelError("", "Item not found");
                    return View(item);
                }
                foreach (var file in files)
                {
                    if ((file != null) &&
                       (Path.GetExtension(file.FileName).ToLower() != ".jpg"
                     && Path.GetExtension(file.FileName).ToLower() != ".png"
                     && Path.GetExtension(file.FileName).ToLower() != ".gif"))
                    {
                        ModelState.AddModelError("file", "Invalid file type");
                        return View(item);
                    }
                }
                if (ModelState.IsValid)
                {
                    if (files[0] != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            files[0].InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            item.Image1 = array;
                        }
                        //TempData["Item"] = item;
                    }
                    if (files[1] != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            files[1].InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            item.Image2 = array;
                        }
                        //TempData["Item"] = item;
                    }
                    if (files[2] != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            files[2].InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            item.Image3 = array;
                        }
                        //TempData["Item"] = item;
                    }
                    User owner = _dbManager.UserRepository.FindUserByName(User.Identity.Name);
                    item.TimeCreation = DateTime.Now;
                    _dbManager.ItemRepository.Additem(item, owner);
                    return RedirectToAction("Index");
                }
                return View(item);


            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult Details(int id)
        {
            TempData["Title"] = "Details";

            Item _item = _dbManager.ItemRepository.FindItemById(id);
            if (_item != null)
            {
                return View(_item);
            }
            else
            {
                TempData["Title"] = "Not Found";
                return RedirectToAction("NotFound", "Error");
            }
        }

        [Authorize]
        public ActionResult EditItem(int id)
        {
            TempData["Title"] = "Update Item";
            Item _item = _dbManager.ItemRepository.FindItemById(id);
            return View(_item);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditItem(Item item, List<HttpPostedFileBase> files)
        {
            Item _oldItem = _dbManager.ItemRepository.FindItemById(item.ItemId);

            foreach (var file in files)
            {
                if ((file != null) &&
                   (Path.GetExtension(file.FileName).ToLower() != ".jpg"
                 && Path.GetExtension(file.FileName).ToLower() != ".png"
                 && Path.GetExtension(file.FileName).ToLower() != ".gif"))
                {
                    ModelState.AddModelError("file", "Invalid file type");
                    return View(item);
                }
            }

            if (_oldItem != null)
            {

                if (ModelState.IsValid)
                {
                    _oldItem.Byer = item.Byer;
                    _oldItem.ItemState = item.ItemState;
                    _oldItem.LongDescription = item.LongDescription;
                    _oldItem.Name = item.Name;
                    _oldItem.Owner = _dbManager.UserRepository.FindUserByName(User.Identity.Name);
                    _oldItem.Price = item.Price;
                    _oldItem.ShortDescription = item.ShortDescription;
                    _oldItem.TimeCreation = item.TimeCreation;
                    _dbManager.Save();

                    if (files[0] != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            files[0].InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            item.Image1 = array;
                        }
                        //TempData["Item"] = item;
                    }
                    if (files[1] != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            files[1].InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            item.Image2 = array;
                        }
                        //TempData["Item"] = item;
                    }
                    if (files[2] != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            files[2].InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            item.Image3 = array;
                        }
                        //TempData["Item"] = item;
                    }
                    User owner = _dbManager.UserRepository.FindUserByName(User.Identity.Name);
                    //item.TimeCreation = DateTime.Now;

                    _dbManager.Save();

                    return RedirectToAction("Index");
                }
                return View(item);



            }
            else
            {

                ModelState.AddModelError("", "Item not found");
                return View(item);
            }
        }



        public ActionResult SortByName()
        {
            TempData["Title"] = "Home";

            var _items = _dbManager.ItemRepository.SortByName();

            List<ItemViewModel> _shortItems = new List<ItemViewModel>();

            foreach (var item in _items)
            {
                if (item.ItemState == State.in_stock)
                {
                    _shortItems.Add(new ItemViewModel()
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        ShortDescription = item.ShortDescription,
                        Price = item.Price,
                        TimeCreation = item.TimeCreation,
                        Owner = item.Owner,
                        Image1 = item.Image1,
                        Image2 = item.Image2,
                        Image3 = item.Image3
                    });
                }
            }

            return View("Index", _shortItems);
        }

        public ActionResult SortByDate()
        {
            TempData["Title"] = "Home";

            var _items = _dbManager.ItemRepository.SortByDate();

            List<ItemViewModel> _shortItems = new List<ItemViewModel>();

            foreach (var item in _items)
            {
                if (item.ItemState == State.in_stock)
                {
                    _shortItems.Add(new ItemViewModel()
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        ShortDescription = item.ShortDescription,
                        Price = item.Price,
                        TimeCreation = item.TimeCreation,
                        Owner = item.Owner,
                        Image1 = item.Image1,
                        Image2 = item.Image2,
                        Image3 = item.Image3
                    });
                }
            }

            return View("Index", _shortItems);
        }

        public ActionResult About()
        {
            TempData["Title"] = "About";

            TempData["AboutButtonColor"] = "#3c1d06";

            return View("About", "_CustomLayout");
        }

     
   


    }

}
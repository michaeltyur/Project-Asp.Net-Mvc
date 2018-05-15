using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSecondHand.Controllers
{
    public class AdsController : Controller
    {
        private DbManager _dbManager;

        //constractor
        public AdsController()
        {
            _dbManager = new DbManager();
        }

        public ActionResult Ads()

        {
            ViewBag.Title = TempData["Title"];


            ViewBag.HomeButtonColor = TempData["HomeButtonColor"];
            ViewBag.UserButtonColor = TempData["UserButtonColor"];
            //ViewBag.AboutButtonColor = TempData["AboutButtonColor"];
            ViewBag.CartButtonColor = TempData["CartButtonColor"];

            IEnumerable<Item> lastedItems = _dbManager.ItemRepository.LastThreeItems().ToList();

            return View(lastedItems);
        }
    }
}
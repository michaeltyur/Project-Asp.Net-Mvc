using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSecondHand.Controllers
{
    public class AdminController : Controller
    {
        private DbManager _dbManager;

        public AdminController()
        {
            _dbManager = new DbManager();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult ListUsers(User user)
        {

            var users = _dbManager.UserRepository.GettUsers().Where(u => u.UserName != User.Identity.Name).ToList();

            return View(users);
        }
    }
}
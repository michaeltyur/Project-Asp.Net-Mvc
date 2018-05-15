using DAL;
using Models;
using ShopSecondHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopSecondHand.Controllers
{
    public class AccountController : Controller
    {
        private DbManager _dbManager;

        public AccountController()
        {
            _dbManager = new DbManager();
        }

        //[ChildActionOnly]
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("LoginError", user);
            }
            else
            {
                var users = _dbManager.UserRepository.GettUsers();
                var _user = _dbManager.UserRepository.FindUserByNameAndPassword(user.UserName, user.Password);

                if (_user != null)
                {

                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    HttpContext.Response.Cookies.Add(
                        new HttpCookie("Quest")
                        {
                            Value = "Quest",
                            Expires = DateTime.Now.AddHours(1)
                        });
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");

                    TempData["ViewData"] = ViewData;

                    return RedirectToAction("LoginError", user);
                }
            }
        }
        //Login Errore
        public ActionResult LoginError(LoginViewModel user)
        {
            if (TempData["ViewData"] != null)
            {
                // restore the ViewData
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            TempData["Title"] = "Login Error";

            return View(user);
        }

        public ActionResult Logout()
        {
            if (User != null && User.Identity != null)
            {
                FormsAuthentication.SignOut();

                // clear authentication cookie
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
                {
                    Expires = DateTime.Now.AddYears(-1)
                };
                Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Quest")
                {
                    Expires = DateTime.Now.AddYears(-1)
                };
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registration()
        {
            TempData["Title"] = "Registration";

            TempData["UserButtonColor"] = "#3c1d06";

            User _user = new User();

            return View(_user);
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            User _user = user;


            if (!ModelState.IsValid)
            {
                return View(_user);
            }
            else if (_dbManager.UserRepository.FindUserByName(_user.UserName)!=null)
            {
                ModelState.AddModelError("", "Sorry, this name already exists");
                return View(_user);
            }
            else
            {
                _dbManager.UserRepository.AddUser(user);
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EditUser()
        {
            TempData["Title"] = "Edit User";

            TempData["UserButtonColor"] = "#3c1d06";

            User _user = _dbManager.UserRepository.FindUserByName(User.Identity.Name);

            if (_user != null) return View(_user);

            else return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            User _oldUser = _dbManager.UserRepository.FindUserByName(user.UserName);

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                _dbManager.UserRepository.UpdateUser(user);
                return RedirectToAction("Index", "Home");
            }

        }



    }
}
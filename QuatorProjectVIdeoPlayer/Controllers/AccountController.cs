using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuatorProjectVIdeoPlayer.Data;
using QuatorProjectVIdeoPlayer.Models;

namespace QuatorProjectVIdeoPlayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpAccessor;

        public AccountController(IHttpContextAccessor accessor)
        {
            _httpAccessor = accessor;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Account a)
        {
            if (ModelState.IsValid)
            {
                bool isEmailAndUsernameAvailable = true;
                if (AccountDb.IsEmailTaken(a.Email))
                {
                    isEmailAndUsernameAvailable = false;
                    ModelState.AddModelError(string.Empty, "Email address is taken");
                }

                if (AccountDb.IsUsernameTaken(a.Username))
                {
                    isEmailAndUsernameAvailable = false;
                    ModelState.AddModelError(string.Empty, "Username is taken");
                }

                if (!isEmailAndUsernameAvailable)
                {
                    return View(a);
                }

                AccountDb.Add(a);
                SessionHelper.LogUserIn(_httpAccessor, a.AccountId, a.Username);
                TempData["Message"] = "You registered sucessfully";
                return RedirectToAction("Index", "Home");
            }

            return View(a);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = AccountDb.IsLoginValid(model);
                if (account != null)
                {
                    SessionHelper.LogUserIn(_httpAccessor, account.AccountId, account.Username);
                    TempData["Message"] = "Logged in successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "You didn't enter the correct information");
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            SessionHelper.LogOut(_httpAccessor);
            TempData["Message"] = "You have been logged out";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult MyVideos()
        {
            if (SessionHelper.IsLoggedIn(_httpAccessor))
            {
                int? memberId = SessionHelper.WhosLoggedIn(_httpAccessor);

                List<Video> userVideos = AccountDb.getUserVideos(memberId);

                return View(userVideos);
            }
            else
            {
                TempData["Message"] = "You must be logged in to view your videos";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult AccountSettings()
        {
            if (SessionHelper.IsLoggedIn(_httpAccessor))
            {
                return View();
            }
            else
            {
                TempData["Message"] = "You must be logged in to change settings";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult AccountSettings(Account a)
        {
            int? memberId = SessionHelper.WhosLoggedIn(_httpAccessor);
            var darkModeCheckBox = Request.Form["darkModeCheckBox"].ToString();
            if(darkModeCheckBox == "on")
            {
                AccountDb.SwitchDarkMode(true, memberId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                AccountDb.SwitchDarkMode(false, memberId);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
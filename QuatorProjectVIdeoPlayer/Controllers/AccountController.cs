using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuatorProjectVIdeoPlayer.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
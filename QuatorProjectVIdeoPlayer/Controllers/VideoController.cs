using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuatorProjectVIdeoPlayer.Models;

namespace QuatorProjectVIdeoPlayer.Controllers
{
    public class VideoController : Controller
    {
        [HttpGet]
        public IActionResult VideoViewer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VideoViewer(Video video)
        {

            return View(video);
        }

        [HttpGet]
        public IActionResult uploadVideo()
        {
            return View();
        }
    }
}
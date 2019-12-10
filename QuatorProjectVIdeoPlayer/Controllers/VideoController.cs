using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuatorProjectVIdeoPlayer.Data;
using QuatorProjectVIdeoPlayer.Models;

namespace QuatorProjectVIdeoPlayer.Controllers
{
    public class VideoController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _accessor;

        public VideoController(IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _env = env;
            _accessor = accessor;
        }

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

        [HttpPost]
        public IActionResult uploadVideo(Video video)
        {
            int accountid = Convert.ToInt32(SessionHelper.WhosLoggedIn(_accessor));
            video.AccountId = accountid;

            ModelState.Remove(nameof(Video.ThumbnailUrl));

            if (ModelState.IsValid)
            {
                IFormFile thumbnail = video.Thumbnail;

                string extension = Path.GetExtension(thumbnail.FileName);
                if(extension == ".png" || extension == ".jpg")
                {
                    //Use ImageSharp to resize image if needed
                    //https://www.hanselman.com/blog/HowDoYouUseSystemDrawingInNETCore.aspx

                    string newFileName = Guid.NewGuid().ToString();

                    if(thumbnail.Length > 0)
                    {
                        string filePath = Path.Combine(_env.WebRootPath, "images", newFileName + extension);

                        video.ThumbnailUrl = "images/" + newFileName + extension;

                        VideoDb.addVideo(video);

                        using(FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            thumbnail.CopyTo(fs);
                        }
                        return RedirectToAction("MyVideos", "Account");
                    }

                    return View();
                }
            }

            return View();
        }
    }
}
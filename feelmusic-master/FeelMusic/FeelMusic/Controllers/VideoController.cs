using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelMusic.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeelMusic.Controllers
{
    [Route("api/video")]
    public class VideoController : Controller
    {
        VideoDataAccessLayer videoDAL = new VideoDataAccessLayer();

        [HttpGet, Route("index")]
        public IEnumerable<Video> Index()
        {
            return videoDAL.GetAllVideos();
        }

        [HttpGet, Route("details/{id?}")]
        public Video Details(int id)
        {
            return videoDAL.GetVideoData(id);
        }

    }
}

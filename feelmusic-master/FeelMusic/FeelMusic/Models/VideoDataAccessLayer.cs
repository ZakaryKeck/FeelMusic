using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelMusic.Models;
using Microsoft.EntityFrameworkCore;

namespace FeelMusic.Models
{
    public class VideoDataAccessLayer
    {
        CornHacks2019DBContext db = new CornHacks2019DBContext();

        public IEnumerable<Video> GetAllVideos()
        {
            try
            {
                return db.Video.ToList();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee  
        public Video GetVideoData(int id)
        {
            try
            {
                Video employee = db.Video.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }
    }
}

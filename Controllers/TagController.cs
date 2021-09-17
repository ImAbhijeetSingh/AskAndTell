using AskAndTell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskAndTell.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        //static Tag Tag = new Tag();
        // GET: Tag
        public ActionResult Index()
        {
            List<string> Tags = db.Tags.Select(t => t.TagName).ToList();
            return View(Tags);
        }

        [HttpGet]
        public ActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTag(string tagName)
        {

            List<Tag> tags = db.Tags.Where(x => x.TagName == tagName).ToList();
            if(tags.Count == 0)
            {
                db.Tags.Add(new Tag { TagName = tagName });
                db.SaveChanges();
            }
            return RedirectToAction("AddTag");
        }
    }
}
using AskAndTell.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskAndTell.Controllers
{
    public class QuestionController : Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //public QuestionController(UserManager<IdentityUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        static ApplicationDbContext db = new ApplicationDbContext();
        // GET: Question
        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }
        public ActionResult NewestFirst()
        {
            return View(db.Questions.OrderByDescending(q=>q.DateTime).ToList());
        }
        public ActionResult MostAnsweredFirst()
        {
            return View(db.Questions.OrderByDescending(q => q.Answers.Count()).ToList());
        }

        // GET
        [Authorize]
        [HttpGet]
        public ActionResult AskQuestion()
        {
            ViewBag.TagId1 = new SelectList(db.Tags, "Id", "TagName");
            ViewBag.TagId2 = new SelectList(db.Tags, "Id", "TagName");
            ViewBag.TagId3 = new SelectList(db.Tags, "Id", "TagName");
            return View();
        }

        // Post
        [HttpPost]
        public ActionResult AskQuestion( string title, string body, int TagId1, int TagId2, int TagId3)
        {
            if (ModelState.IsValid)
            {
                Question question = new Question();
                ViewBag.TagId1 = new SelectList(db.Tags, "Id", "TagName");
                ViewBag.TagId2 = new SelectList(db.Tags, "Id", "TagName");
                ViewBag.TagId3 = new SelectList(db.Tags, "Id", "TagName");
                List<Tag> Tags = new List<Tag>();
                Tags.Add(db.Tags.FirstOrDefault(t => t.Id == TagId1));
                Tags.Add(db.Tags.FirstOrDefault(t => t.Id == TagId2));
                Tags.Add(db.Tags.FirstOrDefault(t => t.Id == TagId3));
                question.Title = title;
                question.Body = body;
                question.Tags = Tags;
                question.UserId = User.Identity.GetUserId();
                question.DateTime = DateTime.Now;
                question.Votes = 0;
                db.Questions.Add(question);
                db.SaveChanges();
            }
            return RedirectToAction("AskQuestion");
        }
        public ActionResult ByTag(int Id)
        {
            Tag tag = db.Tags.FirstOrDefault(t=>t.Id == Id);
            var result = tag.Questions.ToList();
            ViewBag.TagName = tag.TagName;
            return View(result);
        }
    }
}
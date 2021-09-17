using AskAndTell.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskAndTell.Controllers
{
    public class CommentController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        // GET: Comment
        [HttpGet]
        public ActionResult Index(int id)
        {
            Dictionary<Answer, Comment> result = new Dictionary<Answer, Comment>();
            result.Add(db.Answers.Where(a => a.Id == id).FirstOrDefault(), new Comment());
            var ques = db.Answers.Where(a => a.Id == id).FirstOrDefault();
            ViewBag.User = db.Users.Where(u => u.Id == ques.UserId).FirstOrDefault();
            return View(result);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(int id, string body)
        {
            var comment = new Comment();
            comment.UserId = User.Identity.GetUserId();
            comment.AnswerId = id;
            comment.Body = body;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("../Comment/index/" + id);
        }

        public ActionResult UpVote(int id)
        {
            var answer = db.Answers.Where(a => a.Id == id).FirstOrDefault();
            if (answer.UserId != User.Identity.GetUserId())
            {
                answer.Votes += 1;
                db.Users.Where(u => u.Id == answer.UserId).FirstOrDefault().Reputation += 5;
            }
            return RedirectToAction("index/" + id);
        }

        public ActionResult DownVote(int id)
        {
            var answer = db.Answers.Where(a => a.Id == id).FirstOrDefault();
            if (answer.UserId != User.Identity.GetUserId())
            {
                answer.Votes -= 1;
                db.Users.Where(u => u.Id == answer.UserId).FirstOrDefault().Reputation -= 5;
            }
            return RedirectToAction("index/" + id);
        }

        [Authorize]
        public ActionResult AcceptAnswer(int id)
        {
            var answer = db.Answers.Where(a => a.Id == id).FirstOrDefault();
            var question = db.Questions.Where(q => q.Id == answer.QuestionId).FirstOrDefault();
            if (question.UserId == User.Identity.GetUserId())
            {
                answer.IsAccepted = true;
            }
            db.SaveChanges();
            return RedirectToAction("index/" + id);
        }
    }
}
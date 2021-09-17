using AskAndTell.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskAndTell.Controllers
{
    public class AnswerController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        // GET: Answer
        [HttpGet]
        public ActionResult Index(int id)
        {
            Answer answer = new Answer();
            answer.QuestionId = id;
            Dictionary<Question, Answer> result = new Dictionary<Question, Answer>();
            result.Add(db.Questions.Where(q => q.Id == id).FirstOrDefault(), answer);
            var ques = db.Questions.Where(q => q.Id == id).FirstOrDefault();
            var user = db.Users;
            ViewBag.User = db.Users.Where(u => u.Id == ques.UserId).FirstOrDefault();
            return View(result);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(int id, string body, string commentBody)
        {
            Answer answer = new Answer();
            answer.UserId = User.Identity.GetUserId();
            answer.QuestionId = id;
            answer.Body = body;
            db.Answers.Add(answer);

            Comment comment = new Comment();
            comment.UserId = User.Identity.GetUserId();
            comment.Body = commentBody;
            comment.QuestionId = id;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("../Question/index");
        }

        public ActionResult UpVote(int id)
        {
            var question = db.Questions.Where(q => q.Id == id).FirstOrDefault();
            if (question.UserId != User.Identity.GetUserId())
            {
                question.Votes += 1;
                db.Users.Where(u => u.Id == question.UserId).FirstOrDefault().Reputation += 5;
            }
            return RedirectToAction("index/" + id);
        }
        public ActionResult DownVote(int id)
        {
            var question = db.Questions.Where(q => q.Id == id).FirstOrDefault();
            if (question.UserId != User.Identity.GetUserId())
            {
                question.Votes -= 1;
                db.Users.Where(u => u.Id == question.UserId).FirstOrDefault().Reputation -= 5;
            }
            return RedirectToAction("index/" + id);
        }
    }
}
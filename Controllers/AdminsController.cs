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
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>
            (new RoleStore<IdentityRole>(db));
        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(string Name)
        {
            MembershipHelper.AddRole(Name);
            return RedirectToAction("AddRole");
        }

        [HttpGet]
        public ActionResult AddUserToRole()
        {
            ViewBag.userId = new SelectList(db.Users.ToList(), "Id", "Email");
            ViewBag.role = new SelectList(db.Roles.ToList(), "Name", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddUserToRole(string userId, string role)
        {
            // SelectList User
            ViewBag.userId = new SelectList(db.Users.ToList(), "Id", "Email");
            // SelectList Roles
            ViewBag.role = new SelectList(db.Roles.ToList(), "Name", "Name");
            // Add this user to this role using the membershipHelp
            MembershipHelper.AddUserToRole(userId, role);
            return View();
        }
    }
}
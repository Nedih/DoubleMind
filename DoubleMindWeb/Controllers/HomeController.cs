using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoubleMindWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DoubleMindWeb.Controllers
{

    [RequireHttps]
    public class HomeController : Controller
    {

        // создаем контекст данных
        //UsersList db = new UsersList();
        //CommentsList db2 = new CommentsList();

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Index()
        {
            return View();     
        }

        public ActionResult Download()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult CommentsAdmin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Comments()
        {
            // получаем из бд все объекты Book
            //IEnumerable<User> users = db.Users;
            // IEnumerable<Comment> comments = db2.Comments;
            // передаем все объекты в динамическое свойство Books в ViewBag
            //ViewBag.Users = users;
            // ViewBag.Comments = comments;
            // возвращаем представление



            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByName(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            ViewBag.Roles = roles;
            return View(roles);
        }

        public ActionResult Contacts()
        {
            return View();
        }



        /*[HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }*/

    }
}
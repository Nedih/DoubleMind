using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoubleMindWeb.Models;

namespace DoubleMindWeb.Controllers
{
    public class HomeController : Controller
    {

        // создаем контекст данных
        UsersList db = new UsersList();
        CommentsList db2 = new CommentsList();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            //IEnumerable<User> users = db.Users;
            IEnumerable<Comment> comments = db2.Comments;
            // передаем все объекты в динамическое свойство Books в ViewBag
            //ViewBag.Users = users;
            ViewBag.Comments = comments;
            // возвращаем представление
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
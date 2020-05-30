using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoubleMindWeb.Models;
using System.Data;
using System.Data.Entity;
using System.Runtime.Serialization;
using DocumentFormat.OpenXml.Wordprocessing;
using NHibernate.Cfg;
using SQLitePCL;
using NuGet.Configuration;
using NuGet;

namespace DoubleMindWeb.Controllers
{
    public class UsersController : ApiController
    {

        ApplicationDbContext db = new ApplicationDbContext();

        

        /* [HttpGet]
         public IEnumerable<ApplicationUser> Get()
         {
             var mapper = MapHelper.Mapping<Todo, ApplicationUser>();
             return mapper.Map<List<ApplicationUser>>(this.todoService.GetTodos()); 
         }


         [HttpGet("{id}")]
         public ApplicationUser Get(int id)
         {
             var mapper = MapHelper.Mapping<Todo, ApplicationUser>();
             return mapper.Map<ApplicationUser>(this.todoService.GetTodoById(id));
         }*/

        public IEnumerable<ApplicationUser> GetUsers()
        {
            IEnumerable<ApplicationUser> users = db.Users.ToList();
            return users;
        }

        public ApplicationUser GetBook(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            return user;
        }

        [HttpPost]
        public void CreateBook([FromBody]ApplicationUser user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditBook(string id, [FromBody]ApplicationUser user)
        {
            if (id == user.Id)
            {
                db.Entry(user).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteBook(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}

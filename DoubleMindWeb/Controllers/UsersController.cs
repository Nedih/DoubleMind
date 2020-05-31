using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoubleMindWeb.Models;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Host.SystemWeb;
using System.Threading.Tasks;
using System.Web.Routing;

namespace DoubleMindWeb.Controllers
{
    //[Authorize]
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

        [HttpGet]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            IEnumerable<ApplicationUser> users = db.Users.ToList();
            return users;
        }

        [HttpPost]
        //[Route("{id}/{password}")]
        public async Task<bool> Login([FromBody] LoginViewModel model)
        {
            // Сбои при входе не приводят к блокированию учетной записи
            // Чтобы ошибки при вводе пароля инициировали блокирование учетной записи, замените на shouldLockout: true

            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext()
                                                  .GetUserManager<ApplicationUserManager>();

            ClaimsIdentity claim = null;
            ApplicationUser user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
                return true;
            return false;
/*  
                model.RememberMe = false;
            var result = await SignInManager.PasswordSignInAsync(model.Email.GetUntilOrEmpty(), model.Password, model.RememberMe, shouldLockout: false);*/
           /* switch (result)
            {
                case SignInStatus.Success:
                    
                default:
                    ModelState.AddModelError("", "Failed attempt.");
                    return false;
            }*/
        }
        
        public ApplicationUser GetUser(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            return user;
        }
/*
        [HttpPost]
        public void CreateUser([FromBody]ApplicationUser user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }*/

        [HttpPut]
        public void EditUser(string id, [FromBody]ApplicationUser user)
        {
            if (id == user.Id)
            {
                db.Entry(user).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

      /*  public void DeleteBook(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }*/
    }
}

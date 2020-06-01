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

/*
        [HttpGet]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            IEnumerable<ApplicationUser> users = db.Users.ToList();
            return users;
        }*/

        [HttpPost]
        public async Task<bool> Login([FromBody] LoginViewModel model)
        {

            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext()
                                                  .GetUserManager<ApplicationUserManager>();

            ClaimsIdentity claim = null;
            ApplicationUser user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
                return true;
            return false;
        }

        [HttpGet]
        public GameUserModels GetUser([FromBody] ApplicationUser usr)
        {
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext()
                                                  .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByName(usr.Email);
            GameUserModels guser = new GameUserModels(user.UserLevel, user.UserPoints);           
            if (user != null)
                return guser;
            return null;
        }

        [HttpPut]
        public void EditUser([FromBody]ApplicationUser usr)
        {
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext()
                                                 .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByName(usr.Email);
            if (user != null)
            {


                //db.Entry(user).State = EntityState.Modified;

                user.UserLevel = usr.UserLevel;
                user.UserPoints = usr.UserPoints;

                userManager.Update(user) ;
               // db.Users.Attach(user);

               // db.SaveChanges();
            }
        }
    }
}

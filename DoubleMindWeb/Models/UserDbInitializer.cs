using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DoubleMindWeb.Models
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UsersList>
    {
        protected override void Seed(UsersList db)
        {
            db.Users.Add(new User { Login = "AnnaPep", Password = "ryaryarary"});
            db.Users.Add(new User { Login = "Shasha", Password = "Urmavermaht"});
            db.Users.Add(new User { Login = "Admin", Password = "FlexPrP" });

            base.Seed(db);
        }
    }
}
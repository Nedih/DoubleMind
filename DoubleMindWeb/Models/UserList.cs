using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DoubleMindWeb.Models
{
    public class UsersList : DbContext
    {
        public DbSet<User> Users { get; set; }

    }
}
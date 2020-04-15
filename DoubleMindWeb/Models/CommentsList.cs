using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoubleMindWeb.Models
{
    public class CommentsList : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
    }
}
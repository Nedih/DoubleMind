using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoubleMindWeb.Models
{
    public class CommentDbInitializer : DropCreateDatabaseAlways<CommentsList>
    {
        protected override void Seed(CommentsList db)
        {
            db.Comments.Add(new Comment { CommentUser = new User { Login = "Raz" }, CommentText = "ryaryarary", CommentStars = 5 });
            db.Comments.Add(new Comment { CommentUser = new User { Login = "Dva" }, CommentText = "Hohoho", CommentStars = 4 });
            db.Comments.Add(new Comment { CommentUser = new User { Login = "Tri" }, CommentText = "superflex", CommentStars = 5 });

            base.Seed(db);
        }
    }
}
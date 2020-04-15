using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoubleMindWeb.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public virtual User CommentUser { get; set; }
        //public string CommentUserName { get; set; }
        public string CommentText { get; set; }
        public int CommentStars { get; set; }
    }
}
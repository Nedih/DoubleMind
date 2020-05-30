using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DoubleMindWeb.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Comment> UserComments { get; set; }
        [DataMember]
        public int UserLevel { get; set; }
        [DataMember]
        public int UserPoints { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public virtual ApplicationUser CommentUser { get; set; }
        //public string CommentUserName { get; set; }
        public string CommentText { get; set; }
        public int CommentStars { get; set; }
        public string CommentUserName { get; set; }
        public DateTime CommentCreated { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext() : base("IdentityDb", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
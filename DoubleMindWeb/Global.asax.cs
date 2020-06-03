using DoubleMindWeb.Models;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DoubleMindWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Database.SetInitializer(new UserDbInitializer());
            //Database.SetInitializer(new CommentDbInitializer());
            Application["Totaluser"] = 15;
            Application["DownloadLink"] = "https://drive.google.com/drive/folders/19VUZNhvSwJd79g410hA2V7PS5PysNYWU?usp=sharing";
            LinkModel.DownloadLink = "https://drive.google.com/drive/folders/19VUZNhvSwJd79g410hA2V7PS5PysNYWU?usp=sharing";
            LinkModel.TelegramLink = "https://t.me/harnaDivchinka";
            LinkModel.LinkeDinLink = "https://www.linkedin.com/in/daria-bidna-5379571a5/";
            LinkModel.GmailLink = "https://mail.google.com/mail/u/1/#inbox?compose=GTvVlcSMVxmVPLSrxRJxjJghrqnQRCfFKrkbLKgmbzRQvdjhNSfJXTcWTcGKzbWRxmRzDTkJtcchT";
            LinkModel.TwitchLink = "https://www.twitch.tv/dashyzza";
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start()
        {
            // Code that runs when a new session is started
            Application.Lock();
            Application["Totaluser"] = (int)Application["Totaluser"] + 1;
            Application.UnLock();
        }
    }
}

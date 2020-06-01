using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoubleMindWeb.Models
{
    public class GameUserModels
    {
        public int UserLevel { get; set; }
        public int UserPoints { get; set; }
        public GameUserModels(int lvl, int pts)
        {
            this.UserLevel = lvl;
            this.UserPoints = pts;
        }
    }
}
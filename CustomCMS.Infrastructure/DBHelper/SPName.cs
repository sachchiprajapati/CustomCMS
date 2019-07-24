using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCMS.Infrastructure
{
   public static class SPName
    {
        public static string spLogin = "sp_login";
        public static string spSlider = "sp_slider";
        public static string spSocialMediaMaster = "sp_socialmediamaster";
        public static string spSocialMediaDetail = "sp_socialmediadetail";
    }

    public static class SPMode
    {
        public static string modeSelect = "SELECT";
        public static string modeInsert = "INSERT";
        public static string modeUpdate = "UPDATE";
        public static string modeDelete = "DELETE";
        public static string modeGetByID = "SELECTBYID";
    }
}

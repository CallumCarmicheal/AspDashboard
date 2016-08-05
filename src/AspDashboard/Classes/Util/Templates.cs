using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspDashboard.Classes.Util {
    public class Templates {

        // TODO: MAKE FUNCTION TO CALCULATE CURRENT AND HIGHLIGHT PAGE!
        public static HtmlString RenderTabItem(string Name, string Location, params string[] Args) {
            string classRes = "";
            bool isCurrentPath = false;

            var appUrl = VirtualPathUtility.ToAbsolute("~/");       // create an absolute path for the application root
            var relativeUrl = HttpContext.Current.Request.Url.
                AbsolutePath.Remove(0, appUrl.Length - 1);          // remove the app path (exclude the last slash)

            isCurrentPath = (relativeUrl == Location);
            if (isCurrentPath) { classRes = "menu-top-active"; }

            // Todo: Add Arguments

            if (isCurrentPath)
                 return new HtmlString($"<li><a class=\"{classRes}\" href=\"#\">{Name}</a></li>");
            else return new HtmlString($"<li><a class=\"{classRes}\" href=\"{Location}\">{Name}</a></li>");
        }

        public static HtmlString RenderTabItem(string Name, string[] Locations, params string[] Args) {
            string classRes = "";
            bool isCurrentPath = false;

            var appUrl = VirtualPathUtility.ToAbsolute("~/");       // create an absolute path for the application root
            var relativeUrl = HttpContext.Current.Request.Url.
                AbsolutePath.Remove(0, appUrl.Length - 1);          // remove the app path (exclude the last slash)

            foreach(string x in Locations) 
                isCurrentPath = isCurrentPath ? true : relativeUrl == x;
            
            if (isCurrentPath) { classRes = "menu-top-active"; }

            // Todo: Add Arguments

            if(isCurrentPath)
                 return new HtmlString($"<li><a class=\"{classRes}\" href=\"#\">{Name}</a></li>");
            else return new HtmlString($"<li><a class=\"{classRes}\" href=\"{Locations[0]}\">{Name}</a></li>");
        }
    }
}
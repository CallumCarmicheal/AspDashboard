using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDashboard.Classes.Util {
    public class Templates {

        // TODO: MAKE FUNCTION TO CALCULATE CURRENT AND HIGHLIGHT PAGE!
        public static HtmlString RenderTabItem(string Name, string Controller, string Action, params string[] Args) {
            UrlHelper Url = new UrlHelper();

            string controllerName = "";
            string actionName = "";
            string locationRes = "";
            string classRes = "";
            string returnResult = "";
            bool isCurrentAction = false;

            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            if (routeValues != null) {
                if (routeValues.ContainsKey("action")) { actionName = routeValues["action"].ToString(); }
                if (routeValues.ContainsKey("controller")) { controllerName = routeValues["controller"].ToString(); }

                isCurrentAction = ((controllerName == Controller) && (actionName == Action));
            }

            if (isCurrentAction) {
                classRes = "menu-top-active";
            }

            locationRes = Url.Action(Action, Controller);
            return new HtmlString($"<li><a class=\"{classRes}\" href=\"{locationRes}\">{Name}</a></li>");
        }
    }
}
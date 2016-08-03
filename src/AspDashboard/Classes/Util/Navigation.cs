using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDashboard.Classes.Util {
    public class NavigationLinkASP : Navigation {
        public string Controller, View, Area;

        private string GetView() {
            if (string.IsNullOrEmpty(View))
                View = "Index";
            return View;
        }

        public override string GetAnchor(string Text, string Classes="") {
            //string tag = "<a class=\""+Classes+"\" href=\"" + URL_FORMAT_ASP + "\">{3}</a>";
            //return string.Format(tag, (string.IsNullOrWhiteSpace(Area) ? "" : Area + "/"), Controller, GetView(), Text);
            return $"<a class=\"{Classes}\" href=\"" + (string.IsNullOrWhiteSpace(Area)? "" : "/" + Area) + $"/{Controller}/{View}\">{Text}</a>";
        }

        public override string GetURL() {
            //return string.Format(URL_FORMAT_ASP, (string.IsNullOrWhiteSpace(Area) ? "" : Area + "/"), Controller, GetView());
            return (string.IsNullOrWhiteSpace(Area) ? "" : "/" + Area) + $"/{Controller}/{View}";
        }
    }

    public class NavigationLinkWEB : Navigation{
        public string URL;

        public override string GetAnchor(string Text, string Classes="") {
            string tag = "<a class=\"" + Classes + "\" href=\"{0}\">{1}</a>";

            //return string.Format(tag, URL, Text);

            return $"<a class=\"{Classes}\" href=\"{URL}\">Text</a>";
        }

        public override string GetURL() {
            return URL;
        }
    }

    public class Navigation {

        public virtual string GetAnchor(string Text, string Classes="")     { return ""; }
        public virtual string GetURL()                                      { return ""; }
    }
}

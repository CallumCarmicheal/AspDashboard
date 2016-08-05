using System.Web.Mvc;

namespace AspDashboard.Areas.Dashboard {
    // ADAdmin -> AspDashboard Admin
    public class ADAdmin : AreaRegistration {
        public override string AreaName {
            get { return "ADAdmin"; }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "ADAdmin",
                "ADAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
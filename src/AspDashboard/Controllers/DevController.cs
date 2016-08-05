using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDashboard.Controllers {
    public class DevController : Controller {
        // GET: Dev
        public ActionResult Index() {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult random() {
            return Content("4");
        }
    }
}
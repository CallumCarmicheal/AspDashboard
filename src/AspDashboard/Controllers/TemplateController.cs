using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDashboard.Classes.Views;

namespace AspDashboard.Controllers {
    public class TemplateController : Controller {
        [ChildActionOnly]
        public ActionResult CurrentUser(dynamic vB) {
            var x = new Template_Navbar_Params() {
                ViewBag = vB,
                elems = Classes.Navigation.Navbar.GenerateNavbar()
            }; return PartialView(x);
        }

        [ChildActionOnly]
        public ActionResult NavBarItems(dynamic vB) {
            var x = new Template_Navbar_Params() {
                ViewBag = vB,
                elems = Classes.Navigation.Navbar.GenerateNavbar()
            }; return PartialView(x);
        }

        [ChildActionOnly]
        public ActionResult Footer(dynamic vB) {
            var x = new Template_Navbar_Params() {
                ViewBag = vB,
                elems = Classes.Navigation.Navbar.GenerateNavbar()
            }; return PartialView(x);
        }

        [ChildActionOnly]
        public ActionResult ScriptResources(dynamic vB) {
            var x = new Template_Navbar_Params() {
                ViewBag = vB,
                elems = Classes.Navigation.Navbar.GenerateNavbar()
            }; return PartialView(x);
        }

        [ChildActionOnly]
        public ActionResult StyleResources(dynamic vB) {
            var x = new Template_Navbar_Params() {
                ViewBag = vB,
                elems = Classes.Navigation.Navbar.GenerateNavbar()
            }; return PartialView(x);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDashboard.Classes.Navigation {
    public class Navbar {
        
        public static List<NavbarElement> GenerateNavbar() {

            // This will be used to generate dyanmic navbar elements
            // Such as admin 

            var x = new List<NavbarElement>();

            var defaultNav = new Util.NavigationLinkASP {
                Controller  = "Home",
                View        = "Index"
            };

            x.Add(new NavbarElement {
                Text        = "Dashboard",
                Icon        = "fa fa-dashboard fa-fw",
                NavType     = NavbarType.Link,
                Navigation  = new Util.NavigationLinkASP {
                    Controller = "Home",
                    View = "Index"
                }
            });

            x.Add(new NavbarElement {
                Text        = "Sub Menu test",
                Icon        = "fa fa-bar-chart-o fa-fw",
                NavType     = NavbarType.Children,
                Children    = new List<NavbarElement>() {
                    new NavbarElement {
                        Text        = "Item 1",
                        NavType     = NavbarType.Link,
                        Navigation  = new Util.NavigationLinkASP {
                            Controller  = "Home",
                            View        = "Index"
                        }
                    }, new NavbarElement {
                        Text        = "Item 2",
                        NavType     = NavbarType.Link,
                        Navigation  = new Util.NavigationLinkASP {
                            Controller  = "Home",
                            View        = "Index"
                        }
                    }
                }
            }); return x;
        }
    }
}

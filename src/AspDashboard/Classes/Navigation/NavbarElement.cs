using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDashboard.Classes.Navigation {
    public enum NavbarType {
        Link, Children, Divider
    }

    public class NavbarElement {
        private bool _hasIcon = false;

        /// <summary>
        /// States if the navbar contains an icon!
        /// </summary>
        public bool HasIcon { get { return _hasIcon; } }
        
        /// <summary>
        /// The Displayed text for the navbar element.
        /// </summary>
        public string Text = "";

        // Optional Content
        public NavbarType NavType = NavbarType.Link;                        // Decides what way the nav element will be displayed
        public List<NavbarElement>  Children;                               // Used for the potential children!
        public Util.Navigation      Navigation;                             // Used for the redirect links

        private string _Icon = "";
        /// <summary>
        /// Returns the Icon for the element.
        /// </summary>
        public string Icon {
            get { return _Icon; } set {
                _Icon = value;
                _hasIcon = !string.IsNullOrWhiteSpace(value);
            }
        }
    }
}

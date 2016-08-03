using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspDashboard.Classes.Util;

namespace AspDashboard.Classes {
    public class AppVariables {
        public static Logging Loggers;




        static AppVariables() {
            Loggers = new Logging();

        }
    }
}
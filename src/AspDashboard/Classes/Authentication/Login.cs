using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDashboard.Classes.Authentication {
    public class Login {
        UserEngine engine = new UserEngine();

        public bool isLoginCorrect(string username, string password) {
            // Encrypt the Username
            // Encrypt the Password
            // Check the database
            
            // Simple testing method
            string  tmp_un = "admin",
                    tmp_up = "admin";
            bool    flg_un = (username == tmp_un),
                    flg_up = (password == tmp_up);
            return (flg_un && flg_up);
        }

        public bool attemptUserLogin(string username, string password) {
            bool loginCorrect = this.isLoginCorrect(username, password);

            if(loginCorrect) {
                // Todo: Get user via database
                // FAKE DATA
                IUserAccount account = new IUserAccount(
                    ID:             0,
                    Username:       "admin",
                    Email:          "admin@example.com",
                    AuthLevel:      IUserLevel.GlobalAdmin,

                    DateCreated:    DateTime.Now,
                    LastAccess:     DateTime.Now,
                    
                    CUID:           null,
                    Enabled:        true,
                    Banned:         true
                );
                
                // Add user to session!
                HttpContext.Current.Session.Add("User", account);

                
            }

            AppVariables.Loggers.Info.WriteLine("Login.attemptUserLogin", "Login Status: " + loginCorrect);
            return loginCorrect;
        }
    }
}
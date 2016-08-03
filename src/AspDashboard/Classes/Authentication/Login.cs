using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace AspDashboard.Classes.Authentication {
    public class Login {
        UserEngine engine = new UserEngine();
        
        public bool isLoginCorrect(string username, string password) {
            // Check the database

            /*/ Simple testing method
            string  tmp_un = "admin",
                    tmp_up = "admin";
            bool    flg_un = (username == tmp_un),
                    flg_up = (password == tmp_up);
            return (flg_un && flg_up); //*/


            MySqlConnection con = null;
            Database.Configuration.open(ref con);

            string sql = "SELECT password FROM users WHERE username=@un";
            string bPass = "";
            using(var cmd = new MySqlCommand(sql, con)) {
                cmd.Parameters.AddWithValue("@un", username);
                using(var rdr = cmd.ExecuteReader()) {
                    if (rdr.HasRows) {
                        bPass = rdr.GetString(0);
                    } else {
                        return false;
                    }
                }
            }

            try {
                var res = BCrypt.CheckPassword(password, bPass);
                return res;
            } catch { return false; }
        }

        public bool attemptUserLogin(string username, string password) {
            bool loginCorrect = this.isLoginCorrect(username, password);

            if(loginCorrect) {

                // Todo: Get user via database
                /*/ FAKE DATA
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
                ); //*/

                //
                //int ID, string Username, IUserLevel AuthLevel, 
                //string Email, bool Enabled, DateTime DateCreated, DateTime LastAccess, string CUID = null, bool Banned = false



                MySqlConnection con = null;
                Database.Configuration.open(ref con);

                string sql = "select * from users where username=@un";
                using (var cmd = new MySqlCommand(sql, con)) {
                    cmd.Parameters.AddWithValue("@un", username);
                    using (var rdr = cmd.ExecuteReader()) {
                        /*int 
                            uId;
                        string
                            uUsername,
                            uCuid
                            uEmail;
                        IUserLevel 
                            uAl;
                        DateTime
                            DateCreated,
                            LastAccess;
                        string 


                        var ordinal = rdr.GetOrdinal("timeOut");
                        if (rdr.IsDBNull(ordinal)) {
                             queryResult.Egresstime = "Logged in";
                        else queryResult.Egresstime = rdr.GetString(ordinal);*/
                    }
                }

                // Add user to session!
                //HttpContext.Current.Session.Add("User", account);
            }

            AppVariables.Loggers.Info.WriteLine("Login.attemptUserLogin", "Login Status: " + loginCorrect);
            return loginCorrect;
        }
    }
}
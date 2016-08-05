using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDashboard.Classes.Database;
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
                    if (rdr.Read() && rdr.HasRows) {
                        var ordinal = rdr.GetOrdinal("password");
                        if (rdr.IsDBNull(ordinal)) 
                             return false;
                        else bPass = rdr.GetString(ordinal);
                    } else { return false; }
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

                string sql = "select * from users where username=binary @un";
                using (var cmd = new MySqlCommand(sql, con)) {
                    cmd.Parameters.AddWithValue("@un", username);
                    using (var rdr = cmd.ExecuteReader()) {
                        if (!rdr.Read() && rdr.HasRows) 
                            return false;

                        int
                            uID,
                            uAlR,
                            uState;
                        string
                            uPassword,
                            uName,
                            uCuid,
                            uEmail;
                        EUserLevel
                            uAl;
                        EUserState
                            uSt;
                        DateTime
                            DateCreated,
                            LastAccess;

                        if (!ReaderHelper.ReadViaOrdianal(       rdr, "id",             out uID)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", "There was a error while trying to recieve the user values (id)!");       return false;
                        } else if (!ReaderHelper.ReadViaOrdianal(rdr, "password", out uPassword)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"There was a error while trying to recieve the user values (password) for id '{username}'!"); return false;
                        } else if (!ReaderHelper.ReadViaOrdianal(rdr, "realname",       out uName)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"There was a error while trying to recieve the user values (realname) for id '{username}'!"); return false;
                        } else if (!ReaderHelper.ReadViaOrdianal(rdr, "level",          out uAlR)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"There was a error while trying to recieve the user values (level) for id '{username}'!"); return false;
                        } else if (!ReaderHelper.ReadViaOrdianal(rdr, "state",          out uState)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"There was a error while trying to recieve the user values (state) for user '{username}'!"); return false;
                        } else if (!ReaderHelper.ReadViaOrdianal(rdr, "cuid",           out uCuid)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"There was a error while trying to recieve the user values (cuid) for user '{username}'!"); return false;
                        } else if (!ReaderHelper.ReadViaOrdianal(rdr, "email",          out uEmail)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"There was a error while trying to recieve the user values (email) for user '{username}'!"); return false;
                        } else if (!ReaderHelper.ReadViaOrdianal(rdr, "datecreated",    out DateCreated)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"There was a error while trying to recieve the user values (datecreated) for user '{username}'!"); return false;
                        } else if (!ReaderHelper.ReadViaOrdianal(rdr, "lastaccess",     out LastAccess)) {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"There was a error while trying to recieve the user values (lastaccess) for user '{username}'!"); return false;
                        }

                        // Check if the password is valid!
                        if(!BCrypt.CheckPassword(password, uPassword)) {
                            AppVariables.Loggers.Info.WriteLine("Login.attemptUserLogin", $"A failed login for '{username}', id={uID} has occured!");
                            return false;
                        }
                        
                        // Attempt to convert uAlR to IUserLevel
                        try { uAl = (EUserLevel)uAlR; } catch {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"Column 'level' (uAlR) contains the wrong values for '{username}' and cannot be converted into a EUserLevel Enum!");
                            return false;
                        } try { uSt = (EUserState)uState; } catch {
                            AppVariables.Loggers.Error.WriteLine("Login.attemptUserLogin", $"Column 'state' (uState) contains the wrong values for '{username}' and cannot be converted into a EUserState Enum!");
                            return false;
                        }

                        // Now create the user and store it into session
                        IUserAccount account = new IUserAccount(
                            ID:             uID,
                            Username:       username,
                            CUID:           uCuid,

                            Name:           uName,
                            Email:          uEmail,

                            AuthLevel:      uAl,
                            State:          uSt,

                            DateCreated:    DateCreated,
                            LastAccess:     LastAccess
                        );

                        if  (HttpContext.Current.Session["User"] != null) 
                             HttpContext.Current.Session["User"] = account;
                        else HttpContext.Current.Session.Add("User", account);
                     }
                }

                // Add user to session!
                //HttpContext.Current.Session.Add("User", account);
            }

            AppVariables.Loggers.Info.WriteLine("Login.attemptUserLogin", "Login Status: " + loginCorrect + "\n");
            return loginCorrect;
        }
    }
}
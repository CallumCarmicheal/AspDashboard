using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AspDashboard.Classes;
using AspDashboard.Classes.Authentication;

namespace AspDashboard.Controllers {
    public class AccountController : Controller {
        private void Log(string act, string msg) {
            AppVariables.Loggers.Info.WriteLineCtrl("AccountController", act, msg);
        }

        // GET: Account
        public ActionResult Index() { return Content("TODO"); }

        [ChildActionOnly]
        private ActionResult Session_Ajax_Resp(bool grant, string error = "") {
            var response = new {
                accessGranted = grant,
                error = error
            };

            return Json(response);
        }

        public ActionResult Session_Login() {
            Login   log             = new Login();
            string  name_Username = "username",
                    name_Password = "passwd";

            //return Session_Login_Ret(true, "Hello World!");

            if (Request.HttpMethod == "POST") {
                bool userValid = false,
                     passValid = false;
                string
                    user = "",
                    pass = "";

                /* Check if the user or pass exists and is not null */ {
                    if(Request.Form.HasKeys()) {
                        userValid = (Request.Form[name_Username] != null);
                        passValid = (Request.Form[name_Password] != null);

                        user = userValid ? Request.Form[name_Username] : "";
                        pass = passValid ? Request.Form[name_Password] : "";

                        userValid = userValid ? !string.IsNullOrWhiteSpace(user) : false;
                        passValid = userValid ? !string.IsNullOrWhiteSpace(user) : false;
                    } else {
                        Log("Session_Login", "Invalid Request #0");
                        return Session_Ajax_Resp(false, "Invalid request #0");
                    }
                }

                /* Check if the user/pass is valid and if so attempt login */ {
                    if (userValid && passValid) {
                        var lAuth       = new Classes.Authentication.Login();
                        bool loginState = lAuth.isLoginCorrect(user, pass);

                        if(loginState) {
                            lAuth.attemptUserLogin(user, pass);

                            Log("Session_Login", "Successfully logged in " + user);
                            return Session_Ajax_Resp(true, "Successfully logged in!");
                        } else {
                            Log("Session_Login", $"Incorrect username and password for {user}");
                            return Session_Ajax_Resp(false, "Incorrect username and password");
                        }

                        
                    } else {
                        Log("Session_Login", $"Invalid username and password combination for {user}");
                        return Session_Ajax_Resp(false, "Invalid username and password");
                    }
                } 

            } else {
                Log("Session_Login", "Invalid request #1");
                return Session_Ajax_Resp(false, "Invalid request #1");
            }

            // No Error 
            Log("Session_Login", "Fallback Request");
            return Session_Ajax_Resp(false, "Fallback Error!");
        }

        public ActionResult Session_Register() {
            if (!AspDashboard.Classes.Util.Config.Get().GetBool("registration_enabled", false))
                return Session_Ajax_Resp(false, "Registration is disabled at the moment!" + Environment.NewLine + "If you think this is a error please contact one of the Administrators!");
            
            // REQUIRED: rUser, rPass, rEmail, rName
            Login   log             = new Login();
            string  name_Username = "rUser",
                    name_Password = "rPass",
                    name_Email    = "rEmail",
                    name_Name     = "rName";

            //return Session_Login_Ret(true, "Hello World!");

            if (Request.HttpMethod == "POST") {
                bool userValid       = false,
                     passValid       = false,
                     emailValid      = false,
                     rnamValid       = false,
                     userRegisted    = false,
                     everythingValid = false;
                string
                    user  = "",
                    name  = "",
                    pass  = "",
                    email = "";

                // TODO: REMOVE THIS WHEN NOT TESTING
                // IT WILL EXPOSE USER PASSWORDS INTO THE LOG FILE!
                string logStr = 
                    string.Join(", ",
                        Request.Form
                          .AllKeys
                          .Select(key => key + ": " + Request.Form[key])
                        .ToArray());
                Log("Session_Register", logStr);

                /* Check if the user or pass exists and is not null */ {
                    if(Request.Form.HasKeys()) {
                        // Check if the values are not null by default
                        // NOTE: THIS STOPS ANY EXCEPTIONS AT THE ISNULLORWHITESPACE STAGE
                        userValid  = (Request.Form[name_Username] != null);
                        passValid  = (Request.Form[name_Password] != null);
                        emailValid = (Request.Form[name_Email]    != null);
                        rnamValid  = (Request.Form[name_Name]     != null);
                        Log("Session_Register", $"Validation (#0): userValid={userValid}, passValid={passValid}, emailValid={emailValid}, rnamValid={rnamValid}.");

                        // Check if the values exist
                        user  = userValid  ? Request.Form[name_Username] : "";
                        pass  = passValid  ? Request.Form[name_Password] : "";
                        email = emailValid ? Request.Form[name_Email]    : "";
                        name  = rnamValid  ? Request.Form[name_Name]     : "";
                        Log("Session_Register", $"Validation (#1): userValid={userValid}, passValid={passValid}, emailValid={emailValid}, rnamValid={rnamValid}.");

                        // Check if the values are not null/whitespaced
                        userValid  = userValid  ? !string.IsNullOrWhiteSpace(user)  : false;
                        passValid  = passValid  ? !string.IsNullOrWhiteSpace(pass)  : false;
                        rnamValid  = rnamValid  ? !string.IsNullOrWhiteSpace(name)  : false;
                        emailValid = emailValid ? !string.IsNullOrWhiteSpace(email) : false;
                        emailValid = emailValid ? 
                            Regex.IsMatch(email, 
                                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\." + 
                                @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:" + 
                                @"[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                                RegexOptions.IgnoreCase) 
                            : false;
                        Log("Session_Register", $"Validation (#2): userValid={userValid}, passValid={passValid}, emailValid={emailValid}, rnamValid={rnamValid}.");

                        // Check if the values are at the required lengths  
                        userValid  = userValid  ? user.Length  >= 5   : false; 
                        userValid  = userValid  ? user.Length  <= 80  : false; 
                        passValid  = passValid  ? pass.Length  >= 5   : false; 
                        passValid  = passValid  ? pass.Length  <= 90  : false; 
                        rnamValid  = rnamValid  ? name.Length  >= 5   : false; 
                        rnamValid  = rnamValid  ? name.Length  <= 250 : false; // Like to see a name that long
                        emailValid = emailValid ? email.Length >= 5   : false;
                        emailValid = emailValid ? email.Length <= 250 : false;
                        Log("Session_Register", $"Validation (#3): userValid={userValid}, passValid={passValid}, emailValid={emailValid}, rnamValid={rnamValid}.");
                        
                        // Check if everything is valid
                        everythingValid = (userValid && passValid && emailValid && rnamValid);
                    } else {
                        Log("Session_Register",         "Invalid Request #0");
                        return Session_Ajax_Resp(false, "Invalid request #0, please check over your values!");
                    }
                }

                /* Attempt to create the user account if everything checks out */ {
                    if(everythingValid) {
                        var ae = new UserEngine();
                        if(ae.userExists(user)) {
                            Log("Session_Register", $"User already exists: Username={user}");
                            return Session_Ajax_Resp(false, "User is already registered!");
                        }


                        Register reg = new Register();

                        // With a tiny chance of the password
                        // getting generated incorrectly
                        // i just want to make sure it aint
                        // its most likely imposibile but one
                        // cant be to sure.
                        bool valid = false; var spass = "";
                        while (!valid) {
                            var salt  = BCrypt.GenerateSalt();
                                spass = BCrypt.HashPassword(pass, salt);
                                valid = BCrypt.CheckPassword(pass, spass);
                        }

                        userRegisted = reg.RegisterUser(user, spass, email, name);
                        Log("Session_Register", "Registration Status: " + userRegisted);
                    } else {
                        Log("Session_Register", $"Invalid results: userValid={userValid}, passValid={passValid}, emailValid={emailValid}, rnamValid={rnamValid}.");
                        return Session_Ajax_Resp(false, "Invalid results, The requested values are not valid!");
                    }
                }

                /* Try to login as the user we just created if registered */ {
                    if (userValid && passValid && emailValid && userRegisted) {
                        var lAuth       = new Classes.Authentication.Login();
                        bool loginState = lAuth.isLoginCorrect(user, pass);

                        if(loginState) {
                            lAuth.attemptUserLogin(user, pass);

                            Log("Session_Register", "Successfully registered and logged in " + user);
                            return Session_Ajax_Resp(true, "Successfully registered and logged in!");
                        } else {
                            Log("Session_Register", $"Incorrect username and password {user}");
                            return Session_Ajax_Resp(false, "Incorrect username and password");
                        }
                    } else {
                        Log("Session_Register", $"Invalid username and password combination for {user}");
                        return Session_Ajax_Resp(false, "Invalid username and password");
                    }
                } 

            } else {
                Log("Session_Register", "Invalid request #1");
                return Session_Ajax_Resp(false, "Invalid request #1");
            } return Session_Ajax_Resp(false, "Fallback Error!");
        }



        public ActionResult Session_Logoff() {
            Session["User"] = null;
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDashboard.Classes.Authentication {
    public enum EUserLevel {
        GlobalAdmin     = 0,
        GlobalModerator = 1,
        NormalUser      = 2
    }

    public enum EUserState {
        Disabled        = 0,
        Enabled         = 1,
        Banned          = 2
    }

    public class IUserAccount {
        // User information
        private int         ID;
        private string      CUID;
        private string      Username;
        private EUserLevel  AuthLevel;
        private EUserState  State;

        // Extra Information
        private string      Email;
        private string      Name;

        // User information
        private DateTime    DateCreated;
        private DateTime    LastAccess;
        
        // GETTERS
        public int          getID()             { return this.ID; }
        public string       getCUID()           { return this.CUID; }
        public string       getUsername()       { return this.Username; }
        public string       getName()           { return this.Name; }
        public string       getEmail()          { return this.Email; }

        public DateTime     getDateCreated()    { return this.DateCreated; }
        public DateTime     getLastAccess()     { return this.LastAccess; }

        public EUserLevel getAuthLevel()        { return this.AuthLevel; }
        public EUserState   getUserState()      { return this.State; }

        public bool         isEnabled()         { return (this.State == EUserState.Enabled); }
        public bool         isBanned()          { return (this.State == EUserState.Banned); }


        // Methods
        public bool hasCustomID()               { return string.IsNullOrWhiteSpace(this.CUID); }


        public IUserAccount(int ID, string Username, EUserLevel AuthLevel, string Name, string Email, DateTime DateCreated, DateTime LastAccess, string CUID = null, EUserState State = EUserState.Disabled) {
            this.ID             = ID;
            this.CUID           = CUID;         // Hidden Personalised Username     (Used for Logging In with more security: OPTIONAL)
            this.Username       = Username;     // Public Username                  (USED BY DEFAULT)
            this.Name           = Name;
            this.AuthLevel      = AuthLevel;
            this.State          = State;
            this.Email          = Email;
            this.DateCreated    = DateCreated;
            this.LastAccess     = LastAccess;
        }
    }

    public class IUserResult {
        public IUserAccount User;
        public bool         Exists = false;
    }

    public class UserEngine {
        public bool userExists(string Username) {
            string sql = "SELECT id FROM users WHERE username=binary @userid";

            MySql.Data.MySqlClient.MySqlConnection con = null;
            var result = Database.Configuration.open(ref con);
            if (!result) return true;

            var cdm = new MySql.Data.MySqlClient.MySqlCommand(sql, con);
            cdm.Parameters.AddWithValue("@userid", Username);
            using (var res = cdm.ExecuteReader()) 
                return res.HasRows; // If the reader has a row then the user exists. Simple right?
        }

        public IUserResult getUserViaID(int id) {
            // Return default (DOES NOT EXIST)
            return new IUserResult();
        }

        public IUserResult getUserViaUsername(string Username) {
            // Return default (DOES NOT EXIST)
            return new IUserResult();
        }

        public IUserResult getUserViaEmail(string Email) {
            // Return default (DOES NOT EXIST)
            return new IUserResult();
        }

        /// <summary>
        /// Returns the currently logged in user!
        /// </summary>
        /// <returns></returns>
        public static IUserResult getUser() {
            IUserResult res = new IUserResult();

            if (HttpContext.Current.Session["User"] == null) {
                res.Exists = false;
                return res;
            }

            IUserAccount user = HttpContext.Current.Session["User"] as IUserAccount;
            res.User = user;
            res.Exists = true;
            return res;
        }
    }
}
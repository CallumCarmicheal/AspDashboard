using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDashboard.Classes.Authentication {
    public enum IUserLevel {
        GlobalAdmin         = 0,
        GlobalModerator     = 1,
        NormalUser          = 2
    }

    public class IUserAccount {
        // User information
        private int         ID;
        private string      CUID;
        private string      Username;
        private IUserLevel  AuthLevel;

        // Extra Information
        private string      Email;

        // User information
        private DateTime    DateCreated;
        private DateTime    LastAccess;

        private bool        Enabled;
        private bool        Banned;
        
        // GETTERS
        public int          getID()             { return this.ID; }
        public string       getCUID()           { return this.CUID; }
        public string       getUsername()       { return this.Username; }
        public IUserLevel   getAuthLevel()      { return this.AuthLevel; }

        public string       getEmail()          { return this.Email; }
        public DateTime     getDateCreated()    { return this.DateCreated; }
        public DateTime     getLastAccess()     { return this.LastAccess; }

        public bool         isEnabled()         { return (this.Banned ? false : this.Enabled); }
        public bool         isBanned()          { return this.Banned; }


        // Methods
        public bool hasCustomID()               { return string.IsNullOrWhiteSpace(this.CUID); }


        public IUserAccount(int ID, string Username, IUserLevel AuthLevel, string Email, bool Enabled, DateTime DateCreated, DateTime LastAccess, string CUID = null, bool Banned = false) {
            this.ID             = ID;
            this.CUID           = CUID;         // Hidden Personalised Username     (Used for Logging In with more security: OPTIONAL)
            this.Username       = Username;     // Public Username                  (USED BY DEFAULT)
            this.AuthLevel      = AuthLevel;
            this.Email          = Email;
            this.DateCreated    = DateCreated;
            this.LastAccess     = LastAccess;
            this.Enabled        = Enabled;
            this.Banned         = Banned;
        }
    }

    public class IUserResult {
        public IUserAccount User;
        public bool         Exists = false;
    }

    public class UserEngine {
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
    }
}
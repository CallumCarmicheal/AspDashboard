using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDashboard.Classes.Authentication {
    public class Register {
        private UserEngine ue = new UserEngine();

        public bool RegisterUser(string Username, string Password, string Email, string FullName) {
            if(!ue.userExists(Username))
                return Register_AfterCheck(Username, Password, Email, FullName);
            return false;
        }

        public bool Register_AfterCheck(string Username, string Password, string Email, string FullName) {
            MySql.Data.MySqlClient.MySqlConnection con = null;
            Database.Configuration.open(ref con);

            string sql = @"
                INSERT INTO `users`(`level`, `state`, `username`, `email`, `password`, `realname`) 
                VALUES (@level, @state, @username, @email, @password, @realname)";

            var defaultLevel = Util.Config.Get().GetInt32("registration_default_authlevel", 2);
            var defaultState = Util.Config.Get().GetInt32("registration_default_state",     0);

            using (var rdr = new MySql.Data.MySqlClient.MySqlCommand(sql, con)) {
                rdr.Parameters.AddWithValue("@level",       defaultLevel);
                rdr.Parameters.AddWithValue("@state",       defaultState);

                rdr.Parameters.AddWithValue("@username",    Username);
                rdr.Parameters.AddWithValue("@realname",    FullName);

                rdr.Parameters.AddWithValue("@email",       Email);
                rdr.Parameters.AddWithValue("@password",    Password);
                
                try {
                    rdr.ExecuteNonQuery(); // Let it throw a error so i can see if it works
                } catch(Exception ex) {
                    throw;
                    return false;
                }
            } con.Close();
            return true;
        }
    }
}
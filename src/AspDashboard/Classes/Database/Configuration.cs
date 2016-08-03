using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AspDashboard.Classes.Database {
    public class Configuration {

        public static string Username   = "calpanel";
        public static string Password   = "";
        
        public static string Host       = "localhost";
        public static string Database   = "calpanel_v5";
        public static int    Port       = 3307;

        public static string toString() {
            if (string.IsNullOrWhiteSpace(Password)) {
                return string.Format("Server={0};Port={1};Database={2};Uid={3};Convert Zero Datetime=True", Host, Port, Database, Username);

            } else {
                return string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};Convert Zero Datetime=True", Host, Port, Database, Username, Password);
            }
        }

        public static bool open(ref MySqlConnection con) {
            try {
                con = new MySqlConnection(toString());
                con.Open();

                AppVariables.Loggers.Info.WriteLineClass("Database.Configuration", "open", "Opening Connection: " + con.State.ToString());
                return (con.State == System.Data.ConnectionState.Open);
            } catch (MySqlException ex) {
                AppVariables.Loggers.Info.WriteLineClass("Database.Configuration", "open", "Error while opening connection: " + ex.Message);
                throw;

                //HttpContext.Current.Response.Clear();
                //HttpContext.Current.Response.Write("MYSQL ERROR: " + ex.Message + "<br>REQUEST STRING: " + toString());
                //HttpContext.Current.Response.Close();


                //#if (DEBUG)
                //    throw ex;
                //#endif

                return false;
            }
        }
    }
}
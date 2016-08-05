using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDashboard.Classes.Database {
    public class ReaderHelper {
        public static bool ReadViaOrdianal(MySql.Data.MySqlClient.MySqlDataReader rdr, string Column, out string Result) {
            try {
                var ordinal = rdr.GetOrdinal(Column);
                var tmp = rdr.GetString(ordinal);
                Result = tmp;
                return true;
            } catch {
                Result = "";
                return false;
            }
        }

        public static bool ReadViaOrdianal(MySql.Data.MySqlClient.MySqlDataReader rdr, string Column, out int Result) {
            try {
                var ordinal = rdr.GetOrdinal(Column);
                var tmp = rdr.GetInt32(ordinal);
                Result = tmp;
                return true;
            } catch {
                Result = -1;
                return false;
            }
        }

        public static bool ReadViaOrdianal(MySql.Data.MySqlClient.MySqlDataReader rdr, string Column, out DateTime Result) {
            try {
                var ordinal = rdr.GetOrdinal(Column);
                var tmp = rdr.GetString(ordinal);

                DateTime dt;
                DateTime.TryParse(tmp, out dt);
                Result = dt;
                return true;
            } catch {
                Result = DateTime.Now;
                return false;
            }
        }
    }
}
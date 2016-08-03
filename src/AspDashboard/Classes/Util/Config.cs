using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDashboard.Classes.Util {
    public class Config {
        private Dictionary<string, string> Values;

        private bool ReloadIfNull = false;
        
        public Config(Dictionary<string, string> cfg) {
            this.Values = cfg;
            ReloadIfNull = GetBool("framework_config_missing_reload", false);
        }

        public bool ContainsKey(string Key, bool Reloaded = false) {
            var valid = Values.Keys.Contains(Key);

            if (!Reloaded && ReloadIfNull) {
                if (!valid) { lock (Values) { Values = getConfigData(); } }
                valid = Values.Keys.Contains(Key);
            } return valid;
        }

        public int GetInt32(string key, int Default = 0) {
            if (!ContainsKey(key)) return Default;
            try {
                int x;
                int.TryParse(Values[key], out x);
                return x;
            } catch {
                return Default;
            }
        }

        public string GetString(string key, string Default = null) {
            if (!ContainsKey(key)) return Default;
            return Values[key];
        }

        public bool GetBool(string key, bool Default = false) {
            if (!ContainsKey(key)) return Default;

            string[] validList = {
                "y",    "Y",
                "Yes",  "yes",
                "1",    "+"
            }; return validList.Contains(Values[key]);
        }

        public void SetString(string key, string value) {
            // TODO: UPDATE DATABASE AND SET STRING
        }

        public static void Refresh() {
            var ctx = HttpContext.Current;
            var tmp = getConfigData();
            var cfg = new Config(tmp);

            var reloadInMinutes = 30;

            ctx.Cache.Remove("DashboardConfig");
            ctx.Cache.Insert("DashboardConfig", cfg, null, DateTime.Now.AddMinutes(reloadInMinutes), TimeSpan.Zero);
        }

        private static Dictionary<string, string> getConfigData() {
            // Query database for settings
            MySql.Data.MySqlClient.MySqlConnection con = null;
            Database.Configuration.open(ref con);

            var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM aspdashboard_settings", con);
            var rdr = cmd.ExecuteReader();

            var tmp = new Dictionary<string, string>();

            while (rdr.Read()) tmp.Add(rdr.GetString(1), rdr.GetString(2));
            rdr.Close();
            con.Close();

            return tmp;
        }

        public static Config Get() {
            var ctx = HttpContext.Current;
            if (ctx.Cache["DashboardConfig"] == null)
                   Refresh();
            return ctx.Cache["DashboardConfig"] as Config;
        }
    }
}
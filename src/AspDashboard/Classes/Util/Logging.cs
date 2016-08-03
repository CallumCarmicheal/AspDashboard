using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDashboard.Classes.Util {

    public class LogConfig {
        public string       Category;
        public bool         Enabled;
        public bool         PrintToDebug;
        public bool         WriteLog;
        public bool         PrependDate;
    }

    public class Log {
        private LogConfig cfg;
        public LogConfig getConfig() { return this.cfg; }

        public Log(LogConfig log) {
            this.cfg = log;
        }

        private string getDate() {
            if(cfg.PrependDate)
                 return DateTime.Now.ToString("MM-dd-yy HH-MM-ss");
            else return "";
        }


        public void WriteLine(string Section, string Message) {
            if(!cfg.Enabled) return;

            string format = "({Date} [{Category}]) [{Section}] {Message}";
            format = format.
                Replace("{Date}",       getDate()).
                Replace("{Category}",   cfg.Category).
                Replace("{Section}",    Section).
                Replace("{Message}",    Message);
            

            if(cfg.PrintToDebug) System.Diagnostics.Debugger.Log(0, cfg.Category, format);
        }

        public void WriteLineCtrl(string Controller, string Action, string Message) {
            if (!cfg.Enabled) return;

            string format = "({Date} [{Category}]) [{Controller}.{Action}] {Message}\n";
            format = format.
                Replace("{Date}", getDate()).
                Replace("{Category}", cfg.Category).
                Replace("{Controller}", Controller).
                Replace("{Action}", Action).
                Replace("{Message}", Message);


            if (cfg.PrintToDebug) System.Diagnostics.Debugger.Log(0, cfg.Category, format);
        }
    }

    public class Logging {
        public Log Info; // Only one for now
        public Log Debug;
        public Log Error;


        public Logging() {

            Info = new Log(new LogConfig() {
                Enabled         = true,
                Category        = "Info",
                PrependDate     = true,
                PrintToDebug    = true,
                WriteLog        = false
            });

        }


        

    }
}
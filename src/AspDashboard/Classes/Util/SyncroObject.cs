using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDashboard.Classes.Util {
    /// <summary>
    /// SyncroObject is a simple class thats only objective is to create a synchronous object that can be used
    /// from multiple locations and be edited at will when ever needed, this object is ideal for cases such as 
    /// having a single string to store a dynamic variable inside the cache that can be edited without the worry
    /// of it being locked etc.
    /// </summary>
    public class SynchroObject {
        public object Value;
    }
}
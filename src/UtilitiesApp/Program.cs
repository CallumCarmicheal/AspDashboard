using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilitiesApp {
    class Test {
        public string Val = "";
    }

    static class Program {
        
        public static void Tamper(Test testObj) {
            testObj.Val += " - Tampered!";
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            Console.WriteLine("C# Object reference testing: "); {
                List<Test> lists = new List<Test>();

                lists.Add(new Test() { Val = "Test0" });
                lists.Add(new Test() { Val = "Test1" });

                foreach (var obj in lists)
                    Console.WriteLine($"\tBefore Tampering: Test.Val = {obj.Val}");
                Tamper(lists[0]);

                var test = lists[1]; Tamper(test);
                foreach (var obj in lists)
                    Console.WriteLine($"\tAfter  Tampering: Test.Val = {obj.Val}");
            }
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
    }
}

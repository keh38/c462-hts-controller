using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTSController
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool launchedByDashboard = args.Contains("--launched-by-dashboard");
            
            if (!launchedByDashboard && Process.GetProcessesByName("game-dashboard").Length > 0)
            {
                MessageBox.Show(
                    "The Game Dashboard is already running.\n\n" +
                    "Only one controller application can run at a time. " +
                    "Please close the Game Dashboard before launching HTSController.",
                    "Cannot Start — Conflict Detected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}

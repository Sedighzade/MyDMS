using PNB.Helpers;
using System;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Windows.Forms;

namespace PNB.SAS
{
    static class Program
    {
        static SApp app;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProfileOptimization.SetProfileRoot("MyAppFolder");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //long j = DateTime.Now.Ticks;
            //System.Threading.Thread.Sleep(2000);
            //TimeSpan ts = TimeSpan.FromTicks(DateTime.Now.Ticks - j);

            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                if (lang.LayoutName == "Persian")
                {
                    Application.CurrentInputLanguage = lang;
                    break;
                }
            Application.ThreadException += Application_ThreadException;

            Initialize();

            //app = new SApp();
            //app.Start();

            Application.Run(new frmTestCases());
            Configuration.Messengr.Stop();
        }
        private static void Initialize()
        {
            ///always first!
            Configuration.AppPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            ///create Data folder
            Archive.Archive.CreateFolderStructure();
            Configuration.Messengr.Init();
            Configuration.Messengr.Start();

            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Fatal Error!\n\nMessage:\n" + e.Exception.ToString() + "\n\nYour data is safe.\nMyDMS will terminate now!"
                , "my DMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}

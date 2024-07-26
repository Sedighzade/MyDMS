using PNB.Helpers;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PNB.MyDMS
{
	static class Program
	{
		static App app;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string DocDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

			foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
				if (lang.LayoutName == "Persian")
				{
					Application.CurrentInputLanguage = lang;
					break;
				}
			Application.ThreadException += Application_ThreadException;
			try
			{
				Initialize();
				app = new MyDMS.App();
				app.Start();
			}
			catch (Exception ee) { }
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			return null;
		}

		private static void Initialize()
		{
			///always first!
			Configuration.AppPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			//Configuration.Messengr.Init();
			//Configuration.Messengr.Start();

			Logger.SaveDebug2Disk = true;
			Logger.App = "MyDMS";
			Directory.CreateDirectory(Configuration.GetDebugDir());

			if (File.Exists(Logger.App))
				File.Delete(Logger.App);
		}
		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			MessageBox.Show("Fatal Error!\n\nMessage:\n" + e.Exception.ToString() + "\n\nYour data is safe.\nMyDMS will terminate now!"
				, "my DMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Application.Exit();
		}
	}
}

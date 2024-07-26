using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PNB.Helpers
{
	public class Logger
	{
		static long logCount = 0;
		public const int MaxItem = 15000;

		static string appFile = "";
		static object olockLOG2Disk = new object();
		static object logLock = new object();


		public static bool Log2Console { set; get; }
		public static bool SaveDebug2Disk { set; get; }
		public static bool SeperateLogFiles { set; get; }
		public static string App
		{
			set
			{
				appFile = Configuration.GetDebugDir() + value + "_debug.txt";
			}
			get { return appFile; }
		}


		public static void StartMonitor()
		{
			long filesize = 1024 * 1024 * 100;
			ThreadPool.QueueUserWorkItem(delegate
			{
				while (!Configuration.GlobalShutDown)
				{
					string[] folders = Directory.GetDirectories(Configuration.GetLogDir());
					foreach (string f in folders)
					{
						if (f.EndsWith(Defs.Dir_LogBackup)) continue;

						string[] files = Directory.GetFiles(f);
						foreach (string file in files)
						{
							FileInfo fi = new FileInfo(file);
							if (fi.Length > filesize)
							{

							}
						}
					}
					Thread.Sleep(10000);
				}
			});
		}

		public static void Log(object obj, string dir)
		{
			Directory.CreateDirectory(Configuration.GetLogDir() + dir + Path.DirectorySeparatorChar);
			if (obj != null)
				LogToFile(obj.ToString(), dir + Path.DirectorySeparatorChar);
		}
		public static void Log(object message)
		{
			if (message != null)
				LogToFile(message.ToString(), string.Empty);
		}
		private static void LogToFile(string msg, string targetDir)
		{
			Logger.Debug("Error: " + msg);
			string lFile = string.Empty;
			DateTime dt = DateTime.Now;

			lock (logLock)
				logCount++;
			string file2 = "";
			try
			{
				string folder = Configuration.GetLogDir() + targetDir;
				Directory.CreateDirectory(folder);

				if (SeperateLogFiles)
				{
					lFile = string.Format("{0}.log", Util.ConvertDateTimeToFileName(dt, true));
					using (StreamWriter sw = new StreamWriter(folder + lFile))
						sw.WriteLine(msg);
				}
				else
				{
					lFile = Defs.LogFile;
					string finalLFile = folder + lFile;
					string content = string.Format("{0}\t{1}\n\n", dt.ToString("HH:mm:ss.ffffff"), msg);
					File.AppendAllText(finalLFile, content);

					if (Time2Backup(finalLFile))
					{
						file2 = folder + Util.ConvertDateTimeToFileName(dt, false) + "-" + lFile;
						string arg = $"\"{folder}{Path.GetFileName(file2)}.7z\" \"{folder}{Path.GetFileName(file2)}\" \"{Configuration.GetLogBackupDir()}\"";

						lock (logLock)
						{
							File.Move(finalLFile, file2);
						}
						Process.Start(Configuration.GetScriptDir() + "zip.bat", arg);

						logCount = 0;
					}
				}

			}
			catch (Exception eeee)
			{
				Log(eeee);
			}
		}
		static int len = 1024 * 1024 * 50;
		private static bool Time2Backup(string file)
		{
			if (logCount > 100)
			{
				FileInfo fi = new FileInfo(file);
				bool ff = fi.Length > len;
				return ff;
			}
			return false;
		}

		public static void Debug(object message)
		{
			if (message == null) return;
			string content = string.Format("{0}\t\t{1}\n", DateTime.Now.ToString("HH:mm:ss.ffffff"), message);
			Console.Write(content);

			if (SaveDebug2Disk)
			{
				lock (olockLOG2Disk)
					File.AppendAllText(appFile, content);
			}
		}
		public static void DeleteDebugFile()
		{
			if (File.Exists(appFile))
				File.Delete(appFile);
		}
		public static int GetLogCount()
		{
			int lll = 0;
			if (!Directory.Exists(Configuration.GetLogDir()))
				return lll;

			lll = Directory.GetFiles(Configuration.GetLogDir()).Length;

			return lll;
		}
		public static void Log2WindowsEventLog()
		{
			// Create an EventLog instance and assign its source.
			EventLog myLog = new EventLog();
			myLog.Source = "MySource";

			// Write an informational entry to the event log.    
			myLog.WriteEntry("Writing to event log.");

		}
		public static void CreateWindowsEventSource()
		{
			if (!EventLog.SourceExists("PNB"))
			{
				//An event log source should not be created and immediately used.
				//There is a latency time to enable the source, it should be created
				//prior to executing the application that uses the source.
				//Execute this sample a second time to use the new source.
				EventLog.CreateEventSource("MySource", "MyNewLog");
				//Logger.Debug("CreatedEventSource");
				//Logger.Debug("Exiting, execute the application a second time to use the source.");
				// The source is created.  Exit the application to allow it to be registered.
				return;
			}
		}
	}



	//public class Messenger
	//{
	//    public class MessengerListview : ListView
	//    {
	//        Messenger m;
	//        ColumnHeader columnHeader1;
	//        ColumnHeader columnHeader2;
	//        ColumnHeader columnHeader3;
	//        public MessengerListview(Messenger messenger)
	//        {
	//            this.m = messenger;
	//            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
	//                | ControlStyles.AllPaintingInWmPaint, true);
	//            GridLines = FullRowSelect = true;
	//            View = View.Details;
	//            Dock = DockStyle.Fill;

	//            columnHeader1 = new ColumnHeader();
	//            columnHeader2 = new ColumnHeader();
	//            columnHeader3 = new ColumnHeader();

	//            this.columnHeader1.Text = "Message";
	//            this.columnHeader1.Width = 600;
	//            this.columnHeader2.Text = "Originator";
	//            this.columnHeader2.Width = 80;
	//            this.columnHeader3.Text = "Time";
	//            this.columnHeader3.Width = 80;
	//            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
	//            { this.columnHeader1, this.columnHeader2, this.columnHeader3 });

	//            //m.Send = delegate (object sender, List<Messenger.MessengerData> lst)
	//            //{
	//            //    if (lst.Count == 0) return;

	//            //    List<Messenger.MessengerData> msgs = new List<Messenger.MessengerData>();
	//            //    msgs.AddRange(lst);
	//            //    ThreadPool.QueueUserWorkItem(delegate
	//            //    {
	//            //        List<ListViewItem> items = new List<ListViewItem>();

	//            //        foreach (Messenger.MessengerData m in msgs)
	//            //        {
	//            //            ListViewItem item = new ListViewItem(m.Message);
	//            //            item.SubItems.Add(m.Originator);
	//            //            item.SubItems.Add(Utility.ConvertTimeToString(m.Time, true));
	//            //            item.UseItemStyleForSubItems = true;

	//            //            if (m.Severity == Severity.Info)
	//            //                item.BackColor = Color.AliceBlue;
	//            //            else if (m.Severity == Severity.Error)
	//            //                item.BackColor = Color.Red;
	//            //            else if (m.Severity == Severity.Warning)
	//            //                item.BackColor = Color.Orange;
	//            //            else if (m.Severity == Severity.Important)
	//            //                item.BackColor = Color.LimeGreen;

	//            //            items.Add(item);
	//            //        }

	//            //        try
	//            //        {
	//            //            Invoke((MethodInvoker)delegate ()
	//            //                            {
	//            //                                lock (this)
	//            //                                {
	//            //                                    if (Items.Count > Logger.MaxItem)
	//            //                                        Items.Clear();
	//            //                                    Items.AddRange(items.ToArray());
	//            //                                }
	//            //                            });
	//            //        }
	//            //        catch (Exception rr)
	//            //        {
	//            //        }

	//            //    });
	//            //};
	//        }
	//    }
	//    public class MessengerData
	//    {
	//        public MessengerData(string originator, string message, Severity sev)
	//        {
	//            Originator = originator;
	//            Message = message;
	//            Time = DateTime.Now.Ticks;
	//            Severity = sev;
	//        }
	//        public string Originator { set; get; }
	//        public string Message { set; get; }
	//        public long Time { set; get; }
	//        public Severity Severity { set; get; }
	//    }

	//    #region Fields
	//    //public event EventHandler<List<MessengerData>> Send;
	//    MessengerListview m;
	//    List<MessengerData> list;
	//    List<MessengerData> listOut;
	//    object locker;
	//    bool shutdown;
	//    #endregion

	//    public MessengerListview View { get { return m; } }

	//    public Messenger()
	//    {
	//        list = new List<MessengerData>();
	//        listOut = new List<MessengerData>();
	//        shutdown = false;
	//        locker = new object();
	//        m = new MessengerListview(this);

	//    }
	//    public void Init()
	//    {
	//    }

	//    #region Message Logger
	//    public void Start()
	//    {
	//        ThreadPool.QueueUserWorkItem(delegate { SendOut(); });
	//    }
	//    public void Stop()
	//    {
	//        shutdown = true;

	//        Thread.Sleep(1000);
	//        Save(list);
	//    }

	//    private void SendOut()
	//    {
	//        List<MessengerData> lst1 = new List<MessengerData>();
	//        while (!shutdown)
	//        {
	//            lock (locker)
	//            {
	//                if (listOut.Count > 0)
	//                {
	//                    //if (Send != null)
	//                    //{ Send(null, listOut); }
	//                    listOut.Clear();
	//                }
	//            }
	//            Thread.Sleep(1000);
	//        }
	//    }
	//    public void SendMessage(string originator, string message)
	//    {
	//        SendMessage(originator, message, Severity.Info);
	//    }
	//    public void SendMessage(string originator, string message, Severity severity)
	//    {
	//        lock (locker)
	//        {
	//            MessengerData m = new MessengerData(originator, message, severity);
	//            list.Add(m);
	//            listOut.Add(m);

	//            //Save to disk
	//            if (list.Count > Logger.MaxItem)
	//            {
	//                List<MessengerData> l1 = new List<MessengerData>();
	//                l1.AddRange(list);
	//                list.Clear();
	//                ThreadPool.QueueUserWorkItem(Save, l1);
	//            }
	//        }
	//    }
	//    private void Save(object data)
	//    {
	//        List<MessengerData> lst = data as List<MessengerData>;
	//        StringBuilder sb = new StringBuilder();
	//        sb.AppendFormat("PNB Messenger File\n\n\nVersion:1.0\nTOC:{0}\n\n", Util.ConvertDateTimeToFileName(false));

	//        foreach (MessengerData md in lst)
	//            sb.AppendFormat("{0}\t{1}\t{2}t{3}", md.Time, md.Message, md.Originator, md.Severity);
	//        string fn = Configuration.GetAppPath() + Util.ConvertDateTimeToFileName(DateTime.Now, false);
	//        try
	//        {
	//            File.WriteAllText(fn, sb.ToString());
	//        }
	//        catch (Exception ee) { Logger.Log(ee); }
	//    }
	//    #endregion
	//}
	public enum Severity { Info, Warning, Error, Important }
}

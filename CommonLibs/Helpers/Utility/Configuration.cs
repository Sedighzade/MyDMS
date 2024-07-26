using System;
using System.IO;

namespace PNB.Helpers
{
	public class Configuration
	{
		/// <summary>
		/// Default value is wlan0
		/// </summary>
		public static string NetworkInterfaceName { set; get; } = Defs.NetworkInterface;
		public static void DetectPlatform()
		{
			Util.IsLinux = !System.Environment.OSVersion.ToString().Contains("Microsoft");
			Util.IsWindows = System.Environment.OSVersion.ToString().Contains("Microsoft");
		}
		public static bool SaveBatteryData { set; get; }


		/// <summary>
		/// in seconds
		/// </summary>
		public static int TimeBroadcastInterval { set; get; } = 30;
		public static bool GlobalShutDown { set; get; }
		public static string ConnectionString { set; get; }

		public static string AppPath { set; get; }

		//static Messenger m = new Messenger();

		//public static Messenger Messengr
		//{
		//    get
		//    {
		//        return m;
		//    }
		//}

		/// <summary>
		/// Default = 10 sec
		/// </summary>
		public static double DataProcessInterval { get; set; } = 10;
		static string piRamDiskDir = "/run/user/1000/";
		public static string GetRamDiskDir()
		{
			if (Util.IsLinux)
				return piRamDiskDir;
			return piRamDiskDir;
			// GetTempDir() + Defs.Dir_RamDiskMountPoint + Path.DirectorySeparatorChar;
		}
		public static string GetScriptDir()
		{
			return GetAppPath() + Defs.Dir_Scripts + Path.DirectorySeparatorChar;
		}

		/// <summary>
		/// ../Data/
		/// </summary>
		/// <returns></returns>
		public static string GetDataDir()
		{
			return GetAppPath() + Defs.Dir_Data + Path.DirectorySeparatorChar;
		}
		/// <summary>
		/// Ends to Directory Separator Char
		/// </summary>
		/// <returns></returns>
		public static string GetAppPath()
		{
			return AppPath + Path.DirectorySeparatorChar;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static string GetDBFile()
		{
			return GetDataDir() + "db.mdf";
		}
		public static string GetSessionsFile()
		{
			return GetDataDir() + Defs.SessionsFile;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static string GetSessionsDataDir()
		{
			return GetConfDir() + Defs.FtpSessionDataDir;
		}
		public static string GetSessionsDataBackupDir()
		{
			return GetSessionsDataDir() + Path.DirectorySeparatorChar + "BacupFiles" + Path.DirectorySeparatorChar;
		}
		/// <summary>
		/// Ends to \
		/// </summary>
		/// <returns></returns>
		public static string GetBackupDir()
		{
			return GetAppPath() + Defs.Dir_Backup + Path.DirectorySeparatorChar;
		}
		public static string GetSMVDataDir()
		{
			string dir = GetAppPath() + Defs.Dir_Data
					  + Path.DirectorySeparatorChar + Defs.Dir_SMV + Path.DirectorySeparatorChar;
			return dir;
		}
		/// <summary>
		/// wpa_supplicant
		/// </summary>
		/// <returns></returns>
		public static string GetWPA_Supplicant()
		{
			return GetScriptDir() + Defs.wpa_supplicantTemplate;
		}
		public static string GetPythonPath()
		{
			return "/usr/bin/python";
		}
		public static string GetRFIDScriptPath()
		{
			string res = "";
			res = GetAppPath()
						  + "rfid"
						  + Path.DirectorySeparatorChar
						  + "mfrc522"
						  + Path.DirectorySeparatorChar
						  + "gt.py";
			return res;
		}
		/// <summary>
		/// $confPath/settings.dms
		/// </summary>
		/// <returns></returns>
		public static string GetSettingFilePath()
		{
			return Configuration.GetConfDir() + Defs.ConfigurationFile;
		}
		/// <summary>
		/// settings.ini
		/// </summary>
		/// <returns></returns>
		public static string GetConfigFilePath()
		{
			return GetConfDir()
				+ Path.DirectorySeparatorChar
				+ Defs.SettingsFile1;
		}
		public static string GetConfDir()
		{
			return Configuration.GetAppPath() + Defs.Dir_conf + Path.DirectorySeparatorChar;
		}
		public static string GetDBBackupFilePath()
		{
			return Configuration.GetScriptDir() + Defs.DBBackupBatchFile;
		}
		public static string GetLogDir()
		{
			return Configuration.GetAppPath() + Defs.Dir_Logs + Path.DirectorySeparatorChar;
		}
		public static string GetLogBackupDir()
		{
			return Configuration.GetLogDir() + Defs.Dir_LogBackup + Path.DirectorySeparatorChar;
		}
		public static string GetTempDir()
		{
			return Configuration.GetAppPath() + Defs.Dir_Temp + Path.DirectorySeparatorChar;
		}
		public static string GetSystemTempDir()
		{
			string tmp = "";
			if (Util.IsLinux)
				tmp = Configuration.GetAppPath() + Defs.Dir_Temp + Path.DirectorySeparatorChar;
			else if (Util.IsWindows)
			{
				tmp = Configuration.GetAppPath() + Defs.Dir_Temp + Path.DirectorySeparatorChar;
			}

			return tmp;
		}
		public static string GetImageDir()
		{
			return Configuration.GetAppPath() + Defs.Dir_Image + Path.DirectorySeparatorChar;
		}
		public static string GetLogoDir()
		{
			return Configuration.GetImageDir() + Defs.Dir_Logo + Path.DirectorySeparatorChar;
		}
		public static string GetToolsDir()
		{
			return Configuration.GetAppPath() + Defs.Dir_Tools + Path.DirectorySeparatorChar;
		}

		public static string GetdhcpcdFilePath()
		{
			return Configuration.GetScriptDir() + Defs.dechcp_conf;

		}

		public static string GetDebugDir()
		{
			return Configuration.GetAppPath() + Defs.Dir_Debug + Path.DirectorySeparatorChar;
		}
	}
}

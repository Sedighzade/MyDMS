using System;

namespace PNB.Helpers
{
	public class Defs
	{
		public const string LCDOrientation = "LCDOrient";
		/// <summary>
		/// ;
		/// </summary>
		public static char[] Splitter1 = { ';' };
		/// <summary>
		/// ,
		/// </summary>
		public static char[] Splitter2 = { ',' };
		/// <summary>
		/// -
		/// </summary>
		public static char[] Splitter3 = { '-' };
		/// <summary>
		/// _
		/// </summary>
		public static char[] Splitter4 = { '_' };
		/// <summary>
		/// =
		/// </summary>
		public static char[] Splitter5 = { '=' };
		/// <summary>
		/// :
		/// </summary>
		public static char[] Splitter6 = { ':' };
		/// <summary>
		/// >
		/// </summary>
		public static char[] Splitter7 = { '>' };
		/// <summary>
		/// ===
		/// </summary>
		public static string[] Splitter8 = { "===" };
		/// <summary>
		/// tab space
		/// </summary>
		public static string[] Splitter9 = { "\t" };
		static string[] sp10 = new string[] { Environment.NewLine };
		static string[] sp13 = new string[] { "\n" };
		/// <summary>
		/// Environment.NewLine
		/// </summary>
		public static string[] Splitter10 = sp10;
		/// <summary>
		/// '\n'
		/// </summary>
		public static string[] Splitter13 = sp13;
		/// <summary>
		/// Space
		/// </summary>
		public static string Splitter11 = " ";
		/// <summary>
		/// Online History Start Day
		/// </summary>
		public const string OnlineHistoryStartDay = "OnlineHistoryStartDay";
		public const string dechcp_conf = "dhcpcd.conf";

		/// <summary>
		/// wpa_cp
		/// </summary>
		public const string script_wpa_cp = "wpa_cp";
		/// <summary>
		/// reset
		/// </summary>
		public const string script_reset = "reset";
		/// <summary>
		/// camera
		/// </summary>
		public const string script_camera = "camera";
		/// <summary>
		/// conf
		/// </summary>
		public const string Dir_conf = "conf";
		/// <summary>
		/// scripts
		/// </summary>
		public const string Dir_Scripts = "scripts";
		/// <summary>
		/// Logs
		/// </summary>
		public const string Dir_Logs = "Logs";
		/// <summary>
		/// Logs.log
		/// </summary>
		public const string LogFile = "Logs.log";
		/// <summary>
		/// LogBackups
		/// </summary>
		public const string Dir_LogBackup = "LogBackups";
		/// <summary>
		/// wpa_passphrase
		/// </summary>
		public const string script_wpa_passphrase = "wpa_passphrase";
		/// <summary>
		/// wpa_supplicant.conf
		/// </summary>
		public const string wpa_supplicant = "wpa_supplicant.conf";
		/// <summary>
		/// wpa_supplicant
		/// </summary>
		public const string wpa_supplicantTemplate = "wpa_supplicant";
		/// <summary>
		/// Messenger
		/// </summary>
		public const string Dir_Messenger = "Messenger";
		/// <summary>
		/// Backup
		/// </summary>
		public const string Dir_Backup = "Backup";
		/// <summary>
		/// Data
		/// </summary>
		public const string Dir_Data = "Data";
		/// <summary>
		/// DataFiles
		/// </summary>
		public const string FtpSessionDataDir = "DataFiles";
		/// <summary>
		/// SMV
		/// </summary>
		public const string Dir_SMV = "SMV";
		/// <summary>
		/// Debug
		/// </summary>
		public const string Dir_Debug = "Debug";
		/// <summary>
		/// 6060
		/// </summary>
		public const int DefaultTerminalLocalBindPort = 6060;
		/// <summary>
		/// 7070
		/// </summary>
		public const int DefaultServerPort = 7070;
		/// <summary>
		/// 8080
		/// </summary>
		public const int ServiceWatcherPort = 8080;
		/// <summary>
		/// Loopback
		/// </summary>
		public const string LoopBack = "127.0.0.1";
		/// <summary>
		/// CS
		/// </summary>
		public const string ConnectionString = "CS";
		/// <summary>
		/// settings.dms
		/// </summary>
		public const string ConfigurationFile = "settings.dms";
		/// <summary>
		/// Setup.zip
		/// </summary>
		public const string AppFile = "Setup.zip";
		/// <summary>
		/// sessions.txt
		/// </summary>
		public const string SessionsFile = "sessions.txt";
		/// <summary>
		/// settings.ini
		/// </summary>
		public const string SettingsFile1 = "settings.ini";
		/// <summary>
		/// battery.txt
		/// </summary>
		public const string BatterySettingsFile = "battery.txt";
		/// <summary>
		/// 
		/// </summary>
		public const string DBBackupBatchFile = "db_backup.bat";
		/// <summary>
		/// tempImages
		/// </summary>
		public const string Dir_TempImage = "tempImages";
		/// <summary>
		/// temp
		/// </summary>
		public const string Dir_Temp = "temp";
		/// <summary>
		/// Images
		/// </summary>
		public const string Dir_Image = "Images";
		/// <summary>
		/// Tools
		/// </summary>
		public const string Dir_Tools = "Tools";
		/// <summary>
		/// BR100
		/// </summary>
		public const string Database_Name = "BR100";
		/// <summary>
		/// asu
		/// </summary>
		public const string AutomaticSettingUpdate = "asu";

		/// <summary>
		/// -100
		/// </summary>
		public const long ServiceSerialNo = -100;
		/// <summary>
		/// -
		/// </summary>
		public const string EmptyField = "-";
		/// <summary>
		/// Logo
		/// </summary>
		public const string Dir_Logo = "Logo";
		/// <summary>
		/// TBI
		/// </summary>
		public const string TimeBoradCastInterval = "TBI";
		/// <summary>
		/// br100_ramdisk
		/// </summary>
		public const string Dir_RamDiskMountPoint = "br100_ramdisk";
		/// <summary>
		/// br100_ramdisk_
		/// </summary>
		public const string Dir_RamDiskMountName = "br100_ramdisk_";

		public const string NetworkInterface = "wlan0";
	}
}

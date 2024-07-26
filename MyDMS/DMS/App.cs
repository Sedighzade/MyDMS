using MyDMS.DMS;
using MyDMS.Secretariat;
using PNB.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace PNB.MyDMS
{
	public class App
	{
		Settings settings = null;
		public const string SettingsFile = "settings.dms";

		internal void Start()
		{
			if ((settings = Load(Configuration.AppPath)) == null)
				settings = new Settings();

			settings.TemporaryData.AppPath = Configuration.AppPath;


			try
			{
				Application.Run(new frmMain(this));
			}
			catch (Exception rr)
			{
				MessageBox.Show(rr.ToString(), "my DMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
				PNB.Helpers.Logger.Log(rr);
			}
			Save(settings);
		}

		public Settings Load(string path)
		{
			Settings s = null;

			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = null;
			System.IO.FileStream fs = null;

			if (!File.Exists(path + "\\" + SettingsFile))
				return null;
			try
			{
				fs = System.IO.File.Open(path + "\\" + SettingsFile, FileMode.Open, FileAccess.Read, FileShare.None);
				bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				bf.Binder = new FormaterBinder();
				s = bf.Deserialize(fs) as Settings;
			}
			catch (Exception ee)
			{
				PNB.Helpers.Logger.Log(ee);
			}
			finally
			{
				if (fs != null)
					fs.Close();
			}
			return s;
		}

		public void Save(Settings s)
		{
			if (s == null)
				return;
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = null;
			System.IO.FileStream bw = null;

			string srcTemp = Path.GetTempPath() + SettingsFile;
			string current = s.TemporaryData.AppPath + "\\" + SettingsFile;
			string current_backup = Configuration.GetBackupDir() + SettingsFile + "  " + Util.ConvertDateTimeToFileName(DateTime.Now, false);

			try
			{
				bw = System.IO.File.Create(srcTemp);
				bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				bf.Serialize(bw, s);
				bw.Close();

				Directory.CreateDirectory(PNB.Helpers.Configuration.GetBackupDir());

				///move current to backup fodler
				if (File.Exists(current))
				{
					File.Move(current, current_backup);
					File.Delete(current);
				}
				File.Move(srcTemp, current);
				File.Delete(srcTemp);
			}
			catch (Exception ee)
			{
				PNB.Helpers.Logger.Log(ee);
			}
			finally
			{
				if (bw != null)
					bw.Close();
			}
		}

		#region Properties
		public Settings AppSettings { get { return settings; } }
		#endregion

	}

	internal class FormaterBinder : SerializationBinder
	{
		public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
		{
			typeName = assemblyName = "";
		}
		public override Type BindToType(string assemblyName, string typeName)
		{
			if (typeName == "MyDMS.Secretariat.OEntity")
				return typeof(OEntity);
			if (typeName == "MyDMS.Secretariat.People")
				return typeof(People);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[MyDMS.Secretariat.People,"))
				return typeof(List<People>);
			else if (typeName == "MyDMS.Secretariat.Office")
				return typeof(Office);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[MyDMS.Secretariat.Office"))
				return typeof(List<Office>);
			else if (typeName == "MyDMS.DMS.Settings")
				return typeof(Settings);
			else if (typeName == "MyDMS.Secretariat.Organization")
				return typeof(Organization);
			else if (typeName == "MyDMS.Secretariat.Secretarait")
				return typeof(Secretarait);
			else if (typeName == "PNB.MyDMS.BOM")
				return typeof(BOM);
			else if (typeName == "PNB.MyDMS.Inventory")
				return typeof(Inventory);
			else if (typeName == "MyDMS.Secretariat.Letter")
				return typeof(Letter);
			else if (typeName == "MyDMS.Secretariat.Mission")
				return typeof(Mission);
			//else if (typeName == "MyDMS.DMS.Invoice")
			//	return typeof(Invoice);
			else if (typeName == "PNB.MyDMS.BOMProject")
				return typeof(BOMProject);
			else if (typeName == "MyDMS.Secretariat.Letter+Direction")
				return typeof(Letter.Direction);
			else if (typeName == "MyDMS.Secretariat.Letter+LetterType")
				return typeof(Letter.LetterType);
			else if (typeName == "PNB.MyDMS.Item")
				return typeof(Item);
			else if (typeName == "PNB.MyDMS.ItemInfo")
				return typeof(ItemInfo);
			else if (typeName == "MyDMS.Secretariat.Call")
				return typeof(Call);
			else if (typeName == "PNB.MyDMS.BomPrice")
				return typeof(BomPrice);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[System.String,"))
				return typeof(List<string>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[MyDMS.Secretariat.Organization"))
				return typeof(List<Organization>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[MyDMS.Secretariat.Letter"))
				return typeof(List<Letter>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[MyDMS.Secretariat.Mission"))
				return typeof(List<Mission>);
			//else if (typeName.StartsWith("System.Collections.Generic.List`1[[MyDMS.DMS.Invoice"))
			//	return typeof(List<Invoice>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[PNB.MyDMS.BOMProject"))
				return typeof(List<BOMProject>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[PNB.MyDMS.Item,"))//do not remove comma
				return typeof(List<Item>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[PNB.MyDMS.ItemInfo"))
				return typeof(List<ItemInfo>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[MyDMS.Secretariat.Call"))
				return typeof(List<Call>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[PNB.MyDMS.BomPrice"))
				return typeof(List<BomPrice>);
			else if (typeName.StartsWith("System.Collections.Generic.List`1[[MyDMS.Secretariat.OEntity"))
				return typeof(List<OEntity>);
			return null;
		}
	}
}

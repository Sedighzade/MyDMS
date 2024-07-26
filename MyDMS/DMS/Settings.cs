using MyDMS.Secretariat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyDMS.DMS
{
	[Serializable]
	public class Settings
	{
		List<string> paths = new List<string>();
		[NonSerialized]
		TempData td = null;
		Secretarait sec;
		PNB.MyDMS.BOM bom;
		public bool MaximizeMainWindow { set; get; }
		public Settings()
		{
			init();
		}
		void init()
		{
			if (td == null)
				td = new TempData();
			if (sec == null)
				sec = new Secretarait();
			if (bom == null)
				bom = new PNB.MyDMS.BOM();
		}

		public Secretarait SecretariatData { get { return sec; } }
		public PNB.MyDMS.BOM BOM { get { return bom; } }
		public TempData TemporaryData { get { return td; } }
		public List<string> Paths { get { return paths; } }
		[OnDeserializedAttribute]
		public void OnDeserialized(StreamingContext context)
		{
			init();
		}
	}


	[Serializable]

	public class TempData
	{
		public string AppPath { set; get; }
	}
}

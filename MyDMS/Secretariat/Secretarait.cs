using MyDMS.DMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyDMS.Secretariat
{
	[Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
	public class Secretarait
	{
		[NonSerialized]
		Serial serial = null;
		public int LastUsedSerial { set; get; }
		List<Organization> organizations = new List<Organization>();
		List<Letter> letters = new List<Letter>();
		List<Mission> missions = new List<Mission>();

		public Secretarait()
		{
			LastUsedSerial = 1;
			serial = new Serial(this);
		}
		public void IncreaseSerial() { LastUsedSerial++; }
		public void ResetSerial()
		{
			LastUsedSerial = 1;
		}

		[Browsable(true)]
		public List<Letter> Letters { get { return letters; } }
		[Browsable(true)]
		public List<Organization> Organizations { get { return organizations; } }

		public Serial SerialLetter { get { return serial; } }



		[OnDeserializedAttribute]
		public void OnDeserialized(StreamingContext context)
		{
			if (LastUsedSerial == 0)
				LastUsedSerial = 1;

			if (missions == null)
				missions = new List<Mission>();

			serial = new Serial(this);//non-serializable
		}
	}
}

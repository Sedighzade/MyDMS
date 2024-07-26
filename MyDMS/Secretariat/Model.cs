using PNB.Common;
using PNB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MyDMS.Secretariat
{
	public interface Model
	{
		string Serial { set; get; }
		long CreationDate { set; get; }
		long SendDate { set; get; }
		string Subject { set; get; }
		string Text { set; get; }
		string Code { set; get; }
	}

	[Serializable]
	public class Letter : Model
	{
		public enum Direction { Outgoing, Incoming }
		public enum LetterType { External, Internal }
		long id;
		public Letter()
		{
			LetterDirection = Direction.Outgoing;
			id = PNB.Helpers.Util.GetLong();
		}
		public override string ToString()
		{
			return this.Subject;
		}

		#region Properties        
		public Direction LetterDirection { set; get; }
		public LetterType LetterType1 { set; get; }
		[ReadOnly(true)]
		public long ID { get { return id; } }
		public string CreationDateString { get { return PersianCalendar.GregorianToJalali(CreationDate, true); } }
		public string SendDateString { get { return PersianCalendar.GregorianToJalali(SendDate, true); } }
		public string Code
		{
			get;
			set;
		}
		[Browsable(false)]
		public long CreationDate
		{
			get;
			set;
		}
		[Browsable(false), DisplayName("Date")]
		public long SendDate
		{
			get;
			set;
		}
		//[ReadOnly(true)]
		public long Organization { set; get; }
		public string Subject
		{
			get;
			set;
		}
		public string Serial
		{
			get;
			set;
		}

		public string AttachedFile { set; get; }
		public string Text
		{
			get;
			set;
		}
		#endregion
	}

	[Serializable]
	public class Organization
	{
		public const string Unknown = "Unknown";
		//List<OEntity> offices22 = new List<OEntity>();
		List<OEntity> enties = new List<OEntity>();
		List<Call> calls = new List<Call>();

		List<Office> offices = new List<Office>();
		List<People> people = new List<People>();

		long id;


		[Browsable(false)] public List<Call> Calls { get { return calls; } }
		public Organization()
		{
			this.Name = Unknown;
			id = PNB.Helpers.Util.GetLong();
			CreatetionDate = DateTime.Now.Ticks;
		}
		public Organization(long OrgId)
		{
			this.id = OrgId;
			this.Name = Unknown;
			CreatetionDate = DateTime.Now.Ticks;
		}
		[DisplayName("Web site")]
		public string WebSite { set; get; }
		//public List<People> Members { get { return people; } }
		[ReadOnly(true)]
		public long ID { get { return id; } set { id = value; } }
		[DisplayName("تاریخ ساخت")]
		public string CreatetionDateString { get { return PersianCalendar.GregorianToJalali(CreatetionDate, true); } }

		[Browsable(false)]
		public long CreatetionDate { set; get; }
		[ReadOnly(true)] public string Name { set; get; }
		public List<OEntity> Entities { get { return enties; } }

		public override string ToString()
		{
			return Name;
		}

		[OnDeserializedAttribute]
		public void OnDeserialized(StreamingContext context)
		{
			if (calls == null)
				calls = new List<Call>();
			if (enties == null)
				enties = new List<OEntity>();

			long id = ID;

			Logger.Debug($"Org:{Name}. ID:{ID}. CD:{PersianCalendar.GregorianToJalali(CreatetionDate, true)}");


			enties.ForEach(e =>
			{
				if (e.CreatetionDate == 0)
					e.CreatetionDate = CreatetionDate;
			});
			//people.ForEach(p =>
			//{
			//	Logger.Debug($"\t\tPerson:{p.Name}. ID:{p.ID}. CD:{Helpers.PersianCalendar.GregorianToJalali(p.CreatetionDate, true)}");
			//	OEntity oe = new OEntity()
			//	{
			//		CreatetionDate = p.CreatetionDate,
			//		ID = p.ID,
			//		Name = p.Name,
			//		Email = p.Email,
			//		Owner = ID
			//	};
			//	enties.Add(oe);
			//});
			offices.ForEach(o =>
			{
				Logger.Debug($"\t\tPerson:{o.Name}. ID:{o.ID}.");

				OEntity oe = new OEntity()
				{
					ID = o.ID,
					Name = o.Name,
					Email = o.Email,
					Deleted = false,
					Fax = o.Fax,
					Note = o.Note,
					Owner = ID,
					BankAccount = o.BankAccount,
					PhoneNumbers = o.PhoneNumbers,
					POBox = o.POBox,
					TaxCode = o.TaxCode,
					URI = o.URI,
					CreatetionDate = CreatetionDate
				};
				enties.Add(oe);
			});
			offices.Clear();
		}
		[ReadOnly(true), DisplayName("Click#")] public int ClickedTimes { set; get; }
	}

	[Serializable]
	public class Call
	{
		public Call()
		{
			CreatetionDate = DateTime.Now.Ticks;
		}

		[Browsable(false)] public long PreviousCall { set; get; }
		[Browsable(false)] public long NextCall { set; get; }
		public string Subject { set; get; }
		public string Description { set; get; }
		public long CreatetionDate { set; get; }
		public string CallDateString { get { return PersianCalendar.GregorianToJalali(CreatetionDate, true); } }

		public long OE { get; internal set; }
		public string AttachedFilePath { get; internal set; }
	}

	[Serializable]
	public class OEntity : IDName
	{
		public OEntity()
		{
			CreatetionDate = DateTime.Now.Ticks;
		}
		[Category("Data")] public string PhoneNumbers { set; get; }
		[Category("Data")] public string Fax { set; get; }
		[Category("Data")] public string Email { set; get; }
		[Category("Data")] public string Note { set; get; }
		[Category("Data")] public string POBox { set; get; }
		[DisplayName("Web Site"), Category("Data")] public string URI { set; get; }
		[DisplayName("Tax Code"), Category("Data")] public string TaxCode { set; get; }
		[DisplayName("Bank Account"), Category("Data")] public string BankAccount { set; get; }
		[DisplayName("Creation Date-Time"), Category("General")] public string CreatetionDateString { get { return PersianCalendar.GregorianToJalali(CreatetionDate, true); } }
		[ReadOnly(true), Category("General")] public long Owner { set; get; }
		[Browsable(false)] public long CreatetionDate { set; get; }

		public override string ToString()
		{
			return Name;
		}
	}

	public class Serial
	{
		Secretarait sec;
		public Serial(Secretarait secretarait)
		{
			sec = secretarait;
		}
		public enum SerialMethod { M1, M2 }
		public string GetLetterSerialCode(SerialMethod method, object data)
		{
			string s = "";
			switch (method)
			{
				case SerialMethod.M1:
					{
						long dtNow = ((DateTime)data).Ticks;
						s = string.Format("{0}{1}-{2:D2}"
							, PersianCalendar.GetJalaliYear(dtNow)
							, PersianCalendar.GetJalaliMonth(dtNow), sec.LastUsedSerial);
					}
					break;
				case SerialMethod.M2:
					break;
			}
			return s;
		}
	}


	[Serializable]
	public class Office
	{
		//List<string> phoneNumbers = new List<string>();
		//List<string> addresses = new List<string>();

		public Office()
		{
			ID = PNB.Helpers.Util.GetLong();
			Name = "New Office";
		}

		[Browsable(false)]
		public long ID { set; get; }
		public string Name { set; get; }
		[DisplayName("Web Site")]
		public string URI { set; get; }
		//public List<string> PhoneNumbers { get; set; }
		public string PhoneNumbers { set; get; }
		//public List<string> Addresses { get; set; }
		public string Email { set; get; }
		public string Note { set; get; }
		public string POBox { set; get; }
		[DisplayName("Tax Code")]
		public string TaxCode { set; get; }
		[DisplayName("Bank Account")]
		public string BankAccount { set; get; }
		public string Fax { set; get; }
		public override string ToString()
		{
			return Name;
		}
	}
	[Serializable]
	public class People
	{
		long id = 0;
		public People()
		{
			id = PNB.Helpers.Util.GetLong();
			CreatetionDate = DateTime.Now.Ticks;
		}
		public string Name { set; get; }

		[Browsable(false)]
		public long CreatetionDate { set; get; }
		[Browsable(false)]
		public long ID { get { return id; } }
		public string Email { set; get; }
	}
}

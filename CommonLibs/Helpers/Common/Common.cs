using System;
using System.ComponentModel;

namespace PNB.Common
{
	public interface IIDName
	{
		long ID { set; get; }
		string Name { set; get; }
	}
	[Serializable]
	public class IDName : IIDName
	{
		static readonly Random rnd = new Random();
		static readonly double max1 = 100000000000000000;
		static long GetLong()
		{
			//long l = 0;
			byte[] buf = new byte[8];
			rnd.NextBytes(buf);
			long longRand = (long)(rnd.NextDouble() * max1);
			//long longRand = BitConverter.ToInt64(buf, 0);
			//l = (Math.Abs(longRand % (max - min)) + min);
			//return l;
			return longRand;
		}
		public IDName()
		{
			ID = GetLong();
		}
		public virtual void SetName(string newName)
		{
			Name = newName;
		}
		[Category("General"), ReadOnly(true)] public long ID { set; get; }
		[Category("General"), ReadOnly(true)] public string Name { set; get; }
		[Category("General"), ReadOnly(true)] public bool Deleted { set; get; }
		public override string ToString()
		{
			return Name;
		}
	}
	public enum Actions { Add, Delete, Edit, Rename, Load, Clear }
}

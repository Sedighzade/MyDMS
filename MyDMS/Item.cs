using PNB.Common;
using PNB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PNB.MyDMS
{
	[Serializable]
	public class BOM
	{
		Inventory inventory = new Inventory();
		List<BOMProject> projects = new List<BOMProject>();

		public BOM()
		{

		}
		public List<BOMProject> Projects { get { return projects; } }
		public Inventory Warehouse { get { return inventory; } }


		[OnDeserializedAttribute]
		public void OnDeserialized(StreamingContext context)
		{
			if (inventory == null)
				inventory = new Inventory();
		}
	}


	[Serializable]
	public class BOMProject : IDName
	{
		List<Item> items = new List<Item>();
		public BOMProject(string name)
		{
			SetName(name);
		}
		public List<Item> Items { get { return items; } }

		internal long GetTotalPrice()
		{
			long l = 0;

			items.ForEach(i =>
			{
				BomPrice p = i.Info.GetLastPrice();
				l += (p != null ? p.Price : 0) * i.Count;
			});

			return l;
		}
	}


	[Serializable]
	public class Inventory
	{
		List<Item> items = new List<Item>();
		List<ItemInfo> iitems = new List<ItemInfo>();

		public List<ItemInfo> ItemInfos { get { return iitems; } }


		public List<Item> Items { get { return items; } }
	}





	[Serializable]
	public class ItemInfo : IDName
	{
		List<BomPrice> historical_prices = new List<BomPrice>();
		public List<BomPrice> HistoricalPrices { get { return historical_prices; } }
		public long DateDefined { set; get; }

		internal BomPrice GetLastPrice()
		{
			return historical_prices.Count == 0 ? null : historical_prices[historical_prices.Count - 1];
		}

		internal BomPrice GetPriceAt(long v)
		{
			throw new NotImplementedException();
		}
	}


	[Serializable]
	public class Item : IDName
	{

		/// p is one time assigned value. When item is created it is assigned and will never 
		/// changes coz we need price at the time of the item creation.
		BomPrice p;


		ItemInfo ii;

		public Item(ItemInfo info, BomPrice price)
		{
			p = price;
			DateAdded = DateTime.Now.Ticks;
			Count = 1;
			ii = info;
		}

		public ItemInfo Info { get { return ii; } }
		[DisplayName("Date Added")]
		public string DateAddedString { get { return PersianCalendar.GregorianToJalali(DateAdded, false); } }
		[Browsable(false)]
		public long DateAdded { set; get; }
		public int Count { get; set; }
		public BomPrice Price { get { return p; } }
		public override string ToString()
		{
			return this.ii.Name;
		}
	}






	[Serializable]
	public class BomPrice : IDName
	{
		public BomPrice(long price)
		{
			this.Price = price;
		}
		public long DateAdded { set; get; }
		public long Price { set; get; }
	}
}

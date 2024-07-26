using System;

namespace PNB.Helpers
{
	public class PersianCalendar
	{
		#region Fields
		public static char[] Splitter = { '/' };
		//private static string day;
		//private static string month;
		//private static string year;
		#endregion

		#region Methods    
		private static int div(int a, int b)
		{
			return (int)(a / b);
		}
		private static int div(long a, int b)
		{
			return (int)(a / b);
		}
		public static string GregorianToJalali(long ticks, bool IncludeTime)
		{
			string day, month, year;
			long jd;
			long jm;
			long jy;
			int i;
			DateTime dt = new DateTime(ticks);
			//string strdelimiter = "/";
			//string[] dateSeperated;
			//char[] delimiter = strdelimiter.ToCharArray();

			int g_y = dt.Year;// Convert.ToInt16(dateSeperated[0]);
			int g_m = dt.Month;// Convert.ToInt16(dateSeperated[1]);
			int g_d = dt.Day;// Convert.ToInt16(dateSeperated[2]);

			int[] g_days_in_month = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
			int[] j_days_in_month = new int[12] { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29 };

			int gy = g_y - 1600;
			int gm = g_m - 1;
			int gd = g_d - 1;

			long g_day_no = 365 * gy + div(gy + 3, 4) - div(gy + 99, 100) + div(gy + 399, 400);

			for (i = 0; i < gm; ++i)
				g_day_no += g_days_in_month[i];
			if (gm > 1 && ((gy % 4 == 0 && gy % 100 != 0) || (gy % 400 == 0)))
				/* leap and after Feb */
				g_day_no++;
			g_day_no += gd;

			long j_day_no = g_day_no - 79;

			int j_np = div(j_day_no, 12053); /* 12053 = 365*33 + 32/4 */
			j_day_no = j_day_no % 12053;

			jy = 979 + 33 * j_np + 4 * div(j_day_no, 1461); /* 1461 = 365*4 + 4/4 */

			j_day_no %= 1461;

			if (j_day_no >= 366)
			{
				jy += div(j_day_no - 1, 365);
				j_day_no = (j_day_no - 1) % 365;
			}

			for (i = 0; i < 11 && j_day_no >= j_days_in_month[i]; ++i)
				j_day_no -= j_days_in_month[i];

			jm = i + 1;
			jd = j_day_no + 1;

			if (jd < 10)
				day = "0" + jd.ToString();
			else
				day = jd.ToString();

			if (jm < 10)
				month = "0" + jm.ToString();
			else
				month = jm.ToString();

			year = jy.ToString();

			string h = "";
			if (IncludeTime)
				h = string.Format("{0}-{1}-{2} - {3}", year, month, day, dt.ToString("HH.mm.ss"));
			else
				h = string.Format("{0}-{1}-{2}", year, month, day);

			return h;
		}
		public static string GregorianToJalali(string georgian, string strdelimiter, bool IncludeTime)
		{
			string day, month, year;
			long jd;
			long jm;
			long jy;
			int i;
			string[] dateSeperated;

			char[] delimiter = strdelimiter.ToCharArray();

			dateSeperated = georgian.Split(delimiter, 3);
			int g_y = Convert.ToInt16(dateSeperated[0]);
			int g_m = Convert.ToInt16(dateSeperated[1]);
			int g_d = Convert.ToInt16(dateSeperated[2]);

			int[] g_days_in_month = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
			int[] j_days_in_month = new int[12] { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29 };

			int gy = g_y - 1600;
			int gm = g_m - 1;
			int gd = g_d - 1;


			long g_day_no = 365 * gy + div(gy + 3, 4) - div(gy + 99, 100) + div(gy + 399, 400);

			for (i = 0; i < gm; ++i)
				g_day_no += g_days_in_month[i];
			if (gm > 1 && ((gy % 4 == 0 && gy % 100 != 0) || (gy % 400 == 0)))
				/* leap and after Feb */
				g_day_no++;
			g_day_no += gd;

			long j_day_no = g_day_no - 79;

			int j_np = div(j_day_no, 12053); /* 12053 = 365*33 + 32/4 */
			j_day_no = j_day_no % 12053;

			jy = 979 + 33 * j_np + 4 * div(j_day_no, 1461); /* 1461 = 365*4 + 4/4 */

			j_day_no %= 1461;

			if (j_day_no >= 366)
			{
				jy += div(j_day_no - 1, 365);
				j_day_no = (j_day_no - 1) % 365;
			}

			for (i = 0; i < 11 && j_day_no >= j_days_in_month[i]; ++i)
				j_day_no -= j_days_in_month[i];

			jm = i + 1;
			jd = j_day_no + 1;

			if (jd < 10)
				day = "0" + jd.ToString();
			else
				day = jd.ToString();

			if (jm < 10)
				month = "0" + jm.ToString();
			else
				month = jm.ToString();

			year = jy.ToString();

			return year + "-" + month + "-" + day;
		}
		public static string JalaliToGregorian(string jalali, string strdelimiter)
		{
			string day, month, year;
			string[] dateSeperated;

			char[] delimiter = strdelimiter.ToCharArray();

			dateSeperated = jalali.Split(delimiter, 3);
			int j_y = Convert.ToInt16(dateSeperated[0]);
			int j_m = Convert.ToInt16(dateSeperated[1]);
			int j_d = Convert.ToInt16(dateSeperated[2]);

			int[] g_days_in_month = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
			int[] j_days_in_month = new int[12] { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29 };

			int i;
			int jy = j_y - 979;
			int jm = j_m - 1;
			int jd = j_d - 1;
			bool leap;
			int gm;
			int gy;

			long j_day_no = 365 * jy + div(jy, 33) * 8 + div(jy % 33 + 3, 4);
			for (i = 0; i < jm; ++i)
				j_day_no += j_days_in_month[i];

			j_day_no += jd;

			long g_day_no = j_day_no + 79;

			gy = 1600 + 400 * div(g_day_no, 146097); /* 146097 = 365*400 + 400/4 - 400/100 + 400/400 */
			g_day_no = g_day_no % 146097;

			leap = true;
			if (g_day_no >= 36525) /* 36525 = 365*100 + 100/4 */
			{
				g_day_no--;
				gy += 100 * div(g_day_no, 36524); /* 36524 = 365*100 + 100/4 - 100/100 */
				g_day_no = g_day_no % 36524;

				if (g_day_no >= 365)
					g_day_no++;
				else
					leap = false;
			}

			gy += 4 * div(g_day_no, 1461); /* 1461 = 365*4 + 4/4 */
			g_day_no %= 1461;

			if (g_day_no >= 366)
			{
				leap = false;

				g_day_no--;
				gy += div(g_day_no, 365);
				g_day_no = g_day_no % 365;
			}

			for (i = 0; g_day_no >= g_days_in_month[i] + Convert.ToInt32((i == 1 && leap)); i++)
				g_day_no -= g_days_in_month[i] + Convert.ToInt32((i == 1 && leap));
			gm = i + 1;
			long gd = g_day_no + 1;

			if (gd < 10)
				day = "0" + gd.ToString();
			else
				day = gd.ToString();

			if (gm < 10)
				month = "0" + gm.ToString();
			else
				month = gm.ToString();

			year = gy.ToString();

			return year + "/" + month + "/" + day;
		}
		public static string GetJalaliMonth(long dt)
		{
			string m = GregorianToJalali(dt, true).Substring(5, 2);
			return m;
		}
		public static string GetJalaliName(string jalaiDate)
		{
			if (string.IsNullOrEmpty(jalaiDate))
				return jalaiDate;
			string[] chunks = jalaiDate.Split(Splitter);
			if (chunks.Length != 3)
				return "Error";
			int day = int.Parse(chunks[2]);
			string dayName = "";
			switch (day)
			{
				case 0:
					dayName = "يكشنبه";
					break;
				case 1:
					dayName = "دوشنبه";
					break;
				case 2:
					dayName = "سه شنبه";
					break;
				case 3:
					dayName = "چهارشنبه";
					break;
				case 4:
					dayName = "پنج شنبه";
					break;
				case 5:
					dayName = "جمعه";
					break;
				case 6:
					dayName = "شنبه";
					break;
			}
			return dayName;
		}
		public static string GetJalaliDay(long ticks)
		{
			return GregorianToJalali(ticks, true).Substring(8, 2);
		}
		public static string GetJalaliYear(long ticks)
		{
			string h = GregorianToJalali(ticks, true).Substring(0, 4);
			return h;
		}
		#endregion

		#region Properties
		public static string JalaliDayName
		{
			get
			{
				DayOfWeek today = DateTime.Today.DayOfWeek;
				string t = "";
				switch ((int)today)
				{
					case 0:
						t = "يكشنبه";
						break;
					case 1:
						t = "دوشنبه";
						break;
					case 2:
						t = "سه شنبه";
						break;
					case 3:
						t = "چهارشنبه";
						break;
					case 4:
						t = "پنج شنبه";
						break;
					case 5:
						t = "جمعه";
						break;
					case 6:
						t = "شنبه";
						break;
				}
				return t;
			}
		}
		public static string TodayJalali
		{
			get
			{
				return GregorianToJalali(DateTime.Now.Ticks, true);
			}
		}
		#endregion
	}
}

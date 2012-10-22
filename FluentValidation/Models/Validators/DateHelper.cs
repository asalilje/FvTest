using System;
using System.Globalization;

namespace FVTest.Models.Validators
{
	public class DateHelper
	{
		public static bool IsValidDate(string dateString, out DateTime resultDate)
		{
			var dateFormats = new[] { @"yyyy-MM-dd", @"yy-MM-dd", @"yyyyMMdd", @"yyMMdd" };
			var cultureInfo = new CultureInfo("sv-SE");
			var isValid = DateTime.TryParseExact(dateString, dateFormats, cultureInfo, DateTimeStyles.None, out resultDate);
			return isValid;
		} 
	}
}
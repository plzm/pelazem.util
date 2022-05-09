using System;
using System.Collections.Generic;
using System.Text;

namespace pelazem.util
{
	/// <summary>
	/// FORMAT_* strings should be wrapped in an appropriate string format expression, for example:
	/// string.Format("" + Constants.FORMAT_CURRENCY + "", someString);
	/// </summary>
	public struct Constants
	{
		public const string FORMAT_CURRENCY = "c";

		public const string FORMAT_DATE = "d";
		public const string FORMAT_DATETIME_US = "G";
		public const string FORMAT_DATETIME_ISO8601 = "O"; // "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";
		public const string FORMAT_TIME = "HH:mm";
	}
}

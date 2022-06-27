using System;
using System.Collections.Generic;
using System.Text;

namespace pelazem.util
{
	public static class Converter
	{
		/// <summary>
		/// Returns a bool for the passed value, if value can be converted. If not, false is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool GetBool(object value)
		{
			bool retVal = false;

			try
			{
				retVal = Convert.ToBoolean(value);
			}
			catch
			{
				bool result = bool.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns a DateTime for the passed value, if value can be converted. If not, minimum DateTime value is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static DateTime GetDateTime(object value)
		{
			DateTime retVal = DateTime.MinValue;

			try
			{
				retVal = Convert.ToDateTime(value);
			}
			catch
			{
				bool result = DateTime.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Given a string representation of a time span in a useful part or all of d.hh:mm:ss.mmm, returns a corresponding TimeSpan.
		/// Simple strings like 2:37 are interpreted to mean 2 minutes and 37 seconds. This is DIFFERENT from TimeSpan.Parse default, which would interpret that as 2 hours and 37 minutes.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static TimeSpan GetTimeSpan(string value)
		{
			TimeSpan retVal = TimeSpan.Zero;

			if (!string.IsNullOrWhiteSpace(value))
			{
				// first check if someone passed only seconds, and if so > 60 which we'll need to convert to normal time notation
				int secondsOnly = GetInt32(value);

				if (secondsOnly > 60)
				{
					int actualSeconds = secondsOnly % 60;
					double rawActualMinutes = GetDouble(secondsOnly) / 60;
					int actualMinutes = GetInt32(rawActualMinutes);

					value = actualMinutes.ToString() + ":" + (actualSeconds < 10 ? "0" : string.Empty) + actualSeconds.ToString();
				}

				int colonCount = value.Length - value.Replace(":", "").Length;

				if (colonCount == 0)
					value = "00:00:" + value;
				else if (colonCount == 1)
					value = "00:" + value;

				bool result = TimeSpan.TryParse(value, out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns a Decimal for the passed value, if value can be converted. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Decimal GetDecimal(object value)
		{
			Decimal retVal = 0;

			try
			{
				retVal = Convert.ToDecimal(value);
			}
			catch
			{
				bool result = Decimal.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns a double for the passed value, if value can be converted. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Double GetDouble(object value)
		{
			Double retVal = 0;

			try
			{
				retVal = Convert.ToDouble(value);
			}
			catch
			{
				bool result = Double.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns a GUID for the passed value, if value can be converted to GUID. If not, empty GUID is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Guid GetGuid(object value)
		{
			Guid retVal = Guid.Empty;

			try
			{
				retVal = new Guid(value.ToString());
			}
			catch
			{
				bool result = Guid.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns a 16-bit integer (short) for the passed value, if value can be converted. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Int16 GetInt16(object value)
		{
			Int16 retVal = 0;

			try
			{
				retVal = Convert.ToInt16(value);
			}
			catch
			{
				bool result = Int16.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns an unsigned 16-bit integer for the passed value, if value can be converted. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static UInt16 GetUInt16(object value)
		{
			UInt16 retVal = 0;

			try
			{
				retVal = Convert.ToUInt16(value);
			}
			catch
			{
				bool result = UInt16.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns a 32-bit int for the passed value, if value can be converted. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Int32 GetInt32(object value)
		{
			Int32 retVal = 0;

			try
			{
				retVal = Convert.ToInt32(value);
			}
			catch
			{
				bool result = Int32.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns an unsigned 32-bit integer for the passed value, if value can be converted. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static UInt32 GetUInt32(object value)
		{
			UInt32 retVal = 0;

			try
			{
				retVal = Convert.ToUInt32(value);
			}
			catch
			{
				bool result = UInt32.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns a 64-bit int for the passed value, if value can be converted to int. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Int64 GetInt64(object value)
		{
			Int64 retVal = 0;

			try
			{
				retVal = Convert.ToInt64(value);
			}
			catch
			{
				bool result = Int64.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns an unsigned 64-bit integer for the passed value, if value can be converted. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static UInt64 GetUInt64(object value)
		{
			UInt64 retVal = 0;

			try
			{
				retVal = Convert.ToUInt64(value);
			}
			catch
			{
				bool result = UInt64.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}

		/// <summary>
		/// Returns a float (single) for the passed value, if value can be converted. If not, zero is returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Single GetSingle(object value)
		{
			float retVal = 0;

			try
			{
				retVal = Convert.ToSingle(value);
			}
			catch
			{
				bool result = float.TryParse(value.ToString().Trim(), out retVal);

				if (!result)
					retVal = default;
			}

			return retVal;
		}
	}
}

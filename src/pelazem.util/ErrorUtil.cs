using System;
using System.Collections.Generic;
using System.Text;

namespace pelazem.util
{
	public static class ErrorUtil
	{
		public static string GetText(Exception ex)
		{
			if (ex == null)
				return string.Empty;

			string result;

			try
			{
				StringBuilder sb = new();

				sb.AppendLine(Properties.Resources.Type + ": " + ex.GetType().Name);
				sb.AppendLine(Properties.Resources.Source + ": " + ex.Source);
				sb.AppendLine(Properties.Resources.Message + ": " + ex.Message);
				sb.AppendLine(Properties.Resources.StackTrace + ":");
				sb.AppendLine(ex.StackTrace);

				if (ex.InnerException != null)
				{
					sb.AppendLine(Properties.Resources.InnerException + ":");
					sb.AppendLine(GetText(ex.InnerException));
				}

				result = sb.ToString();
			}
			catch
			{
				result = Properties.Resources.ErrorMsgCouldNotGetExceptionText;
			}

			return result;
		}

		public static string GetText(object errorObject)
		{
			if (errorObject == null)
				return string.Empty;

			string result;

			try
			{
				result =
					Properties.Resources.Type + ": " + errorObject.GetType().Name + Environment.NewLine +
					Properties.Resources.Text + ": " + Environment.NewLine + errorObject.ToString() + Environment.NewLine +
					Properties.Resources.StackTrace + ":" + Environment.NewLine +
					Environment.StackTrace + Environment.NewLine;
			}
			catch
			{
				result = Properties.Resources.ErrorMsgCouldNotGetErrorText;
			}

			return result;
		}
	}
}

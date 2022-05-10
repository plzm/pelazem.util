using System;
using System.Collections.Generic;
using System.Text;

namespace pelazem.util
{
	public static class ErrorUtil
	{
		public static string GetText(Exception ex)
		{
			string result = string.Empty;

			try
			{
				StringBuilder sb = new StringBuilder();

				sb.AppendLine(Properties.Resources.Type + ": " + ex.GetType().Name);
				sb.AppendLine(Properties.Resources.Source + ": " + ex.Source);
				sb.AppendLine(Properties.Resources.Message + ": " + ex.Message + Environment.NewLine);
				sb.AppendLine(Properties.Resources.StackTrace + ":" + Environment.NewLine + ex.StackTrace + Environment.NewLine);

				if (ex.InnerException != null)
				{
					sb.AppendLine();
					sb.AppendLine(Properties.Resources.InnerException + ":");
					sb.AppendLine(GetText(ex.InnerException));
				}

				sb.AppendLine();

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

			string result = string.Empty;

			try
			{
				result =
					Properties.Resources.Type + ": " + errorObject.GetType().Name + Environment.NewLine +
					Properties.Resources.Text + ": " + Environment.NewLine + errorObject.ToString() + Environment.NewLine +
					Properties.Resources.StackTrace + ": " + Environment.NewLine + Environment.StackTrace + Environment.NewLine;
			}
			catch
			{
				result = Properties.Resources.ErrorMsgCouldNotGetErrorText;
			}

			return result;
		}
	}
}

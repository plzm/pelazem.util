using System;
using System.Collections.Generic;
using System.Text;

namespace pelazem.util
{
	public static class EncodingExtensionMethods
	{
		private static readonly char paddingChar = '=';
		static readonly char[] paddingChars = { paddingChar };
		private static readonly string paddingString = new(paddingChar, 1);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encoding"></param>
		/// <param name="text"></param>
		/// <param name="makeFileUrlPathSafe">If true, cleans the result as follows: 1. strips padding at end | 2. replaces + (plus) with - (minus) | 3. Replaces / (slash) with _ (underscore)</param>
		/// <returns></returns>
		public static string EncodeBase64(this Encoding encoding, string text, bool makeFileUrlPathSafe = false)
		{
			if (string.IsNullOrWhiteSpace(text))
				return string.Empty;

			byte[] textAsBytes = encoding.GetBytes(text);

			string result = Convert.ToBase64String(textAsBytes);

			if (makeFileUrlPathSafe)
			{
				result = result
					.TrimEnd(paddingChars)
					.Replace('+', '-')
					.Replace('/', '_');
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encoding"></param>
		/// <param name="encodedText"></param>
		/// <param name="reverseFileUrlPathSafe">If true, reverses the safety measures optionally added by EncodeBase64() by adding back padding, replacing - with +, and replacing _ with / prior to decoding.</param>
		/// <returns></returns>
		public static string DecodeBase64(this Encoding encoding, string encodedText, bool reverseFileUrlPathSafe = false)
		{
			byte[] bytes;
			string result = string.Empty;

			if (string.IsNullOrWhiteSpace(encodedText))
				return result;

			if (!reverseFileUrlPathSafe)
				bytes = Convert.FromBase64String(encodedText);
			else
			{
				string raw = encodedText
					.Replace('-', '+')
					.Replace('_', '/');

				// Add padding at end if not there already
				if (!raw.EndsWith(paddingString))
				{
					switch (raw.Length % 4)
					{
						case 2:
							raw += new string(paddingChar, 2);
							break;
						case 3:
							raw += paddingString;
							break;
					}
				}

				bytes = Convert.FromBase64String(raw);
			}

			result = encoding.GetString(bytes);

			return result;
		}
	}
}

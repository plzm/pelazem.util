using System;
using System.Collections.Generic;
using System.Text;

namespace pelazem.util
{
	public static class EncodingExtensionMethods
	{
		private static readonly char paddingChar = '=';
		private static readonly string paddingString = new(paddingChar, 1);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encoding"></param>
		/// <param name="text"></param>
		/// <param name="makeFileUrlPathSafe">If true, cleans the encoded output as follows: 1. replaces + (plus) with - (minus) | 3. Replaces / (slash) with _ (underscore)</param>
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
					.Replace('+', '-')
					.Replace('/', '_')
				;
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encoding"></param>
		/// <param name="encodedText"></param>
		/// <param name="reverseFileUrlPathSafe">If true, reverses the safety measures optionally added by EncodeBase64() by replacing - with +, and replacing _ with / prior to decoding.</param>
		/// <returns></returns>
		public static string DecodeBase64(this Encoding encoding, string encodedText, bool reverseFileUrlPathSafe = false)
		{
			byte[] bytes;
			string result = string.Empty;

			if (string.IsNullOrWhiteSpace(encodedText))
				return result;

			// Add padding at end if encoded text length not a multiple of 4 and padding is not there already - have to pad so length % 4 = 0; see https://stackoverflow.com/a/36571117/140761
			if ((encodedText.Length % 4) != 0 && !encodedText.EndsWith(paddingString))
				encodedText += new string(paddingChar, 4 - (encodedText.Length % 4));

			if (!reverseFileUrlPathSafe)
				bytes = Convert.FromBase64String(encodedText);
			else
			{
				string raw = encodedText
					.Replace('-', '+')
					.Replace('_', '/');

				bytes = Convert.FromBase64String(raw);
			}

			result = encoding.GetString(bytes);

			return result;
		}
	}
}

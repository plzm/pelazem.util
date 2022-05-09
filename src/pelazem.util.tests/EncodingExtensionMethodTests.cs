using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class EncodingExtensionMethodTests
	{
		private static string _rawString = "D/General/Active-Special_Servicing/2011/WFRBS_2011-C4/Closing_Binder/22._WFB_–_Master_Servicer_-_Indemnification_Agreement.pdf";
		private static string _encodedStringSafe = "RC9HZW5lcmFsL0FjdGl2ZS1TcGVjaWFsX1NlcnZpY2luZy8yMDExL1dGUkJTXzIwMTEtQzQvQ2xvc2luZ19CaW5kZXIvMjIuX1dGQl_igJNfTWFzdGVyX1NlcnZpY2VyXy1fSW5kZW1uaWZpY2F0aW9uX0FncmVlbWVudC5wZGY";
		private static string _encodedStringUnsafe = "RC9HZW5lcmFsL0FjdGl2ZS1TcGVjaWFsX1NlcnZpY2luZy8yMDExL1dGUkJTXzIwMTEtQzQvQ2xvc2luZ19CaW5kZXIvMjIuX1dGQl/igJNfTWFzdGVyX1NlcnZpY2VyXy1fSW5kZW1uaWZpY2F0aW9uX0FncmVlbWVudC5wZGY=";

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void EmptyShouldReturnEmptyString(string value)
		{
			// Arrange

			// Act
			string result = Encoding.UTF8.EncodeBase64(value);

			// Assert
			Assert.True(result.Length == 0);
		}

		[Fact]
		public void RawShouldEncodeSafe()
		{
			// Arrange

			// Act
			string encoded = Encoding.UTF8.EncodeBase64(_rawString, true);

			// Assert
			Assert.Equal(_encodedStringSafe, encoded);
		}

		[Fact]
		public void RawShouldEncodeUnsafe()
		{
			// Arrange

			// Act
			string encoded = Encoding.UTF8.EncodeBase64(_rawString, false);

			// Assert
			Assert.Equal(_encodedStringUnsafe, encoded);
		}

		[Fact]
		public void SafeShouldDecodeRaw()
		{
			// Arrange

			// Act
			string raw = Encoding.UTF8.DecodeBase64(_encodedStringSafe, true);

			// Assert
			Assert.Equal(_rawString, raw);
		}

		[Fact]
		public void UnsafeShouldDecodeRawEvenSafe()
		{
			// Arrange

			// Act
			string raw = Encoding.UTF8.DecodeBase64(_encodedStringUnsafe, true);

			// Assert
			Assert.Equal(_rawString, raw);
		}

		[Fact]
		public void UnsafeShouldDecodeRaw()
		{
			// Arrange

			// Act
			string raw = Encoding.UTF8.DecodeBase64(_encodedStringUnsafe, false);

			// Assert
			Assert.Equal(_rawString, raw);
		}
	}
}

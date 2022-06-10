using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class EncodingExtensionMethodsTests
	{
		private const string _rawString = "D/Zoomout/Abcdef-Stuvwxy_Zyxwvutsr/9999/FGHIJ_9999-X9/Carrots_Nectar/99._YYY_–_Wisdom_Nutrient_-_Ggggggggggggggg_Zzzzzzzzz.yyy";
		private const string _encodedStringSafe = "RC9ab29tb3V0L0FiY2RlZi1TdHV2d3h5X1p5eHd2dXRzci85OTk5L0ZHSElKXzk5OTktWDkvQ2Fycm90c19OZWN0YXIvOTkuX1lZWV_igJNfV2lzZG9tX051dHJpZW50Xy1fR2dnZ2dnZ2dnZ2dnZ2dnX1p6enp6enp6ei55eXk=";
		private const string _encodedStringUnsafe = "RC9ab29tb3V0L0FiY2RlZi1TdHV2d3h5X1p5eHd2dXRzci85OTk5L0ZHSElKXzk5OTktWDkvQ2Fycm90c19OZWN0YXIvOTkuX1lZWV/igJNfV2lzZG9tX051dHJpZW50Xy1fR2dnZ2dnZ2dnZ2dnZ2dnX1p6enp6enp6ei55eXk=";

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void EmptyStringShouldReturnEmptyEncodedString(string value)
		{
			// Arrange

			// Act
			string result = Encoding.UTF8.EncodeBase64(value);

			// Assert
			Assert.True(result.Length == 0);
		}

		[Fact]
		public void RawStringShouldEncodeCorrectlyWithMakeFilePathSafe()
		{
			// Arrange

			// Act
			string encoded = Encoding.UTF8.EncodeBase64(_rawString, true);

			// Assert
			Assert.Equal(_encodedStringSafe, encoded);
		}

		[Fact]
		public void RawStringShouldEncodeCorrectlyWithoutMakeFilePathSafe()
		{
			// Arrange

			// Act
			string encoded = Encoding.UTF8.EncodeBase64(_rawString, false);

			// Assert
			Assert.Equal(_encodedStringUnsafe, encoded);
		}

		[Fact]
		public void EncodedSafeStringShouldDecodeCorrectlyWithFilePathReversal()
		{
			// Arrange

			// Act
			string raw = Encoding.UTF8.DecodeBase64(_encodedStringSafe, true);

			// Assert
			Assert.Equal(_rawString, raw);
		}

		[Fact]
		public void EncodedUnsafeStringShouldDecodeCorrectlyWithFilePathReversal()
		{
			// Arrange

			// Act
			string raw = Encoding.UTF8.DecodeBase64(_encodedStringUnsafe, true);

			// Assert
			Assert.Equal(_rawString, raw);
		}

		[Fact]
		public void EncodedUnsafeStringShouldDecodeCorrectlyWithoutFilePathReversal()
		{
			// Arrange

			// Act
			string raw = Encoding.UTF8.DecodeBase64(_encodedStringUnsafe, false);

			// Assert
			Assert.Equal(_rawString, raw);
		}
	}
}

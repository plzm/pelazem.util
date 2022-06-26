using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class ConverterTests
	{
		[Fact]
		public void GetBoolSucceeds()
		{
			// Arrange
			bool expected = true;
			string convertThis = "true";

			// Act
			bool result = Converter.GetBool(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetBoolFailsAndReturnsDefault()
		{
			// Arrange
			bool expected = default;
			string convertThis = null;

			// Act
			bool result = Converter.GetBool(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetDateTimeSucceeds()
		{
			// Arrange
			DateTime expected = new DateTime(2022, 3, 31, 12, 30, 15); ;
			string convertThis = expected.ToString(Constants.FORMAT_DATETIME_ISO8601);

			// Act
			DateTime result = Converter.GetDateTime(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetDateTimeFailsAndReturnsDefault()
		{
			// Arrange
			DateTime expected = default;
			string convertThis = null;

			// Act
			DateTime result = Converter.GetDateTime(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetTimeSpanSucceeds()
		{
			// Arrange
			TimeSpan expected = new TimeSpan(1, 2, 3);
			string convertThis = expected.ToString();

			// Act
			TimeSpan result = Converter.GetTimeSpan(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetTimeSpanFailsAndReturnsDefault()
		{
			// Arrange
			TimeSpan expected = default;
			string convertThis = null;

			// Act
			TimeSpan result = Converter.GetTimeSpan(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetDecimalSucceeds()
		{
			// Arrange
			Decimal expected = 1;
			string convertThis = expected.ToString();

			// Act
			Decimal result = Converter.GetDecimal(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetDecimalFailsAndReturnsDefault()
		{
			// Arrange
			Decimal expected = default;
			string convertThis = null;

			// Act
			Decimal result = Converter.GetDecimal(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetSingleSucceeds()
		{
			// Arrange
			Single expected = 1;
			string convertThis = expected.ToString();

			// Act
			Single result = Converter.GetSingle(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetSingleFailsAndReturnsDefault()
		{
			// Arrange
			Single expected = default;
			string convertThis = null;

			// Act
			Single result = Converter.GetSingle(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetDoubleSucceeds()
		{
			// Arrange
			Double expected = 1;
			string convertThis = expected.ToString();

			// Act
			Double result = Converter.GetDouble(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetDoubleFailsAndReturnsDefault()
		{
			// Arrange
			Double expected = default;
			string convertThis = null;

			// Act
			Double result = Converter.GetDouble(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetGuidSucceeds()
		{
			// Arrange
			Guid expected = Guid.NewGuid();
			string convertThis = expected.ToString();

			// Act
			Guid result = Converter.GetGuid(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetGuidFailsAndReturnsDefault()
		{
			// Arrange
			Guid expected = default;
			string convertThis = null;

			// Act
			Guid result = Converter.GetGuid(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetInt16Succeeds()
		{
			// Arrange
			Int16 expected = 1;
			string convertThis = expected.ToString();

			// Act
			Int16 result = Converter.GetInt16(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetInt16FailsAndReturnsDefault()
		{
			// Arrange
			Int16 expected = default;
			string convertThis = null;

			// Act
			Int16 result = Converter.GetInt16(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetInt32Succeeds()
		{
			// Arrange
			Int32 expected = 1;
			string convertThis = expected.ToString();

			// Act
			Int32 result = Converter.GetInt32(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetInt32FailsAndReturnsDefault()
		{
			// Arrange
			Int32 expected = default;
			string convertThis = null;

			// Act
			Int32 result = Converter.GetInt32(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetInt64Succeeds()
		{
			// Arrange
			Int64 expected = 1;
			string convertThis = expected.ToString();

			// Act
			Int64 result = Converter.GetInt64(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetInt64FailsAndReturnsDefault()
		{
			// Arrange
			Int64 expected = default;
			string convertThis = null;

			// Act
			Int64 result = Converter.GetInt64(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetUInt16Succeeds()
		{
			// Arrange
			UInt16 expected = 1;
			string convertThis = expected.ToString();

			// Act
			UInt16 result = Converter.GetUInt16(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetUInt16FailsAndReturnsDefault()
		{
			// Arrange
			UInt16 expected = default;
			string convertThis = null;

			// Act
			UInt16 result = Converter.GetUInt16(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetUInt32Succeeds()
		{
			// Arrange
			UInt32 expected = 1;
			string convertThis = expected.ToString();

			// Act
			UInt32 result = Converter.GetUInt32(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetUInt32FailsAndReturnsDefault()
		{
			// Arrange
			UInt32 expected = default;
			string convertThis = null;

			// Act
			UInt32 result = Converter.GetUInt32(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetUInt64Succeeds()
		{
			// Arrange
			UInt64 expected = 1;
			string convertThis = expected.ToString();

			// Act
			UInt64 result = Converter.GetUInt64(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void GetUInt64FailsAndReturnsDefault()
		{
			// Arrange
			UInt64 expected = default;
			string convertThis = null;

			// Act
			UInt64 result = Converter.GetUInt64(convertThis);

			// Assert
			Assert.Equal(expected, result);
		}
	}
}

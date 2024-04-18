using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class ValidationTests
	{
		[Fact]
		public void IsValidIsFalseByDefault()
		{
			// Arrange

			// Act
			Validation v = new();

			// Assert
			Assert.False(v.IsValid);
		}

		[Fact]
		public void IsValidAfterSettingToTrue()
		{
			// Arrange

			// Act
			Validation v = new()
			{
				IsValid = true
			};

			// Assert
			Assert.True(v.IsValid);
		}

		[Fact]
		public void IsMessageEmptyByDefault()
		{
			// Arrange

			// Act
			Validation v = new();

			// Assert
			Assert.Equal(0, v.Message.Length);
		}

		[Fact]
		public void IsMessageCorrectAfterSettingValue()
		{
			// Arrange
			string message = "foo";

			// Act
			Validation v = new()
			{
				Message = message
			};

			// Assert
			Assert.Equal(message, v.Message);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class ValidationResultTests
	{
		[Fact]
		public void IsValidIsTrueByDefault()
		{
			// Arrange

			// Act
			ValidationResult vr = new();

			// Assert
			Assert.True(vr.IsValid);
		}

		[Fact]
		public void ValidationsIsNotNullByDefault()
		{
			// Arrange

			// Act
			ValidationResult vr = new();

			// Assert
			Assert.NotNull(vr.Validations);
		}

		[Fact]
		public void IsValidIsTrueWhenAllValidationsHaveIsValidTrue()
		{
			// Arrange

			// Act
			ValidationResult vr = new();

			for (int i = 1; i <= 5; i++)
				vr.Validations.Add(new Validation() { IsValid = true });

			// Assert
			Assert.True(vr.IsValid);
		}

		[Fact]
		public void IsValidIsFalseWhenAtLeastOneValidationHasIsValidFalse()
		{
			// Arrange

			// Act
			ValidationResult vr = new();

			for (int i = 1; i <= 5; i++)
				vr.Validations.Add(new Validation() { IsValid = (i > 1) });

			// Assert
			Assert.False(vr.IsValid);
		}
	}
}

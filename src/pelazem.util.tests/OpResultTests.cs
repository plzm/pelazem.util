using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class OpResultTests
	{
		[Fact]
		public void ValidationResultIsNotNullByDefault()
		{
			// Arrange

			// Act
			OpResult o = new();

			// Assert
			Assert.NotNull(o.ValidationResult);
		}

		[Fact]
		public void ValidationResultIsSetCorrectly()
		{
			// Arrange
			ValidationResult vr = new();
			vr.Validations.Add(new Validation() { IsValid = true, Message = "foo" });

			// Act
			OpResult o = new()
			{
				ValidationResult = vr
			};

			// Assert
			Assert.Equal(vr, o.ValidationResult);
		}

		[Fact]
		public void OutputIsNullByDefault()
		{
			// Arrange

			// Act
			OpResult o = new();

			// Assert
			Assert.Null(o.Output);
		}

		[Fact]
		public void OutputIsSetCorrectly()
		{
			// Arrange
			TestClass tc = new() { Name = "foo" };

			// Act
			OpResult o = new() { Output = tc };

			// Assert
			Assert.Equal(tc, o.Output);
		}

		[Fact]
		public void OutputsIsNotNullByDefault()
		{
			// Arrange

			// Act
			OpResult o = new();

			// Assert
			Assert.NotNull(o.Outputs);
		}

		[Fact]
		public void OutputsCountIsCorrect()
		{
			// Arrange
			int count = 5;

			// Act
			OpResult o = new();

			for (int i = 1; i <= 5; i++)
				o.Outputs.Add(i.ToString(), i.ToString());

			// Assert
			Assert.Equal(count, o.Outputs.Count);
		}

		[Fact]
		public void OpResultsIsNotNullByDefault()
		{
			// Arrange

			// Act
			OpResult o = new();

			// Assert
			Assert.NotNull(o.OpResults);
		}

		[Fact]
		public void OpResultsCountIsCorrect()
		{
			// Arrange
			int count = 5;

			// Act
			OpResult o = new();

			for (int i = 1; i <= 5; i++)
				o.OpResults.Add(new OpResult() { Message = i.ToString() });

			// Assert
			Assert.Equal(count, o.OpResults.Count);
		}

		[Fact]
		public void ExceptionIsNullByDefault()
		{
			// Arrange

			// Act
			OpResult o = new();

			// Assert
			Assert.Null(o.Exception);
		}

		[Fact]
		public void ExceptionIsSetCorrectly()
		{
			// Arrange
			Exception e = new() { Source = "foo" };

			// Act
			OpResult o = new() { Exception = e };

			// Assert
			Assert.Equal(e, o.Exception);
		}

		[Fact]
		public void SucceededIsNullByDefault()
		{
			// Arrange

			// Act
			OpResult o = new();

			// Assert
			Assert.Null(o.Succeeded);
		}

		[Fact]
		public void SucceededIsSetCorrectlyToTrue()
		{
			// Arrange
			bool succeeded = true;

			// Act
			OpResult o = new() { Succeeded = succeeded };

			// Assert
			Assert.True(o.Succeeded);
		}

		[Fact]
		public void SucceededIsSetCorrectlyToFalse()
		{
			// Arrange
			bool succeeded = false;

			// Act
			OpResult o = new() { Succeeded = succeeded };

			// Assert
			Assert.False(o.Succeeded);
		}

		[Fact]
		public void IsMessageEmptyByDefault()
		{
			// Arrange

			// Act
			OpResult o = new();

			// Assert
			Assert.Equal(0, o.Message.Length);
		}

		[Fact]
		public void IsMessageCorrectAfterSettingValue()
		{
			// Arrange
			string message = "foo";

			// Act
			OpResult o = new()
			{
				Message = message
			};

			// Assert
			Assert.Equal(message, o.Message);
		}

		[Fact]
		public void IsCountAffectedZeroByDefault()
		{
			// Arrange

			// Act
			OpResult o = new();

			// Assert
			Assert.Equal(0, o.CountAffected);
		}

		[Fact]
		public void IsCountAffectedCorrectAfterSettingValue()
		{
			// Arrange
			int count = 5;

			// Act
			OpResult o = new()
			{
				CountAffected = count
			};

			// Assert
			Assert.Equal(count, o.CountAffected);
		}
	}
}

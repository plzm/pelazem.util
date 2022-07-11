using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class ErrorUtilTests
	{
		[Fact]
		public void NullExceptionShouldReturnEmptyTextString()
		{
			// Arrange
			Exception ex = null;

			// Act
			string result = ErrorUtil.GetText(ex);

			// Assert
			Assert.Equal(0, result.Length);
		}

		[Fact]
		public void ExceptionTextShouldContainRequiredInfo()
		{
			// Arrange
			string message = "foo";
			string source = "test";
			Exception ex = new(message);
			ex.Source = source;
			string expected =
				Properties.Resources.Type + ": " + ex.GetType().Name + Environment.NewLine +
				Properties.Resources.Source + ": " + source + Environment.NewLine +
				Properties.Resources.Message + ": " + message + Environment.NewLine +
				Properties.Resources.StackTrace + ":" + Environment.NewLine +
				Environment.NewLine;

			// Act
			string result = ErrorUtil.GetText(ex);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void ExceptionWithInnerExceptionTextShouldContainRequiredInfo()
		{
			// Arrange
			string messageChild = "bar";
			string sourceChild = "also test";
			Exception exInner = new(messageChild);
			exInner.Source = sourceChild;

			string messageParent = "foo";
			string sourceParent = "test";
			Exception exOuter = new(messageParent, exInner);
			exOuter.Source = sourceParent;

			string expected =
				Properties.Resources.Type + ": " + exOuter.GetType().Name + Environment.NewLine +
				Properties.Resources.Source + ": " + sourceParent + Environment.NewLine +
				Properties.Resources.Message + ": " + messageParent + Environment.NewLine +
				Properties.Resources.StackTrace + ":" + Environment.NewLine +
				Environment.NewLine +
				Properties.Resources.InnerException + ":" + Environment.NewLine +
				Properties.Resources.Type + ": " + exInner.GetType().Name + Environment.NewLine +
				Properties.Resources.Source + ": " + sourceChild + Environment.NewLine +
				Properties.Resources.Message + ": " + messageChild + Environment.NewLine +
				Properties.Resources.StackTrace + ":" + Environment.NewLine +
				Environment.NewLine + Environment.NewLine;

			// Act
			string result = ErrorUtil.GetText(exOuter);

			// Assert
			Assert.Equal(expected, result);
		}

		[Fact]
		public void NullErrorObjectShouldReturnEmptyTextString()
		{
			// Arrange
			object err = null;

			// Act
			string result = ErrorUtil.GetText(err);

			// Assert
			Assert.Equal(0, result.Length);
		}

		[Fact]
		public void ErrorObjectTextShouldContainInfo()
		{
			// Arrange
			string name = "foo";
			TestClass errorObject = new() { Name = name };

			// Act
			string result = ErrorUtil.GetText(errorObject);

			// Assert
			Assert.False(string.IsNullOrWhiteSpace(result));
		}
	}
}

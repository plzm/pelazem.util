using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class ReflectionExtensionMethodsTests
	{
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("foo")]
		public void GetValueExShouldReturnCorrectValue(string value)
		{
			// Arrange
			ReflectionTestClass rtc = new() { Name = value };
			string propName = nameof(ReflectionTestClass.Name);
			PropertyInfo prop = typeof(ReflectionTestClass).GetProperty(propName);

			// Act
			string result = prop.GetValueEx(rtc) as string;

			// Assert
			Assert.Equal(value, result);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("foo")]
		public void GetValueExWithNullPropShouldReturnNull(string value)
		{
			// Arrange
			ReflectionTestClass rtc = new() { Name = value };
			PropertyInfo prop = null;

			// Act
			string result = prop.GetValueEx(rtc) as string;

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void GetValueExWithNullObjectShouldReturnNull()
		{
			// Arrange
			ReflectionTestClass rtc = null;
			string propName = nameof(ReflectionTestClass.Name);
			PropertyInfo prop = typeof(ReflectionTestClass).GetProperty(propName);

			// Act
			string result = prop.GetValueEx(rtc) as string;

			// Assert
			Assert.Null(result);
		}
	}
}

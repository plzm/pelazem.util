using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class CollectionExtensionMethodsTests
	{
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void SingleEmptyItemListWithSpaceDelimShouldReturnEmptyString(string value)
		{
			// Arrange
			string delim = " ";
			List<string> testList = new List<string>() { value };

			// Act
			string test = testList.GetDelimitedList(delim, string.Empty, false);

			// Assert
			Assert.Equal(0, test.Length);
		}
	}
}

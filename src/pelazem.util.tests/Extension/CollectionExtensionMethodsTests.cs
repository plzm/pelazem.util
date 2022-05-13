using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class CollectionExtensionMethodsTests
	{
		[Fact]
		public void AddItemsTargetCountIsCorrect()
		{
			// Arrange
			List<int> targetList = new();
			List<int> itemsToAdd = new();

			int initialCount = targetList.Count;
			int numOfItems = 10;

			for (int i = 1; i <= numOfItems; i++)
				itemsToAdd.Add(i);

			// Act
			targetList.AddItems(itemsToAdd);

			// Assert
			Assert.Equal(initialCount + numOfItems, targetList.Count);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		[InlineData("    ")]
		public void SingleEmptyItemListWithSpaceDelimShouldReturnEmptyString(string value)
		{
			// Arrange
			string delim = " ";
			List<string> testList = new() { value };

			// Act
			string test = testList.GetDelimitedList(delim, string.Empty, false);

			// Assert
			Assert.Equal(0, test.Length);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		[InlineData("    ")]
		public void SingleEmptyItemListWithStringDelimShouldReturnEmptyString(string value)
		{
			// Arrange
			string delim = ",";
			List<string> testList = new() { value };

			// Act
			string test = testList.GetDelimitedList(delim, string.Empty, false);

			// Assert
			Assert.Equal(0, test.Length);
		}

		[Fact]
		public void EmptyItemsListNotSetToUseEmptyItemsShouldReturnEmptyString()
		{
			// Arrange
			string delim = ",";
			List<string> testList = new();
			testList.Add(" ");
			testList.Add(null);
			testList.Add("    ");
			testList.Add(" ");

			// Act
			string test = testList.GetDelimitedList(delim, string.Empty, false);

			// Assert
			Assert.Equal(0, test.Length);
		}

		[Fact]
		public void GetDelimitedListFromIENumPrimitive()
		{
			// Arrange
			List<int> items = new();
			string delimiter = ",";
			string expectedValue = "1,2,3,4,5,6,7,8,9,10";
			
			for (int i = 1; i <= 10; i++)
				items.Add(i);

			// Act
			string result = items.GetDelimitedList(delimiter, string.Empty, false);

			// Assert
			Assert.Equal(expectedValue, result);
		}

		[Fact]
		public void GetDelimitedListFromIENumProperty()
		{
			// Arrange
			List<Sample> items = new();
			string delimiter = ",";
			string expectedValue = "1,2,3,4,5,6,7,8,9,10";

			PropertyInfo prop = typeof(Sample).GetProperty(nameof(Sample.Id));

			for (int i = 1; i <= 10; i++)
				items.Add(new Sample() { Id = i });

			// Act
			string result = items.GetDelimitedList(delimiter, string.Empty, prop, false);

			// Assert
			Assert.Equal(expectedValue, result);
		}

		[Fact]
		public void GetDelimitedListFromIDictPrimitive()
		{
			// Arrange
			Dictionary<int, int> items = new();
			string delimiter = ",";
			string expectedValue = "1=1,2=2,3=3,4=4,5=5,6=6,7=7,8=8,9=9,10=10";

			for (int i = 1; i <= 10; i++)
				items.Add(i, i);

			// Act
			string result = items.GetDelimitedList(delimiter, string.Empty, false);

			// Assert
			Assert.Equal(expectedValue, result);
		}

		[Fact]
		public void GetDelimitedListFromIDictProperty()
		{
			// Arrange
			Dictionary<int, Sample> items = new();
			string delimiter = ",";
			string expectedValue = "1=1,2=2,3=3,4=4,5=5,6=6,7=7,8=8,9=9,10=10";

			PropertyInfo prop = typeof(Sample).GetProperty(nameof(Sample.Id));

			for (int i = 1; i <= 10; i++)
				items.Add(i, new Sample() { Id = i });

			// Act
			string result = items.GetDelimitedList(delimiter, string.Empty, prop, false);

			// Assert
			Assert.Equal(expectedValue, result);
		}
	}

	internal class Sample
	{
		public int Id { get; set; }
	}
}

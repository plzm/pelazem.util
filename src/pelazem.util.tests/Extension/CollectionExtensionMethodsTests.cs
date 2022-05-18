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
		public void AddNonZeroItemsTargetCountIsCorrect()
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

		[Fact]
		public void AddNullItemsTargetCountIsSame()
		{
			// Arrange
			List<int> targetList = new();
			List<int> itemsToAdd = null;

			int initialCount = targetList.Count;

			// Act
			targetList.AddItems(itemsToAdd);

			// Assert
			Assert.Equal(initialCount, targetList.Count);
		}

		[Fact]
		public void AddItemsToNullTargetDoesNotThrow()
		{
			// Arrange
			List<int> targetList = null;
			List<int> itemsToAdd = new();

			int numOfItems = 10;

			for (int i = 1; i <= numOfItems; i++)
				itemsToAdd.Add(i);

			// Act
			targetList.AddItems(itemsToAdd);

			// Assert
			Assert.Null(targetList);
		}

		[Theory]
		[InlineData(null, true)]
		[InlineData(null, false)]
		[InlineData("", true)]
		[InlineData("", false)]
		[InlineData("  ", true)]
		[InlineData("  ", false)]
		[InlineData(" foo ", true)]
		[InlineData(" foo ", false)]
		public void GetStringCorrectlyHandlesTrim(string item, bool includeEmptyItems)
		{
			// Arrange

			// Act
			string result = CollectionExtensionMethods.GetString(item, includeEmptyItems);

			// Assert
			if (item == null)
				Assert.Equal(0, result.Length);
			else if (includeEmptyItems)
				Assert.Equal(item, result);
			else
				Assert.Equal(item.Trim(), result);
		}

		[Theory]
		[InlineData(null, null)]
		[InlineData(null, ",")]
		[InlineData("", ",")]
		[InlineData(" ", ",")]
		[InlineData("1,2", ",")]
		[InlineData(",1,2", ",")]
		[InlineData(",1,2,", ",")]
		[InlineData("1,2,", ",")]
		[InlineData(null, " ")]
		[InlineData("", " ")]
		[InlineData(" ", " ")]
		[InlineData("1 2", " ")]
		[InlineData(" 1 2", " ")]
		[InlineData(" 1 2 ", " ")]
		[InlineData("1 2 ", " ")]
		public void GetResultCorrectlyRemovesLeadingDelimiter(string delimitedList, string delimiter)
		{
			// Arrange

			// Act
			string result = CollectionExtensionMethods.GetResult(delimitedList, delimiter);

			// Assert
			if (string.IsNullOrWhiteSpace(delimitedList))
				Assert.Equal(delimitedList, result);
			else if (string.IsNullOrEmpty(delimiter))
				Assert.Equal(delimitedList, result);
			else if (!delimitedList.StartsWith(delimiter))
				Assert.Equal(delimitedList, result);
			else
				Assert.Equal(delimitedList.Substring(1), result);
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
		public void EmptyItemsListSetToUseEmptyItemsShouldReturnNonEmptyString()
		{
			// Arrange
			string delim = ",";
			List<string> testList = new();
			testList.Add(" ");
			testList.Add(null);
			testList.Add("    ");
			testList.Add(" ");
			string expectedValue = " ,,    , ";

			// Act
			string test = testList.GetDelimitedList(delim, string.Empty, true);

			// Assert
			Assert.Equal(expectedValue, test);
		}

		[Theory]
		[InlineData(",", null, false)]
		[InlineData(",", null, true)]
		[InlineData(",", "", false)]
		[InlineData(",", "", true)]
		[InlineData(",", "itsempty", false)]
		[InlineData(",", "itsempty", true)]
		public void GetDelimitedListFromNullListWithoutPropInfoReturnsValueIfEmpty(string delimiter, string valueIfEmpty, bool includeEmptyItems)
		{
			// Arrange
			List<int> input = null;

			// Act
			string result = input.GetDelimitedList(delimiter, valueIfEmpty, includeEmptyItems);

			// Assert
			Assert.Equal(valueIfEmpty, result);
		}

		[Theory]
		[InlineData(",", null, false)]
		[InlineData(",", null, true)]
		[InlineData(",", "", false)]
		[InlineData(",", "", true)]
		[InlineData(",", "itsempty", false)]
		[InlineData(",", "itsempty", true)]
		public void GetDelimitedListFromNullListWithPropInfoReturnsValueIfEmpty(string delimiter, string valueIfEmpty, bool includeEmptyItems)
		{
			// Arrange
			List<Sample> input = null;
			PropertyInfo prop = typeof(Sample).GetProperty(nameof(Sample.Id));

			// Act
			string result = input.GetDelimitedList(delimiter, valueIfEmpty, prop, includeEmptyItems);

			// Assert
			Assert.Equal(valueIfEmpty, result);
		}

		[Theory]
		[InlineData(",", null, false)]
		[InlineData(",", null, true)]
		[InlineData(",", "", false)]
		[InlineData(",", "", true)]
		[InlineData(",", "itsempty", false)]
		[InlineData(",", "itsempty", true)]
		public void GetDelimitedListFromNullDictWithoutPropInfoReturnsValueIfEmpty(string delimiter, string valueIfEmpty, bool includeEmptyItems)
		{
			// Arrange
			Dictionary<int, string> input = null;

			// Act
			string result = input.GetDelimitedList(delimiter, valueIfEmpty, includeEmptyItems);

			// Assert
			Assert.Equal(valueIfEmpty, result);
		}

		[Theory]
		[InlineData(",", null, false)]
		[InlineData(",", null, true)]
		[InlineData(",", "", false)]
		[InlineData(",", "", true)]
		[InlineData(",", "itsempty", false)]
		[InlineData(",", "itsempty", true)]
		public void GetDelimitedListFromNullDictWithPropInfoReturnsValueIfEmpty(string delimiter, string valueIfEmpty, bool includeEmptyItems)
		{
			// Arrange
			Dictionary<int, Sample> input = null;
			PropertyInfo prop = typeof(Sample).GetProperty(nameof(Sample.Id));

			// Act
			string result = input.GetDelimitedList(delimiter, valueIfEmpty, prop, includeEmptyItems);

			// Assert
			Assert.Equal(valueIfEmpty, result);
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

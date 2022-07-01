using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class OpResultGenericTests
	{
		[Fact]
		public void OutputsIsNotNullByDefault()
		{
			// Arrange

			// Act
			OpResult<string> o = new();

			// Assert
			Assert.NotNull(o.Outputs);
		}

		[Fact]
		public void OutputsCountIsCorrect()
		{
			// Arrange
			int count = 5;

			// Act
			OpResult<string> o = new();

			for (int i = 1; i <= 5; i++)
				o.Outputs.Add(i.ToString(), i.ToString());

			// Assert
			Assert.Equal(count, o.Outputs.Count);
		}
	}
}

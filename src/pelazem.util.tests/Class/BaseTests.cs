using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using pelazem.util;
using System.ComponentModel;

namespace pelazem.util.tests
{
	public class BaseTests
	{
		private bool _notified = false;

		[Fact]
		public void HasChangedIsTrueOnPropertySet()
		{
			// Arrange
			TestClass tc = new();

			// Act
			tc.Name = "foo";

			// Assert
			Assert.True(tc.HasChanged);
		}

		[Fact]
		public void HasChangedIsFalseAfterSet()
		{
			// Arrange
			TestClass tc = new();

			// Act
			tc.Name = "foo";
			tc.HasChanged = false;

			// Assert
			Assert.False(tc.HasChanged);
		}

		[Fact]
		public void FireEventsIsTrueByDefault()
		{
			// Arrange
			TestClass tc = new();

			// Act

			// Assert
			Assert.True(tc.FireEvents);
		}

		[Fact]
		public void FireEventsIsFalseAfterSet()
		{
			// Arrange
			TestClass tc = new();

			// Act
			tc.FireEvents = false;

			// Assert
			Assert.False(tc.FireEvents);
		}

		[Fact]
		public void ChangeFiresPropertyChangedEvent()
		{
			// Arrange
			TestClass tc = new();

			tc.PropertyChanged += GetNotified;

			// Act
			tc.Name = "foo";

			// Assert
			Assert.True(_notified);
		}

		private void GetNotified(object sender, PropertyChangedEventArgs e)
		{
			_notified = true;
		}
	}
}

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
			var tc = new TestClass();

			// Act
			tc.Name = "foo";

			// Assert
			Assert.True(tc.HasChanged);
		}

		[Fact]
		public void HasChangedIsFalseAfterSet()
		{
			// Arrange
			var tc = new TestClass();

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
			var tc = new TestClass();

			// Act

			// Assert
			Assert.True(tc.FireEvents);
		}

		[Fact]
		public void FireEventsIsFalseAfterSet()
		{
			// Arrange
			var tc = new TestClass();

			// Act
			tc.FireEvents = false;

			// Assert
			Assert.False(tc.FireEvents);
		}

		[Fact]
		public void ChangeFiresPropertyChangedEvent()
		{
			// Arrange
			var tc = new TestClass();

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

	internal class TestClass : Base
	{
		private string _name = string.Empty;

		internal string Name
		{
			get { return _name; }

			set
			{
				try
				{
					_name = value;
					this.OnPropertyChanged(null);
				}
				catch
				{
					_name = string.Empty;
					this.HasChanged = false;
				}
			}
		}
	}
}

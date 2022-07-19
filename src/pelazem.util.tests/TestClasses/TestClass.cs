using System;

namespace pelazem.util.tests
{
	internal class TestClass : Base
	{
		private string _name = string.Empty;

		public string Name
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

		public String StringProp { get; set; }
		public DateTime DateTimeProp { get; set; }
		public char CharProp { get; set; }
		public bool BoolProp { get; set; }

		public override string ToString()
		{
			return nameof(TestClass);
		}
	}
}

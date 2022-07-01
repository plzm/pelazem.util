namespace pelazem.util.tests
{
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

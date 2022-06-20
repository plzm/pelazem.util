using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace pelazem.util
{
	public abstract class Base : IDisposable, INotifyPropertyChanged
	{
		#region Properties

		public bool HasChanged { get; set; } = false;

		public virtual bool FireEvents { get; set; } = true;

		#endregion

		#region IDisposable Members

		[ExcludeFromCodeCoverage]
		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

		[ExcludeFromCodeCoverage]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				DisposeNotify();
			}
		}

		#endregion

		#region Notify Property Changed Support

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged = null;

		#endregion

		protected void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			this.HasChanged = true;

			if (this.FireEvents)
			{
				if (this.PropertyChanged == null)
					this.PropertyChanged = delegate { };

				this.PropertyChanged(this, e);
			}
		}

		[ExcludeFromCodeCoverage]
		protected void DisposeNotify()
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged = null;
		}

		#endregion
	}
}

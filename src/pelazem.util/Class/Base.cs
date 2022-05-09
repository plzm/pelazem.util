using System;
using System.ComponentModel;

namespace pelazem.util
{
	public abstract class Base : IDisposable, INotifyPropertyChanged
	{
		#region Variables

		private bool _hasChanged = false;

		private bool _fireEvents = true;

		#endregion

		#region Properties

		public bool HasChanged
		{
			get { return _hasChanged; }
			set { _hasChanged = value; }
		}

		public virtual bool FireEvents
		{
			get { return _fireEvents; }
			set { _fireEvents = value; }
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

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

			if (_fireEvents)
			{
				if (this.PropertyChanged == null)
					this.PropertyChanged = delegate { };

				this.PropertyChanged(this, e);
			}
		}

		protected void DisposeNotify()
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged = null;
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;

namespace pelazem.util
{
	/// <summary>
	/// A class suitable for returning from class library operations to indicate operation success,
	/// provide the consumer a message, and return an output value.
	/// </summary>
	/// <author>Patrick El-Azem</author>
	public class OpResult<T> : OpResult
	{
		#region Variables

		private Dictionary<string, T> _outputs = null;

		#endregion

		public new T Output { get; set; } = default(T);

		public new Dictionary<string, T> Outputs
		{
			get
			{
				if (_outputs == null)
					_outputs = new Dictionary<string, T>();

				return _outputs;
			}
		}
	}
}

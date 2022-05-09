using System;
using System.Collections.Generic;

namespace pelazem.util
{
	/// <summary>
	/// A class suitable for returning from class library operations to indicate operation success,
	/// provide the consumer a message, and return an output value.
	/// </summary>
	/// <author>Patrick El-Azem</author>
	public class OpResult
	{
		#region Variables

		private Dictionary<string, object> _outputs = null;
		private List<OpResult> _opResults = null;

		private ValidationResult _validationResult = null;

		#endregion

		#region Properties

		/// <summary>
		/// Whether the operation that generated this OpResult succeeded.
		/// </summary>
		public virtual bool Succeeded { get; set; } = false;

		/// <summary>
		/// A status or other message provided by the operation.
		/// </summary>
		public virtual string Message { get; set; } = string.Empty;

		public virtual int CountAffected { get; set; } = 0;

		public virtual Exception Exception { get; set; } = null;

		public virtual object Output { get; set; } = null;

		/// <summary>
		/// Output values from the operation. Key-value pairs.
		/// </summary>
		public virtual Dictionary<string, object> Outputs
		{
			get
			{
				if (_outputs == null)
					_outputs = new Dictionary<string, object>();

				return _outputs;
			}
		}

		public virtual IList<OpResult> OpResults
		{
			get
			{
				if (_opResults == null)
					_opResults = new List<OpResult>();

				return _opResults;
			}
		}

		public virtual ValidationResult ValidationResult
		{
			get
			{
				if (_validationResult == null)
					_validationResult = new ValidationResult();

				return _validationResult;
			}
			set
			{
				_validationResult = value;
			}
		}

		#endregion
	}

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

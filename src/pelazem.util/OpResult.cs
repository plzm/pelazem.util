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
		#region Validation

		private ValidationResult _validationResult = null;

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

		#region Output

		/// <summary>
		/// Use when a single Output makes sense, otherwise use Outputs
		/// </summary>
		public virtual object Output { get; set; } = null;

		private Dictionary<string, object> _outputs = null;

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

		#endregion

		#region OpResult

		private List<OpResult> _opResults = null;

		/// <summary>
		/// Use for child or group OpResults to which this OpResult has a 1:n relationship
		/// </summary>
		public virtual IList<OpResult> OpResults
		{
			get
			{
				if (_opResults == null)
					_opResults = new List<OpResult>();

				return _opResults;
			}
		}

		#endregion

		#region Exception

		public virtual Exception Exception { get; set; } = null;

		#endregion

		#region Properties

		/// <summary>
		/// Whether the operation that generated this OpResult succeeded.
		/// Null means indeterminate/uncertain/not set.
		/// </summary>
		public virtual bool? Succeeded { get; set; } = null;

		/// <summary>
		/// A status or other message provided by the operation.
		/// </summary>
		public virtual string Message { get; set; } = string.Empty;

		public virtual int CountAffected { get; set; } = 0;

		#endregion
	}
}

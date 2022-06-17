using System;
using System.Collections.Generic;
using System.Linq;

namespace pelazem.util
{
	public class ValidationResult
	{
		private List<Validation> _validations = null;

		public virtual IList<Validation> Validations
		{
			get
			{
				if (_validations == null)
					_validations = new List<Validation>();

				return _validations;
			}
		}

		public bool IsValid
		{
			get
			{
				return (_validations == null || !this.Validations.Any() || this.Validations.Count(v => !v.IsValid) == 0);
			}
		}
	}
}

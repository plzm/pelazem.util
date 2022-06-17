using System;
using System.Reflection;

namespace pelazem.util
{
	public static class ReflectionExtensionMethods
	{
		public static object GetValueEx(this PropertyInfo prop, object obj)
		{
			if (prop == null || obj == null)
				return null;
			else
				return prop.GetValue(obj, null);
		}

		public static void SetValueEx(this PropertyInfo prop, object obj, object value)
		{
			if (prop != null && obj != null)
				prop.SetValue(obj, value, null);
		}
	}
}

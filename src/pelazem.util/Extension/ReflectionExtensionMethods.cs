using System;
using System.Reflection;

namespace pelazem.util
{
	public static class ReflectionExtensionMethods
	{
		public static object GetValueEx(this PropertyInfo prop, object obj)
		{
			return prop.GetValue(obj, null);
		}

		public static void SetValueEx(this PropertyInfo prop, object obj, object value)
		{
			prop.SetValue(obj, value, null);
		}
	}
}

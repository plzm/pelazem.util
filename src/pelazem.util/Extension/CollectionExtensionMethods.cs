using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;

namespace pelazem.util
{
	public static class CollectionExtensionMethods
	{
		public static void AddItems<T>(this ICollection<T> icollection, IEnumerable<T> items)
		{
			if (icollection == null || items == null)
				return;

			foreach (T item in items)
				icollection.Add(item);
		}

		public static string GetDelimitedList<T>(this IEnumerable<T> items, string delimiter, string valueIfEntireListIsEmpty, bool includeEmptyItems = false)
		{
			if (items == null || items.Count() == 0)
				return valueIfEntireListIsEmpty;

			string result = items
				.Aggregate
				(
					string.Empty,
					(output, next) =>
						output +
						((includeEmptyItems || (next != null && next.ToString().Length > 0)) ? delimiter : string.Empty) +
						(next != null ? next.ToString() : string.Empty)
				);

			return result.Substring(Math.Min(result.Length, delimiter.Length));
		}

		public static string GetDelimitedList<TKey, TValue>(this IDictionary<TKey, TValue> dict, string delimiter, string valueIfEntireListIsEmpty, bool includeEmptyItems = false)
		{
			if (dict == null || dict.Count == 0)
				return valueIfEntireListIsEmpty;

			string result = dict
				.Aggregate
				(
					string.Empty,
					(output, next) =>
						output +
						((includeEmptyItems || (next.Value != null && next.Value.ToString().Length > 0)) ? delimiter : string.Empty) +
						next.Key.ToString() + "=" + (next.Value != null ? next.Value.ToString() : string.Empty)
				);

			return result.Substring(Math.Min(result.Length, delimiter.Length));
		}

		public static string GetDelimitedList<T>(this IEnumerable<T> items, string delimiter, string valueIfEntireListIsEmpty, PropertyInfo propToUseValue, bool includeEmptyItems = false)
		{
			if (items == null || items.Count() == 0)
				return valueIfEntireListIsEmpty;

			string result = items
				.Aggregate
				(
					string.Empty,
					(output, next) =>
						output +
						((includeEmptyItems || (next != null && next.ToString().Length > 0)) ? delimiter : string.Empty) +
						(propToUseValue.GetValueEx(next) != null ? propToUseValue.GetValueEx(next).ToString() : string.Empty)
				);

			return result.Substring(Math.Min(result.Length, delimiter.Length));
		}

		public static string GetDelimitedList<TKey, TValue>(this IDictionary<TKey, TValue> dict, string delimiter, string valueIfEntireListIsEmpty, PropertyInfo propToUseValue, bool includeEmptyItems = false)
		{
			if (dict == null || dict.Count == 0)
				return valueIfEntireListIsEmpty;

			string result = dict
				.Aggregate
				(
					string.Empty,
					(output, next) =>
					output +
					((includeEmptyItems || (next.Value != null && next.Value.ToString().Length > 0)) ? delimiter : string.Empty) +
					next.Key.ToString() + "=" + (propToUseValue.GetValueEx(next.Value) != null ? propToUseValue.GetValueEx(next.Value).ToString() : string.Empty)
				);

			return result.Substring(Math.Min(result.Length, delimiter.Length));
		}
	}
}

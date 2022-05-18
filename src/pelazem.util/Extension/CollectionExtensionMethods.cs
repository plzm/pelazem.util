using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace pelazem.util
{
	public static class CollectionExtensionMethods
	{
		public static void AddItems<T>(this ICollection<T> iCollection, IEnumerable<T> items)
		{
			if (iCollection == null || items == null)
				return;

			foreach (T item in items)
				iCollection.Add(item);
		}

		internal static string GetString<T>(T item, bool includeEmptyItems)
		{
			if (item == null)
				return string.Empty;

			string result = (includeEmptyItems ? item.ToString() : item.ToString().Trim());

			return result;
		}

		internal static string GetResult(string delimitedList, string delimiter)
		{
			// Use string.IsNullOrEmpty for delimiter instead of string.IsNullOrWhiteSpace since someone may use whitespace as delimiter
			if (string.IsNullOrWhiteSpace(delimitedList) || string.IsNullOrEmpty(delimiter))
				return delimitedList;

			if (!delimitedList.StartsWith(delimiter))
				return delimitedList;

			// This chops a leading delimiter off
			return delimitedList.Substring(Math.Min(delimitedList.Length, delimiter.Length));
		}

		internal static string GetDelimitedListWorker<T>(IEnumerable<T> items, string delimiter, bool includeEmptyItems, Func<T, bool, string> howToGetItemValue)
		{
			string result = items
				.Aggregate
				(
					string.Empty,
					(output, next) =>
						output +
						(
							(includeEmptyItems || !string.IsNullOrWhiteSpace(GetString(next, includeEmptyItems))) ?
							delimiter + howToGetItemValue(next, includeEmptyItems) :
							string.Empty
						)
				);

			return GetResult(result, delimiter);
		}

		internal static string GetDelimitedListWorker<TKey, TValue>(IDictionary<TKey, TValue> items, string delimiter, bool includeEmptyItems, Func<KeyValuePair<TKey, TValue>, bool, string> howToGetItemValue)
		{
			string result = items
				.Aggregate
				(
					string.Empty,
					(output, next) =>
						output +
						(
							(includeEmptyItems || !string.IsNullOrWhiteSpace(GetString(next.Value, includeEmptyItems))) ?
							delimiter + howToGetItemValue(next, includeEmptyItems) :
							string.Empty
						)
				);

			return GetResult(result, delimiter);
		}

		public static string GetDelimitedList<T>(this IEnumerable<T> items, string delimiter, string valueIfEntireListIsEmpty, bool includeEmptyItems = false)
		{
			if (items == null || items.Count() == 0)
				return valueIfEntireListIsEmpty;

			Func<T, bool, string> func = (item, includeEmptyItems) => GetString(item, includeEmptyItems);

			return GetDelimitedListWorker(items, delimiter, includeEmptyItems, func);
		}

		public static string GetDelimitedList<T>(this IEnumerable<T> items, string delimiter, string valueIfEntireListIsEmpty, PropertyInfo propToUseValue, bool includeEmptyItems = false)
		{
			if (items == null || items.Count() == 0)
				return valueIfEntireListIsEmpty;

			Func<T, bool, string> func = (item, includeEmptyItems) => GetString(propToUseValue.GetValueEx(item), includeEmptyItems);

			return GetDelimitedListWorker(items, delimiter, includeEmptyItems, func);
		}

		public static string GetDelimitedList<TKey, TValue>(this IDictionary<TKey, TValue> items, string delimiter, string valueIfEntireListIsEmpty, bool includeEmptyItems = false)
		{
			if (items == null || items.Count == 0)
				return valueIfEntireListIsEmpty;

			Func<KeyValuePair<TKey, TValue>, bool, string> func = (item, includeEmptyItems) => item.Key.ToString() + "=" + GetString(item.Value, includeEmptyItems);

			return GetDelimitedListWorker(items, delimiter, includeEmptyItems, func);
		}

		public static string GetDelimitedList<TKey, TValue>(this IDictionary<TKey, TValue> items, string delimiter, string valueIfEntireListIsEmpty, PropertyInfo propToUseValue, bool includeEmptyItems = false)
		{
			if (items == null || items.Count == 0)
				return valueIfEntireListIsEmpty;

			Func<KeyValuePair<TKey, TValue>, bool, string> func = (item, includeEmptyItems) => item.Key.ToString() + "=" + GetString(propToUseValue.GetValueEx(item.Value), includeEmptyItems);

			return GetDelimitedListWorker(items, delimiter, includeEmptyItems, func);
		}
	}
}

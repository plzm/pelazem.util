using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace pelazem.util
{
	public static class TypeUtil
	{
		#region Properties

		private static readonly Type TypeBool = typeof(Boolean);
		private static readonly Type TypeByte = typeof(Byte);
		private static readonly Type TypeSByte = typeof(SByte);
		private static readonly Type TypeChar = typeof(char);
		private static readonly Type TypeDateTime = typeof(DateTime);
		private static readonly Type TypeDecimal = typeof(Decimal);
		private static readonly Type TypeDouble = typeof(Double);
		private static readonly Type TypeGuid = typeof(Guid);
		private static readonly Type TypeInt16 = typeof(Int16);
		private static readonly Type TypeUInt16 = typeof(UInt16);
		private static readonly Type TypeInt32 = typeof(Int32);
		private static readonly Type TypeUInt32 = typeof(UInt32);
		private static readonly Type TypeInt64 = typeof(Int64);
		private static readonly Type TypeUInt64 = typeof(UInt64);
		private static readonly Type TypeObject = typeof(object);
		private static readonly Type TypeSingle = typeof(Single);
		private static readonly Type TypeNInt = typeof(IntPtr);
		private static readonly Type TypeNUInt = typeof(UIntPtr);
		private static readonly Type TypeString = typeof(String);
		private static readonly Type TypeVoid = typeof(void);

		private static readonly Type TypeBoolNullable = typeof(Nullable<Boolean>);
		private static readonly Type TypeByteNullable = typeof(Nullable<Byte>);
		private static readonly Type TypeSByteNullable = typeof(Nullable<SByte>);
		private static readonly Type TypeCharNullable = typeof(Nullable<char>);
		private static readonly Type TypeDateTimeNullable = typeof(Nullable<DateTime>);
		private static readonly Type TypeDecimalNullable = typeof(Nullable<Decimal>);
		private static readonly Type TypeDoubleNullable = typeof(Nullable<Double>);
		private static readonly Type TypeGuidNullable = typeof(Nullable<Guid>);
		private static readonly Type TypeInt16Nullable = typeof(Nullable<Int16>);
		private static readonly Type TypeUInt16Nullable = typeof(Nullable<UInt16>);
		private static readonly Type TypeInt32Nullable = typeof(Nullable<Int32>);
		private static readonly Type TypeUInt32Nullable = typeof(Nullable<UInt32>);
		private static readonly Type TypeInt64Nullable = typeof(Nullable<Int64>);
		private static readonly Type TypeUInt64Nullable = typeof(Nullable<UInt64>);
		private static readonly Type TypeSingleNullable = typeof(Nullable<Single>);
		private static readonly Type TypeNIntNullable = typeof(Nullable<IntPtr>);
		private static readonly Type TypeNUIntNullable = typeof(Nullable<UIntPtr>);

		private static Dictionary<Type, string> _typeAliases = null;
		private static List<Type> _primitiveTypes = null;
		private static List<Type> _primitiveNullableTypes = null;
		private static List<Type> _numericTypes = null;

		private static SortedList<string, List<PropertyInfo>> _typeProps = null;
		private static SortedList<string, List<PropertyInfo>> _primitiveProps = null;
		private static SortedList<string, List<PropertyInfo>> _complexProps = null;

		#endregion

		#region Utility lists for public methods

		/// <summary>
		/// .NET types and C# alias names
		/// </summary>
		internal static Dictionary<Type, string> TypeAliases
		{
			get
			{
				if (_typeAliases == null)
					InitializeTypeAliases();

				return _typeAliases;
			}
		}

		internal static List<Type> PrimitiveTypes
		{
			get
			{
				if (_primitiveTypes == null)
					InitializePrimitiveTypes();

				return _primitiveTypes;
			}
		}

		internal static List<Type> PrimitiveNullableTypes
		{
			get
			{
				if (_primitiveNullableTypes == null)
					InitializePrimitiveNullableTypes();

				return _primitiveNullableTypes;
			}
		}

		internal static List<Type> NumericTypes
		{
			get
			{
				if (_numericTypes == null)
					InitializeNumericTypes();

				return _numericTypes;
			}
		}

		internal static SortedList<string, List<PropertyInfo>> TypeProps
		{
			get
			{
				if (_typeProps == null)
					_typeProps = new SortedList<string, List<PropertyInfo>>();

				return _typeProps;
			}
		}

		internal static SortedList<string, List<PropertyInfo>> PrimitiveProps
		{
			get
			{
				if (_primitiveProps == null)
					_primitiveProps = new SortedList<string, List<PropertyInfo>>();

				return _primitiveProps;
			}
		}

		internal static SortedList<string, List<PropertyInfo>> ComplexProps
		{
			get
			{
				if (_complexProps == null)
					_complexProps = new SortedList<string, List<PropertyInfo>>();

				return _complexProps;
			}
		}

		#endregion

		#region Property Initializers

		private static void InitializeTypeAliases()
		{
			_typeAliases = new Dictionary<Type, string>
			{
				{ TypeBool, "bool" },
				{ TypeByte, "byte" },
				{ TypeSByte, "sbyte" },
				{ TypeChar, "char" },
				{ TypeDecimal, "decimal" },
				{ TypeDouble, "double" },
				{ TypeInt16, "short" },
				{ TypeUInt16, "ushort" },
				{ TypeInt32, "int" },
				{ TypeUInt32, "uint" },
				{ TypeInt64, "long" },
				{ TypeUInt64, "ulong" },
				{ TypeObject, "object" },
				{ TypeSingle, "float" },
				{ TypeNInt, "nint" },
				{ TypeNUInt, "nuint" },
				{ TypeString, "string" },
				{ TypeVoid, "void" },
				{ TypeBoolNullable, "bool?" },
				{ TypeByteNullable, "byte?" },
				{ TypeSByteNullable, "sbyte?" },
				{ TypeCharNullable, "char?" },
				{ TypeDecimalNullable, "decimal?" },
				{ TypeDoubleNullable, "double?" },
				{ TypeInt16Nullable, "short?" },
				{ TypeUInt16Nullable, "ushort?" },
				{ TypeInt32Nullable, "int?" },
				{ TypeUInt32Nullable, "uint?" },
				{ TypeInt64Nullable, "long?" },
				{ TypeUInt64Nullable, "ulong?" },
				{ TypeSingleNullable, "float?" },
				{ TypeNIntNullable, "nint?" },
				{ TypeNUIntNullable, "nuint?" }
			};
		}

		private static void InitializePrimitiveTypes()
		{
			_primitiveTypes = new List<Type>
			{
				TypeBool,
				TypeByte,
				TypeSByte,
				TypeChar,
				TypeDateTime,
				TypeDecimal,
				TypeDouble,
				TypeGuid,
				TypeInt16,
				TypeInt32,
				TypeInt64,
				TypeUInt16,
				TypeUInt32,
				TypeUInt64,
				TypeSingle,
				TypeNInt,
				TypeNUInt,
				TypeString
			};
		}

		private static void InitializePrimitiveNullableTypes()
		{
			_primitiveNullableTypes = new List<Type>
			{
				TypeBoolNullable,
				TypeByteNullable,
				TypeSByteNullable,
				TypeCharNullable,
				TypeDateTimeNullable,
				TypeDecimalNullable,
				TypeDoubleNullable,
				TypeGuidNullable,
				TypeInt16Nullable,
				TypeUInt16Nullable,
				TypeInt32Nullable,
				TypeUInt32Nullable,
				TypeInt64Nullable,
				TypeUInt64Nullable,
				TypeSingleNullable,
				TypeNIntNullable,
				TypeNUIntNullable
			};
		}

		private static void InitializeNumericTypes()
		{
			_numericTypes = new List<Type>
			{
				TypeByte,
				TypeByteNullable,
				TypeSByte,
				TypeSByteNullable,
				TypeDecimal,
				TypeDecimalNullable,
				TypeDouble,
				TypeDoubleNullable,
				TypeInt16,
				TypeInt16Nullable,
				TypeUInt16,
				TypeUInt16Nullable,
				TypeInt32,
				TypeInt32Nullable,
				TypeUInt32,
				TypeUInt32Nullable,
				TypeInt64,
				TypeInt64Nullable,
				TypeUInt64,
				TypeUInt64Nullable,
				TypeSingle,
				TypeSingleNullable,
				TypeNInt,
				TypeNIntNullable,
				TypeNUInt,
				TypeNUIntNullable
			};
		}

		#endregion

		#region Type-related Methods

		public static bool IsNumeric(PropertyInfo prop)
		{
			return IsNumeric(prop.PropertyType);
		}

		public static bool IsNumeric(Type type)
		{
			if (type == null || type == TypeString || type == TypeChar || type == TypeVoid)
				return false;

			return NumericTypes.Contains(type);
		}

		public static bool IsPrimitive(PropertyInfo prop)
		{
			return IsPrimitive(prop.PropertyType);
		}

		/// <summary>
		/// True if the type is a primitive (nullable or non-nullable) type.
		/// This class' PrimitiveTypes or PrimitiveNullableTypes contain the types against which the passed-in type is compared.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool IsPrimitive(Type type)
		{
			return (PrimitiveTypes.Contains(type) || PrimitiveNullableTypes.Contains(type));
		}

		/// <summary>
		/// Returns the simple alias for a type name. For example, given System.Int32, returns int. If no simple alias is found, returns the type name.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string GetTypeAlias(Type type)
		{
			if (type == null)
				return string.Empty;
			else
				return TypeAliases.ContainsKey(type) ? TypeAliases[type] : type.Name;
		}

		#endregion

		#region Property-related Methods

		public static PropertyInfo GetProp(Type type, string propertyName)
		{
      return GetProps(type).Find(p => p.Name.ToLowerInvariant() == propertyName.Trim().ToLowerInvariant());
		}

		public static List<PropertyInfo> GetProps(Type type)
		{
			if (!TypeProps.ContainsKey(type.FullName))
				TypeProps.Add(type.FullName, type.GetRuntimeProperties().ToList<PropertyInfo>());

			return TypeProps[type.FullName];
		}

		public static List<PropertyInfo> GetPrimitiveProps(Type type)
		{
			if (!PrimitiveProps.ContainsKey(type.FullName))
				PrimitiveProps.Add(type.FullName, GetProps(type).Where(p => PrimitiveTypes.Contains(p.PropertyType) || PrimitiveNullableTypes.Contains(p.PropertyType)).ToList());

			return PrimitiveProps[type.FullName];
		}

		public static List<PropertyInfo> GetComplexProps(Type type)
		{
			if (!ComplexProps.ContainsKey(type.FullName))
				ComplexProps.Add(type.FullName, GetProps(type).Where(p => !PrimitiveTypes.Contains(p.PropertyType) && !PrimitiveNullableTypes.Contains(p.PropertyType)).ToList());

			return ComplexProps[type.FullName];
		}

		#endregion

		#region Comparison Methods

		/// <summary>
		/// Returns a comparison between the two passed values. If possible, a type-specific comparison will be used; otherwise, a string comparison will be used.
		/// </summary>
		/// <param name="xValue"></param>
		/// <param name="yValue"></param>
		/// <returns></returns>
		public static int Compare(object xValue, object yValue)
		{
			return Compare(xValue, yValue, xValue.GetType(), yValue.GetType());
		}

		/// <summary>
		/// Returns a comparison between the two passed values. If possible, a type-specific comparison will be used; otherwise, a string comparison will be used.
		/// </summary>
		/// <param name="xValue"></param>
		/// <param name="yValue"></param>
		/// <returns></returns>
		public static int Compare<T>(T xValue, T yValue)
		{
			Type t = typeof(T);

			return Compare(xValue, yValue, t, t);
		}

		private static int Compare(object xValue, object yValue, Type xType, Type yType)
		{
			if (!xType.Equals(yType))
			{
				return string.Compare(xValue.ToString(), yValue.ToString(), StringComparison.CurrentCultureIgnoreCase);
			}
			else
			{
				if (xType.Equals(TypeString))
					return string.Compare(xValue.ToString(), yValue.ToString(), StringComparison.CurrentCultureIgnoreCase);
				else if (xType.Equals(TypeGuid))
					return Comparer<Guid>.Default.Compare(Converter.GetGuid(xValue), Converter.GetGuid(yValue));
				else if (xType.Equals(TypeBool))
					return Comparer<Boolean>.Default.Compare(Converter.GetBool(xValue), Converter.GetBool(yValue));
				else if (xType.Equals(TypeDateTime))
					return DateTime.Compare(Converter.GetDateTime(xValue), Converter.GetDateTime(yValue));
				else if (xType.Equals(TypeSingle))
					return Comparer<Single>.Default.Compare(Converter.GetSingle(xValue), Converter.GetSingle(yValue));
				else if (xType.Equals(TypeDouble))
					return Comparer<Double>.Default.Compare(Converter.GetDouble(xValue), Converter.GetDouble(yValue));
				else if (xType.Equals(TypeDecimal))
					return Comparer<Decimal>.Default.Compare(Converter.GetDecimal(xValue), Converter.GetDecimal(yValue));
				else if (xType.Equals(TypeInt16))
					return Comparer<Int16>.Default.Compare(Converter.GetInt16(xValue), Converter.GetInt16(yValue));
				else if (xType.Equals(TypeInt32))
					return Comparer<Int32>.Default.Compare(Converter.GetInt32(xValue), Converter.GetInt32(yValue));
				else if (xType.Equals(TypeInt64))
					return Comparer<Int64>.Default.Compare(Converter.GetInt64(xValue), Converter.GetInt64(yValue));
				else
					return string.Compare(xValue.ToString(), yValue.ToString(), StringComparison.CurrentCultureIgnoreCase);
			}
		}

		#endregion
	}
}

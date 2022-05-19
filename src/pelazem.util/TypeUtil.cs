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

		public static Type TypeBool = typeof(Boolean);
		public static Type TypeByte = typeof(Byte);
		public static Type TypeSByte = typeof(SByte);
		public static Type TypeChar = typeof(char);
		public static Type TypeDateTime = typeof(DateTime);
		public static Type TypeDecimal = typeof(Decimal);
		public static Type TypeDouble = typeof(Double);
		public static Type TypeGuid = typeof(Guid);
		public static Type TypeInt16 = typeof(Int16);
		public static Type TypeUInt16 = typeof(UInt16);
		public static Type TypeInt32 = typeof(Int32);
		public static Type TypeUInt32 = typeof(UInt32);
		public static Type TypeInt64 = typeof(Int64);
		public static Type TypeUInt64 = typeof(UInt64);
		public static Type TypeObject = typeof(object);
		public static Type TypeSingle = typeof(Single);
		public static Type TypeString = typeof(String);
		public static Type TypeVoid = typeof(void);

		public static Type TypeBoolNullable = typeof(Nullable<Boolean>);
		public static Type TypeByteNullable = typeof(Nullable<Byte>);
		public static Type TypeSByteNullable = typeof(Nullable<SByte>);
		public static Type TypeCharNullable = typeof(Nullable<char>);
		public static Type TypeDateTimeNullable = typeof(Nullable<DateTime>);
		public static Type TypeDecimalNullable = typeof(Nullable<Decimal>);
		public static Type TypeDoubleNullable = typeof(Nullable<Double>);
		public static Type TypeGuidNullable = typeof(Nullable<Guid>);
		public static Type TypeInt16Nullable = typeof(Nullable<Int16>);
		public static Type TypeUInt16Nullable = typeof(Nullable<UInt16>);
		public static Type TypeInt32Nullable = typeof(Nullable<Int32>);
		public static Type TypeUInt32Nullable = typeof(Nullable<UInt32>);
		public static Type TypeInt64Nullable = typeof(Nullable<Int64>);
		public static Type TypeUInt64Nullable = typeof(Nullable<UInt64>);
		public static Type TypeSingleNullable = typeof(Nullable<Single>);

		private static Dictionary<Type, string> _typeAliases = null;
		private static List<Type> _primitiveTypes = null;
		private static List<Type> _primitiveNullableTypes = null;

		private static SortedList<string, List<PropertyInfo>> _typeProps = null;
		private static SortedList<string, List<PropertyInfo>> _primitiveProps = new SortedList<string, List<PropertyInfo>>();
		private static SortedList<string, List<PropertyInfo>> _complexProps = new SortedList<string, List<PropertyInfo>>();

		/// <summary>
		/// .NET types and C# alias names
		/// </summary>
		public static Dictionary<Type, string> TypeAliases
		{
			get
			{
				if (_typeAliases == null)
					InitializeTypeAliases();

				return _typeAliases;
			}
		}

		public static List<Type> PrimitiveTypes
		{
			get
			{
				if (_primitiveTypes == null)
					InitializePrimitiveTypes();

				return _primitiveTypes;
			}
		}

		public static List<Type> PrimitiveNullableTypes
		{
			get
			{
				if (_primitiveNullableTypes == null)
					InitializePrimitiveNullableTypes();

				return _primitiveNullableTypes;
			}
		}

		public static SortedList<string, List<PropertyInfo>> TypeProps
		{
			get
			{
				if (_typeProps == null)
					_typeProps = new SortedList<string, List<PropertyInfo>>();

				return _typeProps;
			}
		}

		public static SortedList<string, List<PropertyInfo>> PrimitiveProps
		{
			get
			{
				if (_primitiveProps == null)
					_primitiveProps = new SortedList<string, List<PropertyInfo>>();

				return _primitiveProps;
			}
		}

		public static SortedList<string, List<PropertyInfo>> ComplexProps
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
				{ TypeSingleNullable, "float?" }
			};
		}

		private static void InitializePrimitiveTypes()
		{
			_primitiveTypes = new List<Type>();

			_primitiveTypes.Add(TypeBool);
			_primitiveTypes.Add(TypeByte);
			_primitiveTypes.Add(TypeSByte);
			_primitiveTypes.Add(TypeChar);
			_primitiveTypes.Add(TypeDateTime);
			_primitiveTypes.Add(TypeDecimal);
			_primitiveTypes.Add(TypeDouble);
			_primitiveTypes.Add(TypeGuid);
			_primitiveTypes.Add(TypeInt16);
			_primitiveTypes.Add(TypeInt32);
			_primitiveTypes.Add(TypeInt64);
			_primitiveTypes.Add(TypeUInt16);
			_primitiveTypes.Add(TypeUInt32);
			_primitiveTypes.Add(TypeUInt64);
			_primitiveTypes.Add(TypeSingle);
			_primitiveTypes.Add(TypeString);
		}

		private static void InitializePrimitiveNullableTypes()
		{
			_primitiveNullableTypes = new List<Type>();

			_primitiveNullableTypes.Add(TypeBoolNullable);
			_primitiveNullableTypes.Add(TypeByteNullable);
			_primitiveNullableTypes.Add(TypeSByteNullable);
			_primitiveNullableTypes.Add(TypeCharNullable);
			_primitiveNullableTypes.Add(TypeDateTimeNullable);
			_primitiveNullableTypes.Add(TypeDecimalNullable);
			_primitiveNullableTypes.Add(TypeDoubleNullable);
			_primitiveNullableTypes.Add(TypeGuidNullable);
			_primitiveNullableTypes.Add(TypeInt16Nullable);
			_primitiveNullableTypes.Add(TypeUInt16Nullable);
			_primitiveNullableTypes.Add(TypeInt32Nullable);
			_primitiveNullableTypes.Add(TypeUInt32Nullable);
			_primitiveNullableTypes.Add(TypeInt64Nullable);
			_primitiveNullableTypes.Add(TypeUInt64Nullable);
			_primitiveNullableTypes.Add(TypeSingleNullable);
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

			return
			(
				type.Equals(TypeByte) ||
				type.Equals(TypeByteNullable) ||
				type.Equals(TypeSByte) ||
				type.Equals(TypeSByteNullable) ||
				type.Equals(TypeDecimal) ||
				type.Equals(TypeDecimalNullable) ||
				type.Equals(TypeDouble) ||
				type.Equals(TypeDoubleNullable) ||
				type.Equals(TypeInt16) ||
				type.Equals(TypeInt16Nullable) ||
				type.Equals(TypeUInt16) ||
				type.Equals(TypeUInt16Nullable) ||
				type.Equals(TypeInt32) ||
				type.Equals(TypeInt32Nullable) ||
				type.Equals(TypeUInt32) ||
				type.Equals(TypeUInt32Nullable) ||
				type.Equals(TypeInt64) ||
				type.Equals(TypeInt64Nullable) ||
				type.Equals(TypeUInt64) ||
				type.Equals(TypeUInt64Nullable) ||
				type.Equals(TypeSingle) ||
				type.Equals(TypeSingleNullable)
			);
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
		/// Returns the simple alias for a type name. For example, given System.Int32, returns int.
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

		public static List<PropertyInfo> GetProps(Type type)
		{
			if (!TypeProps.Keys.Contains(type.FullName))
				TypeProps.Add(type.FullName, type.GetRuntimeProperties().ToList<PropertyInfo>());

			return TypeProps[type.FullName];
		}

		public static List<PropertyInfo> GetPrimitiveProps(Type type)
		{
			if (!PrimitiveProps.Keys.Contains(type.FullName))
				PrimitiveProps.Add(type.FullName, GetProps(type).Where(p => PrimitiveTypes.Contains(p.PropertyType) || PrimitiveNullableTypes.Contains(p.PropertyType)).ToList());

			return PrimitiveProps[type.FullName];
		}

		public static List<PropertyInfo> GetComplexProps(Type type)
		{
			if (!ComplexProps.Keys.Contains(type.FullName))
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
					return string.Compare(xValue.ToString(), yValue.ToString(), StringComparison.CurrentCultureIgnoreCase);
				else if (xType.Equals(TypeBool))
					return Comparer<Boolean>.Default.Compare(Converter.GetBool(xValue), Converter.GetBool(yValue));
				else if (xType.Equals(TypeDateTime))
					return DateTime.Compare(Converter.GetDateTime(xValue), Converter.GetDateTime(yValue));
				else if (xType.Equals(TypeDouble))
					return Comparer<Double>.Default.Compare(Converter.GetDouble(xValue), Converter.GetDouble(yValue));
				else if (xType.Equals(TypeInt32))
					return Comparer<Int32>.Default.Compare(Converter.GetInt32(xValue), Converter.GetInt32(yValue));
				else if (xType.Equals(TypeInt64))
					return Comparer<Int64>.Default.Compare(Converter.GetInt64(xValue), Converter.GetInt64(yValue));
				else if (xType.Equals(TypeSingle))
					return Comparer<Single>.Default.Compare(Converter.GetSingle(xValue), Converter.GetSingle(yValue));
				else
					return string.Compare(xValue.ToString(), yValue.ToString(), StringComparison.CurrentCultureIgnoreCase);
			}
		}

		#endregion

		#region Property Set and Get

		/// <summary>
		/// Sets the property value on the passed entity to the passed value. Attempts to convert to the property's type to avoid cast errors.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="prop"></param>
		/// <param name="valueToSet"></param>
		public static void SetValue(object entity, PropertyInfo prop, object valueToSet)
		{
			if (!prop.CanWrite)
				return;

			Type propType = null;
			TypeInfo typeInfo = prop.PropertyType.GetTypeInfo();

			if ((typeInfo.IsPrimitive || prop.PropertyType.Equals(typeof(System.String)) || prop.PropertyType.Equals(typeof(System.Guid))))
				propType = prop.PropertyType;
			else if (typeInfo.IsGenericType && prop.PropertyType.Name.StartsWith("Nullable"))
				propType = typeInfo.GetGenericArguments().FirstOrDefault();

			if (propType != null)
			{
				if (propType.Equals(TypeString))
					prop.SetValueEx(entity, valueToSet.ToString());
				else if (propType.Equals(TypeBool))
					prop.SetValueEx(entity, Converter.GetBool(valueToSet));
				else if (propType.Equals(TypeDateTime))
					prop.SetValueEx(entity, Converter.GetDateTime(valueToSet));
				else if (propType.Equals(TypeDecimal))
					prop.SetValueEx(entity, Converter.GetDecimal(valueToSet));
				else if (propType.Equals(TypeDouble))
					prop.SetValueEx(entity, Converter.GetDouble(valueToSet));
				else if (propType.Equals(TypeGuid))
					prop.SetValueEx(entity, Converter.GetGuid(valueToSet));
				else if (propType.Equals(TypeInt16))
					prop.SetValueEx(entity, Converter.GetInt16(valueToSet));
				else if (propType.Equals(TypeUInt16))
					prop.SetValueEx(entity, Converter.GetUInt16(valueToSet));
				else if (propType.Equals(TypeInt32))
					prop.SetValueEx(entity, Converter.GetInt32(valueToSet));
				else if (propType.Equals(TypeUInt32))
					prop.SetValueEx(entity, Converter.GetUInt32(valueToSet));
				else if (propType.Equals(TypeInt64))
					prop.SetValueEx(entity, Converter.GetInt64(valueToSet));
				else if (propType.Equals(TypeUInt64))
					prop.SetValueEx(entity, Converter.GetUInt64(valueToSet));
				else if (propType.Equals(TypeSingle))
					prop.SetValueEx(entity, Converter.GetSingle(valueToSet));
				else
					prop.SetValueEx(entity, valueToSet);
			}
		}

		public static PropertyInfo GetProperty<TType>(Expression<Func<TType, object>> propertySelector)
		{
			PropertyInfo result = null;

			// we should have been passed a lambda that returns the property in question; get its body
			Expression expression = propertySelector.Body;

			// if the lambda refers to a conversion, we need to get at the actual property
			if (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked)
				expression = ((UnaryExpression)expression).Operand;

			// make sure what was passed is really a property (i.e. member accessor) and if not, throw and leave
			MemberExpression memberExpression = expression as MemberExpression;

			if (memberExpression == null)
				return result;

			// //////////
			// do some additional sanity checks
			expression = memberExpression.Expression;

			// if property returns ValueType we need to eliminate the conversion - do this again since we have drilled in to get the property's container
			if (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked)
				expression = ((UnaryExpression)expression).Operand;

			// Check if the expression is the parameter itself
			if (expression.NodeType != ExpressionType.Parameter)
				return result;
			// end sanity checks
			// //////////

			// Finally (!) retrieve the property's PropertyInfo and return it
			result = memberExpression.Member as PropertyInfo;

			return result;
		}

		#endregion
	}
}

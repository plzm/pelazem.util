using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using pelazem.util;

namespace pelazem.util.tests
{
	public class TypeUtilTests
	{
		[Theory, MemberData(nameof(TestClassNumericProps))]
		public void IsNumericIsTrueForNumericProperty(PropertyInfo prop)
		{
			// Arrange

			// Act
			bool result = TypeUtil.IsNumeric(prop);

			// Assert
			Assert.True(result);
		}

		[Theory, MemberData(nameof(TestClassNumericPropTypes))]
		public void IsNumericIsTrueForNumericPropertyType(Type type)
		{
			// Arrange

			// Act
			bool result = TypeUtil.IsNumeric(type);

			// Assert
			Assert.True(result);
		}

		[Theory, MemberData(nameof(TestClassProps))]
		public void IsNumericIsFalseForNonNumericProperty(PropertyInfo prop)
		{
			// Arrange

			// Act
			bool result = TypeUtil.IsNumeric(prop);

			// Assert
			Assert.False(result);
		}

		[Theory, MemberData(nameof(TestClassPropTypes))]
		public void IsNumericIsFalseForNonNumericPropertyType(Type type)
		{
			// Arrange

			// Act
			bool result = TypeUtil.IsNumeric(type);

			// Assert
			Assert.False(result);
		}

		[Theory, MemberData(nameof(TestClassNumericProps))]
		public void IsPrimitiveIsTrueForNumericProperty(PropertyInfo prop)
		{
			// Arrange

			// Act
			bool result = TypeUtil.IsPrimitive(prop);

			// Assert
			Assert.True(result);
		}

		[Theory, MemberData(nameof(TestClassNumericPropTypes))]
		public void IsPrimitiveIsTrueForNumericPropertyType(Type type)
		{
			// Arrange

			// Act
			bool result = TypeUtil.IsPrimitive(type);

			// Assert
			Assert.True(result);
		}


		[Theory, MemberData(nameof(TestClassNonPrimitiveProps))]
		public void IsPrimitiveIsFalseForNonPrimitiveProperty(PropertyInfo prop)
		{
			// Arrange

			// Act
			bool result = TypeUtil.IsPrimitive(prop);

			// Assert
			Assert.False(result);
		}

		[Theory, MemberData(nameof(TestClassNonPrimitivePropTypes))]
		public void IsPrimitiveIsFalseForNonPrimitiveType(Type type)
		{
			// Arrange

			// Act
			bool result = TypeUtil.IsPrimitive(type);

			// Assert
			Assert.False(result);
		}

		public static IEnumerable<object[]> TestClassNumericProps()
		{
			return TypeUtil.GetProps(typeof(TestClassNumeric)).Select(x => new object[] { x });
		}

		public static IEnumerable<object[]> TestClassNumericPropTypes()
		{
			return TypeUtil.GetProps(typeof(TestClassNumeric)).Select(x => new object[] { x.PropertyType });
		}

		public static IEnumerable<object[]> TestClassProps()
		{
			return TypeUtil.GetProps(typeof(TestClass)).Select(x => new object[] { x });
		}

		public static IEnumerable<object[]> TestClassPropTypes()
		{
			return TypeUtil.GetProps(typeof(TestClass)).Select(x => new object[] { x.PropertyType });
		}

		public static IEnumerable<object[]> TestClassNonPrimitiveProps()
		{
			return TypeUtil.GetProps(typeof(TestClassNonPrimitive)).Select(x => new object[] { x });
		}

		public static IEnumerable<object[]> TestClassNonPrimitivePropTypes()
		{
			return TypeUtil.GetProps(typeof(TestClassNonPrimitive)).Select(x => new object[] { x.PropertyType });
		}
	}
}

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

		[Fact]
		public void TypeAliasesShouldNotBeNull()
		{
			// Arrange

			// Act

			// Assert
			Assert.NotNull(TypeUtil.TypeAliases);
		}

		[Fact]
		public void TypeAliasesShouldNotHaveZeroCount()
		{
			// Arrange

			// Act

			// Assert
			Assert.True(TypeUtil.TypeAliases.Count > 0);
		}

		[Fact]
		public void PrimitiveTypesShouldNotBeNull()
		{
			// Arrange

			// Act

			// Assert
			Assert.NotNull(TypeUtil.PrimitiveTypes);
		}

		[Fact]
		public void PrimitiveTypesShouldNotHaveZeroCount()
		{
			// Arrange

			// Act

			// Assert
			Assert.True(TypeUtil.PrimitiveTypes.Count > 0);
		}

		[Fact]
		public void PrimitiveNullableTypesShouldNotBeNull()
		{
			// Arrange

			// Act

			// Assert
			Assert.NotNull(TypeUtil.PrimitiveNullableTypes);
		}

		[Fact]
		public void PrimitiveNullableTypesShouldNotHaveZeroCount()
		{
			// Arrange

			// Act

			// Assert
			Assert.True(TypeUtil.PrimitiveNullableTypes.Count > 0);
		}

		[Fact]
		public void NumericTypesShouldNotBeNull()
		{
			// Arrange

			// Act

			// Assert
			Assert.NotNull(TypeUtil.NumericTypes);
		}

		[Fact]
		public void NumericTypesShouldNotHaveZeroCount()
		{
			// Arrange

			// Act

			// Assert
			Assert.True(TypeUtil.NumericTypes.Count > 0);
		}

		[Fact]
		public void TypePropsShouldNotHaveZeroCount()
		{
			// Arrange

			// Act

			// Assert
			Assert.True(TypeUtil.TypeProps.Count > 0);
		}

		[Fact]
		public void PrimitivePropsShouldNotHaveZeroCount()
		{
			// Arrange

			// Act

			// Assert
			Assert.True(TypeUtil.PrimitiveProps.Count > 0);
		}

		[Fact]
		public void ComplexPropsShouldNotHaveZeroCount()
		{
			// Arrange

			// Act

			// Assert
			Assert.True(TypeUtil.ComplexProps.Count > 0);
		}

		[Theory]
		[InlineData(typeof(System.Int32), "int")]
		[InlineData(typeof(System.String), "string")]
		public void GetTypeAliasReturnsAliasCorrectly(Type type, string expectedAlias)
		{
			// Arrange

			// Act
			string result = TypeUtil.GetTypeAlias(type);

			// Assert
			Assert.Equal(expectedAlias, result);
		}

		[Fact]
		public void GetPropsCorrectlyReturnsList()
		{
			// Arrange

			// Act
			var props = TypeUtil.GetProps(typeof(System.Int32));

			// Assert
			Assert.NotNull(props);
			Assert.True(props.Count > 0);
		}

		[Fact]
		public void GetPrimitivePropsCorrectlyReturnsList()
		{
			// Arrange

			// Act
			var props = TypeUtil.GetPrimitiveProps(typeof(TestClass));

			// Assert
			Assert.NotNull(props);
			Assert.True(props.Count > 0);
		}

		[Fact]
		public void GetComplexPropsCorrectlyReturnsList()
		{
			// Arrange

			// Act
			var props = TypeUtil.GetComplexProps(typeof(TestClassNonPrimitive));

			// Assert
			Assert.NotNull(props);
			Assert.True(props.Count > 0);
		}

		[Fact]
		public void CompareGenericIsCorrectWhenFirstTermIsGreater()
		{
			// Arrange
			int expectedResult = 1;

			// Act
			int actualResult = TypeUtil.Compare<int>(2, 1);

			// Assert
			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void CompareGenericIsCorrectWhenTermsAreEqual()
		{
			// Arrange
			int expectedResult = 0;

			// Act
			int actualResult = TypeUtil.Compare<int>(2, 2);

			// Assert
			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void CompareGenericIsCorrectWhenSecondTermIsGreater()
		{
			// Arrange
			int expectedResult = -1;

			// Act
			int actualResult = TypeUtil.Compare<int>(1, 2);

			// Assert
			Assert.Equal(expectedResult, actualResult);
		}

		[Theory, MemberData(nameof(FirstTermGreaterPairs))]
		public void CompareIsCorrectWhenFirstTermIsGreater(ComparisonTerms terms)
		{
			// Arrange
			int expectedResult = 1;

			// Act
			int actualResult = TypeUtil.Compare(terms.FirstTerm, terms.SecondTerm);

			// Assert
			Assert.Equal(expectedResult, actualResult);

		}

		public static IEnumerable<object[]> FirstTermGreaterPairs()
		{
			List<ComparisonTerms> terms = new List<ComparisonTerms>()
			{
				new ComparisonTerms() {FirstTerm = Boolean.Parse("true"), SecondTerm = Boolean.Parse("false")},
				new ComparisonTerms() {FirstTerm = DateTime.MaxValue, SecondTerm = DateTime.MinValue},
				new ComparisonTerms() {FirstTerm = Int16.Parse("2"), SecondTerm = Int16.Parse("1")},
				new ComparisonTerms() {FirstTerm = Int32.Parse("2"), SecondTerm = Int32.Parse("1")},
				new ComparisonTerms() {FirstTerm = Int64.Parse("2"), SecondTerm = Int64.Parse("1")},
				new ComparisonTerms() {FirstTerm = Single.Parse("2"), SecondTerm = Single.Parse("1")},
				new ComparisonTerms() {FirstTerm = Double.Parse("2"), SecondTerm = Double.Parse("1")},
				new ComparisonTerms() {FirstTerm = Decimal.Parse("2"), SecondTerm = Decimal.Parse("1")},
				new ComparisonTerms() {FirstTerm = Guid.NewGuid(), SecondTerm = Guid.Empty},
				new ComparisonTerms() {FirstTerm = "b", SecondTerm = "a"}
			};

			return terms.Select(x => new object[] { x });
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

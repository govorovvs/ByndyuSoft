using NUnit.Framework;

namespace Calculator.Tests.Unit
{
	[TestFixture]
	public class MathematicalExpressionParserTests
	{
		private MathematicalExpressionParser _parser;

		[SetUp]
		public void SetUp()
		{
			_parser = new MathematicalExpressionParser();
		}

		[Test]
		public void ParseValueWithOneSymbol()
		{
			// arrange
			const string expression = "1";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(1);
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseValueWithMultipleSymbols()
		{
			// arrange
			const string expression = "12";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(12);
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseValueWithDot()
		{
			// arrange
			const string expression = "12.3";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(12.3m);
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseAddition()
		{
			// arrange
			const string expression = "1+2";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(1, 2, '+');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseSubtraction()
		{
			// arrange
			const string expression = "1-2";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(1, 2, '-');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseMultiplication()
		{
			// arrange
			const string expression = "1*2";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(1, 2, '*');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseDivision()
		{
			// arrange
			const string expression = "1/2";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(1, 2, '/');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseBrackets()
		{
			// arrange
			const string expression = "3*(1+2)";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(3, 1, 2, '+', '*');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParsePriorities()
		{
			// arrange
			const string expression = "3*4+5";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(3, 4, '*' , 5, '+');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseWhitespaces()
		{
			// arrange
			const string expression = "3 + 4";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(3, 4, '+');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseMultipleOperations()
		{
			// arrange
			const string expression = "2/(1-5)*6";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(2, 1, 5, '-', '/',6, '*');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseDoubleBrackets()
		{
			// arrange
			const string expression = "((3 + 4)*5)";

			// act
			var result = _parser.Parse(expression);

			// assert
			var expected = MathematicalExpressionPresentation.Create(3, 4, '+', 5, '*');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseInvalidValueThrowsAnException()
		{
			// arrange
			const string expression = "1$+2";

			// act
			Assert.Throws<ParseException>(() => _parser.Parse(expression));
		}

		[Test]
		public void ParseExtraRightBracketThrowsAnException()
		{
			// arrange
			const string expression = "(1+2))";

			// act
			Assert.Throws<ParseException>(() => _parser.Parse(expression));
		}

		[Test]
		public void ParseExtraLeftBracketThrowsAnException()
		{
			// arrange
			const string expression = "((1+2)";

			// act
			Assert.Throws<ParseException>(() => _parser.Parse(expression));
		}
	}
}
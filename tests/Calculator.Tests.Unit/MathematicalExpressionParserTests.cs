using Calculator.Operations;
using Calculator.Tests.Unit.Helpers;
using NUnit.Framework;

namespace Calculator.Tests.Unit
{
	[TestFixture]
	public class MathematicalExpressionParserTests
	{
		private MathematicalExpressionParser _parser;
		private IOperation[] _operations;

		[SetUp]
		public void SetUp()
		{
			_operations = KnownOperations.Operations;
			_parser = new MathematicalExpressionParser();
		}

		[Test]
		public void ParseValueWithOneSymbol()
		{
			// arrange
			const string expression = "1";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(1);
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseValueWithMultipleSymbols()
		{
			// arrange
			const string expression = "12";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(12);
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseValueWithDot()
		{
			// arrange
			const string expression = "12.3";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(12.3m);
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseAddition()
		{
			// arrange
			const string expression = "1+2";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(1, 2, '+');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseSubtraction()
		{
			// arrange
			const string expression = "1-2";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(1, 2, '-');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseMultiplication()
		{
			// arrange
			const string expression = "1*2";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(1, 2, '*');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseDivision()
		{
			// arrange
			const string expression = "1/2";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(1, 2, '/');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseBrackets()
		{
			// arrange
			const string expression = "3*(1+2)";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(3, 1, 2, '+', '*');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParsePriorities()
		{
			// arrange
			const string expression = "3*4+5";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(3, 4, '*' , 5, '+');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseWhitespaces()
		{
			// arrange
			const string expression = "3 + 4";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(3, 4, '+');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseMultipleOperations()
		{
			// arrange
			const string expression = "2/(1-5)*6";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(2, 1, 5, '-', '/',6, '*');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseDoubleBrackets()
		{
			// arrange
			const string expression = "((3 + 4)*5)";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(3, 4, '+', 5, '*');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void ParseInvalidValueThrowsAnException()
		{
			// arrange
			const string expression = "1$+2";

			// act
			Assert.Throws<ParseException>(() => _parser.Parse(expression, _operations));
		}

		[Test]
		public void ParseExtraRightBracketThrowsAnException()
		{
			// arrange
			const string expression = "(1+2))";

			// act
			Assert.Throws<ParseException>(() => _parser.Parse(expression, _operations));
		}

		[Test]
		public void ParseExtraLeftBracketThrowsAnException()
		{
			// arrange
			const string expression = "((1+2)";

			// act
			Assert.Throws<ParseException>(() => _parser.Parse(expression, _operations));
		}

		[Test]
		public void ParseOnlyBracketsThrowsAnException()
		{
			// arrange
			const string expression = "()";

			// act
			Assert.Throws<ParseException>(() => _parser.Parse(expression, _operations));
		}

		[Test]
		public void ParseFactorial()
		{
			// arrange
			const string expression = "5!";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(5, '!');
			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void Parse_FactorialAtTheEnd()
		{
			// arrange
			const string expression = "1+5!";

			// act
			var result = _parser.Parse(expression, _operations);

			// assert
			var expected = MathematicalExpressionBuilder.Build(1, 5, '!', '+');
			CollectionAssert.AreEqual(expected, result);
		}
	}
}
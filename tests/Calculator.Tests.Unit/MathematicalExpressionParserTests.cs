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
			CollectionAssert.AreEquivalent(expected, result);
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
			CollectionAssert.AreEquivalent(expected, result);
		}
	}
}
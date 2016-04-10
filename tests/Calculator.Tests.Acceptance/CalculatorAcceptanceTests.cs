using NUnit.Framework;

namespace Calculator.Tests.Acceptance
{
	[TestFixture]
	public class CalculatorAcceptanceTests
	{
		private Calculator _calculator;

		[SetUp]
		public void SetUp()
		{
			_calculator = Calculator.CreateDefault();
		}

		[TestCase("1", 1)]
		[TestCase("1+2", 3)]
		[TestCase("1+2*3", 7)]
		[TestCase("4*(5+1)/3", 8)]
		[TestCase("4*((5+1)/3)", 8)]
		[TestCase("5!", 120)]
		[TestCase("1+5!", 121)]
		[TestCase("2*(5!+3)", 246)]
		[TestCase("5!+3!", 126)]
		public void TestCalculate(string expression, decimal expectedResult)
		{
			// act
			decimal result = _calculator.Calculate(expression);

			// assert
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("()")]
		[TestCase("*")]
		[TestCase("1$+2")]
		[TestCase("1++2")]
		[TestCase("(1+2))")]
		[TestCase("((1+2)")]
		public void TestThrowingExceptionOnCalculate(string expression)
		{
			// act
			Assert.Throws<ParseException>(() => _calculator.Calculate(expression));
		}
	}
}

﻿using NUnit.Framework;

namespace Calculator.Tests.Acceptance
{
	[TestFixture]
	public class CalculatorAcceptanceTests
	{
		private Calculator _calculator;

		[SetUp]
		public void SetUp()
		{
			_calculator = new Calculator();
		}

		[TestCase("1+2",3)]
		[TestCase("1+2*3", 7)]
		[TestCase("4*(5+1)/3", 8)]
		[TestCase("4*((5+1)/3)", 8)]
		public void TestCalculate(string expression, decimal expectedResult)
		{
			// act
			decimal result = _calculator.Calculate(expression);

			// assert
			Assert.AreEqual(expectedResult, result);
		}
	}
}
﻿using Calculator.Operations;
using Calculator.Tests.Unit.Helpers;
using Moq;
using NUnit.Framework;

namespace Calculator.Tests.Unit
{
	[TestFixture]
	public class CalculatorTests
	{
		private Calculator _calculator;
		private Mock<MathematicalExpressionParser> _mockParser;
		private Mock<MathematicalExpressionExecutor> _mockExecutor;
		private IOperation[] _operations;

		[SetUp]
		public void SetUp()
		{
			_mockParser = new Mock<MathematicalExpressionParser>();
			_mockExecutor = new Mock<MathematicalExpressionExecutor>();
			_operations = KnownOperations.Operations;
			_calculator = new Calculator(_mockParser.Object, _mockExecutor.Object, _operations);
		}

		[Test]
		public void TestCalculate()
		{
			// arrange
			const string expression = "1+1";
			const decimal expectedResult = 10;
			var fakePresentation = CreateFakePresentation();

			_mockParser
				.Setup(x => x.Parse(expression, _operations))
				.Returns(fakePresentation);
			_mockExecutor
				.Setup(x => x.Execute(fakePresentation))
				.Returns(expectedResult);

			// act
			var result = _calculator.Calculate(expression);

			// assert
			Assert.AreEqual(expectedResult, result);
		}

		private MathematicalExpressionPresentation CreateFakePresentation()
		{
			return MathematicalExpressionBuilder.Build();
		}
	}
}
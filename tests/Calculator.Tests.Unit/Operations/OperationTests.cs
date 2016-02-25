using System;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class OperationTests
	{
		[TestCase('+', typeof(Addition))]
		[TestCase('-', typeof(Subtraction))]
		[TestCase('*', typeof(Multiplication))]
		[TestCase('/', typeof(Division))]
		[TestCase('(', typeof(LeftBracket))]
		[TestCase(')', typeof(RightBracket))]
		public void TestResolve(char symbol, Type type)
		{
			// act
			var operation = Operation.Resolve(symbol);

			// assert
			Assert.IsInstanceOf(type, operation);
		}
	}
}
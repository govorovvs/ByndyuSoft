using System.Collections.Generic;
using System.Linq;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class BinaryOperationTests
	{
		[Test]
		public void ExecuteOnStack_Gets_Two_Args_From_Stack_And_Puts_Result()
		{
			BinaryOperation binaryOp = 
				new FakeBinaryOperation();

			var stack = new Stack<decimal>();
			stack.Push(10);
			stack.Push(20);

			binaryOp.ExecuteOnStack(stack);

			Assert.That(30, Is.EqualTo(stack.Single()));
		}

		private class FakeBinaryOperation : BinaryOperation
		{
			public FakeBinaryOperation() : base('+', 3)
			{
			}

			public override decimal Execute(decimal first, decimal second)
			{
				return first+second;
			}
		}
	}
}
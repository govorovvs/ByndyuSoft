using System.Collections.Generic;
using System.Linq;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class UnaryOperationTests
	{
		[Test]
		public void ExecuteOnStack_Gets_Arg_From_Stack_And_Puts_Result()
		{
			UnaryOperation binaryOp =
				new FakeUnaryOperation();

			var stack = new Stack<decimal>();
			stack.Push(10);

			binaryOp.ExecuteOnStack(stack);

			Assert.That(-10, Is.EqualTo(stack.Single()));
		}

		private class FakeUnaryOperation : UnaryOperation
		{
			public FakeUnaryOperation() : base('-', 3)
			{
			}

			public override decimal Execute(decimal arg)
			{
				return -arg;
			}
		}
	}
}
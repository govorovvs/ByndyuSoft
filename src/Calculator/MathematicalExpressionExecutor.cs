using System.Collections.Generic;
using Calculator.Operations;

namespace Calculator
{
	public class MathematicalExpressionExecutor
	{
		public virtual decimal Execute(MathematicalExpressionPresentation presentation)
		{
			var stack = new Stack<decimal>();

			foreach (object item in presentation)
			{
				if (item is decimal)
				{
					stack.Push((decimal) item);
					continue;
				}

				var operation = (IArithmeticOperation)item;
				Calculate(stack, operation);
			}

			return stack.Peek();
		}

		private void Calculate(Stack<decimal> stack, IArithmeticOperation operation)
		{
			if (stack.Count != 2)
				throw new ParseException($"Unexpected operation '{operation.Symbol}'");

			decimal secondArgument = stack.Pop();
			decimal firstArgument = stack.Pop();

			decimal result = operation.Execute(firstArgument, secondArgument);

			stack.Push(result);
		}
	}
}
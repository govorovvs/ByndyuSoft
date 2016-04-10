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
				operation.ExecuteOnStack(stack);
			}

			return stack.Peek();
		}
	}
}
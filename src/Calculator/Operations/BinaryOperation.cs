using System.Collections.Generic;

namespace Calculator.Operations
{
	public abstract class BinaryOperation : Operation, IArithmeticOperation
	{
		protected BinaryOperation(char symbol, int priority) 
			: base(symbol, priority)
		{
		}

		public abstract decimal Execute(decimal first, decimal second);

		public void ExecuteOnStack(Stack<decimal> stack)
		{
			if (stack.Count < 2)
				throw new ParseException($"Unexpected operation '{Symbol}'");

			decimal secondArgument = stack.Pop();
			decimal firstArgument = stack.Pop();

			decimal result = Execute(firstArgument, secondArgument);

			stack.Push(result);
		}
	}
}
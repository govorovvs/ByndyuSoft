using System.Collections.Generic;

namespace Calculator.Operations
{
	public abstract class UnaryOperation : Operation, IArithmeticOperation
	{
		protected UnaryOperation(char symbol, int priority) : base(symbol, priority)
		{
		}

		public abstract decimal Execute(decimal argument);

		public void ExecuteOnStack(Stack<decimal> stack)
		{
			if (stack.Count == 0)
				throw new ParseException($"Unexpected operation '{Symbol}'");

			decimal argument = stack.Pop();

			decimal result = Execute(argument);

			stack.Push(result);
		}
	}
}
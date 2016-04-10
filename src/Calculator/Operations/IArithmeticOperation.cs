using System.Collections.Generic;

namespace Calculator.Operations
{
	public interface IArithmeticOperation : IOperation
	{
		void ExecuteOnStack(Stack<decimal> stack);
	}
}
using System.Collections.Generic;
using System.Linq;
using Calculator.Operations;

namespace Calculator
{
	internal static class OperationResolver
	{
		public static IOperation Resolve(char symbol, IEnumerable<IOperation> operations)
		{
			return operations.SingleOrDefault(x => x.Symbol == symbol);
		}
	}
}
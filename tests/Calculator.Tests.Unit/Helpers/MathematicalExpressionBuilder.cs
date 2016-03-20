using System;
using System.Collections.Generic;
using Calculator.Operations;

namespace Calculator.Tests.Unit.Helpers
{
	internal static class MathematicalExpressionBuilder
	{
		private static IOperation[] Operations
		{
			get { return KnownOperations.Operations; }
		}

		public static MathematicalExpressionPresentation Build(params object[] items)
		{
			var result = new List<object>();

			foreach (object item in items)
			{
				if (item is decimal)
					result.Add(item);
				else if (item is int)
					result.Add((decimal)(int)item);
				else if (item is IArithmeticOperation)
					result.Add(item);
				else if (item is char)
					result.Add(OperationResolver.Resolve((char)item, Operations));
				else
					throw new ArgumentException(nameof(items));
			}

			return new MathematicalExpressionPresentation(result);
		}
	}
}
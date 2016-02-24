using System;
using System.Collections.Generic;

namespace Calculator
{
	public class MathematicalExpressionParser
	{
		public virtual MathematicalExpressionPresentation Parse(string expression)
		{
			if (expression == null) throw new ArgumentNullException(nameof(expression));

			var output = new List<object>();

			output.Add(1);

			return MathematicalExpressionPresentation.Create(output);
		}
	}
}
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

			decimal value = decimal.Parse(expression);

			output.Add(value);

			return MathematicalExpressionPresentation.Create(output);
		}
	}
}
using System;

namespace Calculator
{
	public class Calculator
	{
		private readonly MathematicalExpressionParser _parser;
		private readonly MathematicalExpressionExecutor _executor;

		public Calculator()
		{
			_parser = new MathematicalExpressionParser();
			_executor = new MathematicalExpressionExecutor();
		}

		internal Calculator(MathematicalExpressionParser parser, MathematicalExpressionExecutor executor)
		{
			if (parser == null) throw new ArgumentNullException(nameof(parser));
			if (executor == null) throw new ArgumentNullException(nameof(executor));

			_parser = parser;
			_executor = executor;
		}

		public decimal Calculate(string expression)
		{
			if (expression == null) throw new ArgumentNullException(nameof(expression));

			MathematicalExpressionPresentation presentation = _parser.Parse(expression);
			decimal result = _executor.Execute(presentation);
			return result;
		}
	}
}
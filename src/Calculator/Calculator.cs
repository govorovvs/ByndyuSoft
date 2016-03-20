using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Operations;

namespace Calculator
{
	public class Calculator
	{
		private readonly MathematicalExpressionParser _parser;
		private readonly MathematicalExpressionExecutor _executor;
		private readonly IOperation[] _supportedOperations;

		public Calculator(IEnumerable<IOperation> supportedOperations)
		{
			_supportedOperations = supportedOperations.ToArray();
			_parser = new MathematicalExpressionParser();
			_executor = new MathematicalExpressionExecutor();
		}

		internal Calculator(MathematicalExpressionParser parser, MathematicalExpressionExecutor executor, IEnumerable<IOperation> supportedOperations)
			: this(supportedOperations)
		{
			if (parser == null) throw new ArgumentNullException(nameof(parser));
			if (executor == null) throw new ArgumentNullException(nameof(executor));

			_parser = parser;
			_executor = executor;
		}

		public decimal Calculate(string expression)
		{
			if (expression == null) throw new ArgumentNullException(nameof(expression));

			MathematicalExpressionPresentation presentation = 
				_parser.Parse(expression, _supportedOperations);
			decimal result = _executor.Execute(presentation);
			return result;
		}

		public static Calculator CreateDefault()
		{
			var operations = new IOperation[]
					{
						Addition.Instance,
						Subtraction.Instance,
						Multiplication.Instance,
						Division.Instance,
						LeftBracket.Instance,
						RightBracket.Instance
					};
			return new Calculator(operations);
		}
	}
}
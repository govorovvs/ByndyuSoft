using System;
using System.Globalization;
using Calculator.Operations;

namespace Calculator
{
	public class MathematicalExpressionParser
	{
		public virtual MathematicalExpressionPresentation Parse(string expression)
		{
			if (expression == null) throw new ArgumentNullException(nameof(expression));

			var state = new MathematicalExpressionParsingState();

			string valueString = string.Empty;

			for (int i = 0; i <= expression.Length; i++)
			{
				bool isTheEndOfString = i == expression.Length;
				if (isTheEndOfString)
				{
					ProcessValue(ref valueString, state);
					break;
				}

				char currentSymbol = expression[i];
				if (currentSymbol == ' ')
					continue;

				IOperation operation;
				if (TryGetOperation(currentSymbol, out operation))
				{
					ProcessOperation(ref valueString, operation, state);
					continue;
				}

				valueString += currentSymbol;
			}

			return state.ToPresentation();
		}

		private void ProcessValue(ref string valueString, MathematicalExpressionParsingState state)
		{
			if (string.IsNullOrEmpty(valueString))
				return;

			decimal value = ParseValue(valueString);
			valueString = string.Empty;
			state.AddValue(value);
		}

		private void ProcessOperation(ref string valueString, IOperation operation, MathematicalExpressionParsingState state)
		{
            ProcessValue(ref valueString, state);
			state.AddOperation(operation);
		}

		private bool TryGetOperation(char currentSymbol, out IOperation operation)
		{
			operation = Operation.Resolve(currentSymbol);
			return operation != null;
		}

		private decimal ParseValue(string valueString)
		{
			decimal value;
			if (!decimal.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
			{
				throw new ParseException($"Can't parse {valueString}");
			}

			return value;
		}
	}
}
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

			var result = new MathematicalExpressionPresentation();

			string valueString = string.Empty;

			for (int i = 0; i <= expression.Length; i++)
			{
				bool isTheEndOfString = i == expression.Length;
				if (isTheEndOfString)
				{
					ProcessValue(ref valueString, result);
					break;
				}

				char currentSymbol = expression[i];

				IArithmeticOperation operation;
				if (TryGetOperation(currentSymbol, out operation))
				{
					ProcessOperation(ref valueString, operation, result);
					continue;
				}

				valueString += currentSymbol;
			}

			result.Complete();
			return result;
		}

		private void ProcessValue(ref string valueString, MathematicalExpressionPresentation presentation)
		{
			decimal value = decimal.Parse(valueString, CultureInfo.InvariantCulture);
			presentation.AddValue(value);
			valueString = string.Empty;
		}

		private void ProcessOperation(ref string valueString, IArithmeticOperation operation, MathematicalExpressionPresentation presentation)
		{
            ProcessValue(ref valueString, presentation);
			presentation.PushOperationToStack(operation);
		}

		private bool TryGetOperation(char currentSymbol, out IArithmeticOperation operation)
		{
			if (currentSymbol == '+')
			{
				operation = Addition.Instance;
				return true;
			}

			operation = null;
			return false;
		}
	}
}
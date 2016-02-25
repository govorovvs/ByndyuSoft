﻿using System;
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
				if (currentSymbol == ' ')
					continue;

				IOperation operation;
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
			if (string.IsNullOrEmpty(valueString))
				return;

			decimal value;
			if (!decimal.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
			{
				throw new ParseException($"Can't parse {valueString}");
			}

			presentation.AddValue(value);
			valueString = string.Empty;
		}

		private void ProcessOperation(ref string valueString, IOperation operation, MathematicalExpressionPresentation presentation)
		{
            ProcessValue(ref valueString, presentation);
			presentation.AddOperation(operation);
		}

		private bool TryGetOperation(char currentSymbol, out IOperation operation)
		{
			operation = Operation.Resolve(currentSymbol);
			return operation != null;
		}
	}
}
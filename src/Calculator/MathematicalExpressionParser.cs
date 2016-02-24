using System;
using System.Collections.Generic;
using System.Globalization;
using Calculator.Operations;

namespace Calculator
{
	public class MathematicalExpressionParser
	{
		public virtual MathematicalExpressionPresentation Parse(string expression)
		{
			if (expression == null) throw new ArgumentNullException(nameof(expression));

			var output = new List<object>();
			var operationsStack = new Stack<IArithmeticOperation>();

			string valueString = string.Empty;

			for (int i = 0; i <= expression.Length; i++)
			{
				bool isTheEndOfString = i == expression.Length;
				if (isTheEndOfString)
				{
					ProcessValue(ref valueString, output);
					break;
				}

				char currentSymbol = expression[i];

				IArithmeticOperation operation;
				if (TryGetOperation(currentSymbol, out operation))
				{
					ProcessOperation(ref valueString, operation, operationsStack, output);
					continue;
				}

				valueString += currentSymbol;
			}

			MoveOperationsFromStackToOutput(operationsStack, output);
			return MathematicalExpressionPresentation.Create(output);
		}

		private void ProcessValue(ref string valueString, List<object> output)
		{
			decimal value = decimal.Parse(valueString, CultureInfo.InvariantCulture);
			output.Add(value);
			valueString = string.Empty;
		}

		private void ProcessOperation(ref string valueString, IArithmeticOperation operation, Stack<IArithmeticOperation> operationsStack, List<object> output)
		{
            ProcessValue(ref valueString, output);
			operationsStack.Push(operation);
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

		private void MoveOperationsFromStackToOutput(Stack<IArithmeticOperation> operationsStack, List<object> output)
		{
			while (operationsStack.Count != 0)
			{
				output.Add(operationsStack.Pop());
			}
		}
	}
}
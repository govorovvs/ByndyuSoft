using System.Collections.Generic;
using Calculator.Operations;

namespace Calculator
{
	internal class MathematicalExpressionParsingState
	{
		public List<object> Output { get; } = new List<object>();

		public Stack<IOperation> OperationsStack { get; } = new Stack<IOperation>();

		public void AddOperation(IOperation operation)
		{
			bool isRightBracket = RightBracket.Instance.Equals(operation);
			if (isRightBracket)
			{
				MoveStackOperationsToOutputTillLeftBracket();
				return;
			}

			bool isArithmeticOperation = operation is IArithmeticOperation;
			if (isArithmeticOperation)
			{
				MoveStackOperationsWithLessPriorityToOutput(operation.Priority);
			}

			OperationsStack.Push(operation);
		}

		public void AddValue(decimal value)
		{
			Output.Add(value);
		}

		public MathematicalExpressionPresentation ToPresentation()
		{
			MoveStackOperationsToOutput();
			if (Output.Count == 0)
			{
				throw new ParseException("Неправильное выражение");
			}

			return new MathematicalExpressionPresentation(Output);
		}

		private void MoveStackOperationsToOutputTillLeftBracket()
		{
			// До тех пор, пока верхним элементом стека не станет открывающая скобка, 
			// выталкиваем элементы из стека в выходную строку. При этом открывающая скобка удаляется из стека, 
			// но в выходную строку не добавляется. 
			// Если после этого шага на вершине стека оказывается символ функции, выталкиваем его в выходную строку. 
			// Если стек закончился раньше, чем мы встретили открывающую скобку, 
			// это означает, что в выражении не согласованы скобки.

			while (true)
			{
				bool isStackEmpty = OperationsStack.Count == 0;
				if (isStackEmpty)
				{
					throw new ParseException("Скобки не согласованы");
				}

				IOperation operationFromTheTopOfStack = OperationsStack.Pop();
				bool isLeftBracketOnTheTopOfStack = operationFromTheTopOfStack.Equals(LeftBracket.Instance);
				if (isLeftBracketOnTheTopOfStack)
				{
					break;
				}

				Output.Add(operationFromTheTopOfStack);
			}

			bool isOperationOnTheTopOfStack =
				OperationsStack.Count != 0 && OperationsStack.Peek() is IArithmeticOperation;
			if (isOperationOnTheTopOfStack)
			{
				IOperation operationFromTheTopOfStack = OperationsStack.Pop();
				Output.Add(operationFromTheTopOfStack);
			}
		}

		private void MoveStackOperationsWithLessPriorityToOutput(int priority)
		{
			while (OperationsStack.Count != 0)
			{
				if (priority > OperationsStack.Peek().Priority)
					return;

				IOperation operationFromTheTopOfStack = OperationsStack.Pop();
				Output.Add(operationFromTheTopOfStack);
			}
		}

		private void MoveStackOperationsToOutput()
		{
			while (OperationsStack.Count != 0)
			{
				IOperation operationFromTheTopOfStack = OperationsStack.Pop();
				bool isLeftBracket = LeftBracket.Instance.Equals(operationFromTheTopOfStack);
				if (isLeftBracket)
				{
					throw new ParseException("Скобки не согласованы");
				}

				Output.Add(operationFromTheTopOfStack);
			}
		}
	}
}
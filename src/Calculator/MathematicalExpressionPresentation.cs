using System;
using System.Collections;
using System.Collections.Generic;
using Calculator.Operations;

namespace Calculator
{
	public class MathematicalExpressionPresentation : IReadOnlyCollection<MathematicalExpressionPresentationItem>
	{
		private readonly List<MathematicalExpressionPresentationItem> _items;
		private readonly Stack<IOperation> _operationsStack;

		public MathematicalExpressionPresentation()
		{
			_items = new List<MathematicalExpressionPresentationItem>();
			_operationsStack = new Stack<IOperation>();
		}

		public IEnumerator<MathematicalExpressionPresentationItem> GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int Count
		{
			get { return _items.Count; }
		}

		public void AddValue(decimal value)
		{
			_items.Add(new MathematicalExpressionPresentationValueItem(value));
		}

		public void AddOperation(IArithmeticOperation operation)
		{
			if (operation == null) throw new ArgumentNullException(nameof(operation));

			_items.Add(new MathematicalExpressionPresentationOperationItem(operation));
		}

		public void PushOperationToStack(IOperation operation)
		{
			if (operation == null) throw new ArgumentNullException(nameof(operation));

			bool isRightBracket = RightBracket.Instance.Equals(operation);
			if (isRightBracket)
			{
				MoveStackOperationsToOutput(LeftBracket.Instance);
				return;
			}

			_operationsStack.Push(operation);
		}

		public void Complete()
		{
			MoveStackOperationsToOutput();
		}

		public static MathematicalExpressionPresentation Create(params object[] items)
		{
			var result = new MathematicalExpressionPresentation();

			foreach (object item in items)
			{
				if (item is decimal)
					result.AddValue((decimal)item);
				else if (item is int)
					result.AddValue((int)item);
				else if (item is IArithmeticOperation)
					result.AddOperation((IArithmeticOperation)item);
				else if (item is char)
					result.AddOperation((IArithmeticOperation)Operation.Resolve((char)item));
				else
					throw new ArgumentException(nameof(items));
			}

			return result;
		}

		private void MoveStackOperationsToOutput(IOperation whileOperation = null)
		{
			while (_operationsStack.Count != 0)
			{
				IOperation operationFromStack = _operationsStack.Pop();
				if (operationFromStack.Equals(whileOperation))
					return;

				var arithmeticOperation = (IArithmeticOperation)operationFromStack;
				AddOperation(arithmeticOperation);
			}
		}
	}
}
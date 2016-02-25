using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Calculator.Operations;

namespace Calculator
{
	public class MathematicalExpressionPresentation : IReadOnlyCollection<object>
	{
		private readonly List<object> _items;
		private readonly Stack<IOperation> _operationsStack;

		public MathematicalExpressionPresentation()
		{
			_items = new List<object>();
			_operationsStack = new Stack<IOperation>();
		}

		public IEnumerator<object> GetEnumerator()
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
			_items.Add(value);
		}

		public void AddOperation(IOperation operation)
		{
			if (operation == null) throw new ArgumentNullException(nameof(operation));

			bool isRightBracket = RightBracket.Instance.Equals(operation);
			if (isRightBracket)
			{
				MoveStackOperationsToOutputWhile(LeftBracket.Instance);
				return;
			}

			if (operation is IArithmeticOperation)
			{
				MoveStackOperationsWithLessPriorityToOutput(operation.Priority);
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
					result._items.Add(item);
				else if (item is int)
					result._items.Add((decimal)(int)item);
				else if (item is IArithmeticOperation)
					result._items.Add(item);
				else if (item is char)
					result._items.Add(Operation.Resolve((char)item));
				else
					throw new ArgumentException(nameof(items));
			}

			return result;
		}

		public override string ToString()
		{
			var items = _items.Select(x => x.ToString());
			return string.Join(" ", items);

		}

		private void MoveStackOperationsToOutputWhile(IOperation whileOperation)
		{
			while (_operationsStack.Count != 0)
			{
				IOperation operationFromStack = _operationsStack.Pop();
				if (operationFromStack.Equals(whileOperation))
				{
					return;
				}

				_items.Add(operationFromStack);
			}
		}

		private void MoveStackOperationsToOutput()
		{
			while (_operationsStack.Count != 0)
			{
				IOperation operationFromStack = _operationsStack.Pop();
				_items.Add(operationFromStack);
			}
		}

		private void MoveStackOperationsWithLessPriorityToOutput(int priority)
		{
			while (_operationsStack.Count != 0)
			{
				if (_operationsStack.Peek().Priority < priority)
					return;

				_items.Add(_operationsStack.Pop());
			}
		}
	}
}
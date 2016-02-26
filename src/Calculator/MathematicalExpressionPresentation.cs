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
				MoveStackOperationsToOutputWhileLeftBracket();
				return;
			}

			if (operation is IArithmeticOperation)
			{
				MoveStackOperationsWithLessPriorityToOutput(operation);
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

		private void MoveStackOperationsToOutputWhileLeftBracket()
		{
			// До тех пор, пока верхним элементом стека не станет открывающая скобка, 
			// выталкиваем элементы из стека в выходную строку. При этом открывающая скобка удаляется из стека, 
			// но в выходную строку не добавляется. 
			// Если после этого шага на вершине стека оказывается символ функции, выталкиваем его в выходную строку. 
			// Если стек закончился раньше, чем мы встретили открывающую скобку, 
			// это означает, что в выражении либо неверно поставлен разделитель, либо не согласованы скобки.

			while (true)
			{
				if (_operationsStack.Count == 0)
				{
					throw new ParseException($"Скобки не согласованы");
				}

				IOperation operationFromStack = _operationsStack.Pop();
				if (operationFromStack.Equals(LeftBracket.Instance))
				{
					if (_operationsStack.Count != 0 && _operationsStack.Peek() is IArithmeticOperation)
					{
						_items.Add(_operationsStack.Pop());
					}

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

		private void MoveStackOperationsWithLessPriorityToOutput(IOperation operation)
		{
			while (_operationsStack.Count != 0)
			{
				if (operation.Priority > _operationsStack.Peek().Priority)
					return;

				_items.Add(_operationsStack.Pop());
			}
		}
	}
}
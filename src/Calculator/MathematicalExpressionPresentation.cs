using System;
using System.Collections;
using System.Collections.Generic;
using Calculator.Operations;

namespace Calculator
{
	public class MathematicalExpressionPresentation : IReadOnlyCollection<MathematicalExpressionPresentationItem>
	{
		private readonly List<MathematicalExpressionPresentationItem> _items = new List<MathematicalExpressionPresentationItem>();

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

		public static MathematicalExpressionPresentation Create(params object[] items)
		{
			var result = new MathematicalExpressionPresentation();

			foreach (object item in items)
			{
				if (item is decimal)
					result.AddValue((decimal)item);
				else if (item is IArithmeticOperation)
					result.AddOperation((IArithmeticOperation)item);
				else
					throw new ArgumentException(nameof(items));
			}

			return result;
		}
	}
}
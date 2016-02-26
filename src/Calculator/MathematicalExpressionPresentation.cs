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

		internal MathematicalExpressionPresentation(IEnumerable<object> items)
		{
			_items = new List<object>(items);
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

		public static MathematicalExpressionPresentation Create(params object[] items)
		{
			var result = new List<object>();

			foreach (object item in items)
			{
				if (item is decimal)
					result.Add(item);
				else if (item is int)
					result.Add((decimal)(int)item);
				else if (item is IArithmeticOperation)
					result.Add(item);
				else if (item is char)
					result.Add(Operation.Resolve((char)item));
				else
					throw new ArgumentException(nameof(items));
			}

			return new MathematicalExpressionPresentation(result);
		}

		public override string ToString()
		{
			var items = _items.Select(x => x.ToString());
			return string.Join(" ", items);
		}
	}
}
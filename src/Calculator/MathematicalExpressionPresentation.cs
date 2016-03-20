using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

		public override string ToString()
		{
			var items = _items.Select(x => x.ToString());
			return string.Join(" ", items);
		}
	}
}
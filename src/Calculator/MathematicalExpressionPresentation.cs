﻿using System.Collections;
using System.Collections.Generic;

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
	}
}
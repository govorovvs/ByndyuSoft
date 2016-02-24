namespace Calculator
{
	public class MathematicalExpressionPresentationValueItem : MathematicalExpressionPresentationItem
	{
		public MathematicalExpressionPresentationValueItem(decimal value)
		{
			Value = value;
		}

		public decimal Value { get; }

		protected bool Equals(MathematicalExpressionPresentationValueItem other)
		{
			return Value == other.Value;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((MathematicalExpressionPresentationValueItem) obj);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}
	}
}
using Calculator.Operations;

namespace Calculator
{
	public class MathematicalExpressionPresentationOperationItem : MathematicalExpressionPresentationItem
	{
		public MathematicalExpressionPresentationOperationItem(IArithmeticOperation operation)
		{
			Operation = operation;
		}

		public IArithmeticOperation Operation { get; }

		protected bool Equals(MathematicalExpressionPresentationOperationItem other)
		{
			return Equals(Operation, other.Operation);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((MathematicalExpressionPresentationOperationItem)obj);
		}

		public override int GetHashCode()
		{
			return Operation.GetHashCode();
		}
	}
}
namespace Calculator.Operations
{
	public abstract class Operation : IOperation
	{
		protected Operation(char symbol, int priority)
		{
			Symbol = symbol;
			Priority = priority;
		}

		public char Symbol { get; }

		public int Priority { get; }

		protected bool Equals(Operation other)
		{
			return Symbol == other.Symbol;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Operation) obj);
		}

		public override int GetHashCode()
		{
			return Symbol.GetHashCode();
		}

		public override string ToString()
		{
			return Symbol.ToString();
		}
	}
}
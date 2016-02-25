using System.Linq;

namespace Calculator.Operations
{
	public abstract class Operation : IOperation
	{
		private static IOperation[] _operations;

		protected Operation(char symbol, int priority)
		{
			Symbol = symbol;
			Priority = priority;
		}

		public char Symbol { get; }

		public int Priority { get; }

		public static IOperation Resolve(char symbol)
		{
			return Operations.SingleOrDefault(x => x.Symbol == symbol);
		}

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

		private static IOperation[] Operations
		{
			get
			{
				if (_operations == null)
				{
					_operations = new IOperation[]
					{
						Addition.Instance,
						Subtraction.Instance,
						Multiplication.Instance,
						Division.Instance,
						LeftBracket.Instance,
						RightBracket.Instance
					};
				}

				return _operations;
			}
		}
	}
}
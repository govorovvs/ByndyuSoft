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
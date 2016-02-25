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
	}
}
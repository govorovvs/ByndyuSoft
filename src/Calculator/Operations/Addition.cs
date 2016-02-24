namespace Calculator.Operations
{
	public class Addition : IArithmeticOperation
	{
		public static Addition Instance = new Addition();

		private Addition()
		{
			Symbol = '+';
			Priority = 2;
		}

		public char Symbol { get; private set; }

		public int Priority { get; private set; }

		public decimal Execute(decimal first, decimal second)
		{
			return first + second;
		}
	}
}
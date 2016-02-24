namespace Calculator.Operations
{
	public class Division : IArithmeticOperation
	{
		public static readonly Division Instance = new Division();

		private Division()
		{
			Symbol = '/';
			Priority = 3;
		}

		public char Symbol { get; private set; }

		public int Priority { get; private set; }

		public decimal Execute(decimal first, decimal second)
		{
			return first / second;
		}
	}
}
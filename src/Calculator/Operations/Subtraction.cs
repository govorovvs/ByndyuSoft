namespace Calculator.Operations
{
	public class Subtraction : IArithmeticOperation
	{
		public static Subtraction Instance = new Subtraction();

		private Subtraction()
		{
			Symbol = '-';
			Priority = 2;
		}

		public char Symbol { get; private set; }

		public int Priority { get; private set; }

		public decimal Execute(decimal first, decimal second)
		{
			return first - second;
		}
	}
}
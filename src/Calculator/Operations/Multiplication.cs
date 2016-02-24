namespace Calculator.Operations
{
	public class Multiplication : IArithmeticOperation
	{
		public static readonly Multiplication Instance = new Multiplication();

		private Multiplication()
		{
			Symbol = '*';
			Priority = 3;
		}

		public char Symbol { get; private set; }

		public int Priority { get; private set; }

		public decimal Execute(decimal first, decimal second)
		{
			return first * second;
		}
	}
}
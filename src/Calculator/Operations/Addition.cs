namespace Calculator.Operations
{
	public class Addition : Operation, IArithmeticOperation
	{
		public static Addition Instance = new Addition();

		private Addition() : base('+', 2)
		{
		}

		public decimal Execute(decimal first, decimal second)
		{
			return first + second;
		}
	}
}
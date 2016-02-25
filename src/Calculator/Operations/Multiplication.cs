namespace Calculator.Operations
{
	public class Multiplication : Operation, IArithmeticOperation
	{
		public static readonly Multiplication Instance = new Multiplication();

		private Multiplication() : base('*', 3)
		{
		}

		public decimal Execute(decimal first, decimal second)
		{
			return first * second;
		}
	}
}
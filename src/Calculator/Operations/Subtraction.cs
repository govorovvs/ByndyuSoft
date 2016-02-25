namespace Calculator.Operations
{
	public class Subtraction : Operation, IArithmeticOperation
	{
		public static Subtraction Instance = new Subtraction();

		private Subtraction() : base('-',2)
		{
		}

		public decimal Execute(decimal first, decimal second)
		{
			return first - second;
		}
	}
}
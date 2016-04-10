namespace Calculator.Operations
{
	public class Multiplication : BinaryOperation
	{
		public static readonly Multiplication Instance = new Multiplication();

		private Multiplication() : base('*', 3)
		{
		}

		public override decimal Execute(decimal first, decimal second)
		{
			return first * second;
		}
	}
}
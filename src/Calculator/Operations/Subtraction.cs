namespace Calculator.Operations
{
	public class Subtraction : BinaryOperation
	{
		public static Subtraction Instance = new Subtraction();

		private Subtraction() : base('-',2)
		{
		}

		public override decimal Execute(decimal first, decimal second)
		{
			return first - second;
		}
	}
}
namespace Calculator.Operations
{
	public class Addition : BinaryOperation
	{
		public static Addition Instance = new Addition();

		private Addition() : base('+', 2)
		{
		}

		public override decimal Execute(decimal first, decimal second)
		{
			return first + second;
		}
	}
}
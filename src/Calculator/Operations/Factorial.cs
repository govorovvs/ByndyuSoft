namespace Calculator.Operations
{
	public class Factorial : UnaryOperation
	{
		public static readonly Factorial Instance = new Factorial();

		private Factorial() : base('!', 4)
		{
		}

		public override decimal Execute(decimal argument)
		{
			decimal result = 1;
			for (int i = 1; i <= argument; i++)
			{
				result *= i;
			}

			return result;
		}
	}
}
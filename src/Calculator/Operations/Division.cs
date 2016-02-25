namespace Calculator.Operations
{
	public class Division : Operation, IArithmeticOperation
	{
		public static readonly Division Instance = new Division();

		private Division() : base('/',3)
		{
		}

		public decimal Execute(decimal first, decimal second)
		{
			return first / second;
		}
	}
}
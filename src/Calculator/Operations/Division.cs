namespace Calculator.Operations
{
	public class Division : BinaryOperation
	{
		public static readonly Division Instance = new Division();

		private Division() : base('/',3)
		{
		}

		public override decimal Execute(decimal first, decimal second)
		{
			return first / second;
		}
	}
}
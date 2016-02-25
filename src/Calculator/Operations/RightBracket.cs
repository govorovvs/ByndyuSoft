namespace Calculator.Operations
{
	public class RightBracket : Operation
	{
		public static readonly RightBracket Instance = new RightBracket();

		private RightBracket() : base(')', 1)
		{
		}
	}
}
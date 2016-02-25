namespace Calculator.Operations
{
	public class LeftBracket : Operation
	{
		public static readonly LeftBracket Instance = new LeftBracket();

		private LeftBracket() : base('(', 0)
		{
		}
	}
}
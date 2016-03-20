using Calculator.Operations;

namespace Calculator.Tests.Unit.Helpers
{
	internal static class KnownOperations
	{
		public static readonly IOperation[] Operations;

		static KnownOperations()
		{
			Operations = new IOperation[]
			{
				Addition.Instance,
				Subtraction.Instance,
				Multiplication.Instance,
				Division.Instance,
				LeftBracket.Instance,
				RightBracket.Instance
			};
		}
	}
}
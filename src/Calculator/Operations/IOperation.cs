namespace Calculator.Operations
{
	public interface IOperation
	{
		char Symbol { get; }

		int Priority { get; }
	}
}
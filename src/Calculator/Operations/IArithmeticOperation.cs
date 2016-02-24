namespace Calculator.Operations
{
	public interface IArithmeticOperation
	{
		decimal Execute(decimal first, decimal second);

		char Symbol { get; }

		int Priority { get; }
	}
}
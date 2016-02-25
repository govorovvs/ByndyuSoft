namespace Calculator.Operations
{
	public interface IArithmeticOperation : IOperation
	{
		decimal Execute(decimal first, decimal second);
	}
}
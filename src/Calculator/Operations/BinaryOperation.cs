namespace Calculator.Operations
{
	public abstract class BinaryOperation : Operation
	{
		protected BinaryOperation(char symbol, int priority) 
			: base(symbol, priority)
		{
		}

		public abstract decimal Execute(decimal first, decimal second);
	}
}
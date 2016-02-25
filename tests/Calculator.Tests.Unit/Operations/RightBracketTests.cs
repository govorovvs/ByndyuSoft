using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class RightBracketTests
	{
		private RightBracket _operation;

		[SetUp]
		public void SetUp()
		{
			_operation = RightBracket.Instance;
		}

		[Test]
		public void HasLeftBracketSymbol()
		{
			// assert
			Assert.AreEqual(')', _operation.Symbol);
		}

		[Test]
		public void HasOnePriority()
		{
			// assert
			Assert.AreEqual(1, _operation.Priority);
		}
	}
}
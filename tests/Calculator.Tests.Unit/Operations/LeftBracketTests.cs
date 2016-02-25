using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class LeftBracketTests
	{
		private LeftBracket _operation;

		[SetUp]
		public void SetUp()
		{
			_operation = LeftBracket.Instance;
		}

		[Test]
		public void HasLeftBracketSymbol()
		{
			// assert
			Assert.AreEqual('(', _operation.Symbol);
		}

		[Test]
		public void HasZeroPriority()
		{
			// assert
			Assert.AreEqual(0, _operation.Priority);
		}
	}
}
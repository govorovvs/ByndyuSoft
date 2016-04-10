using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class FactorialTests
	{
		private Factorial _operation;

		[SetUp]
		public void SetUp()
		{
			_operation = Factorial.Instance;
		}

		[Test]
		public void HasExclamationMarkSymbol()
		{
			// assert
			Assert.AreEqual('!', _operation.Symbol);
		}

		[Test]
		public void HasFourPriority()
		{
			// assert
			Assert.AreEqual(4, _operation.Priority);
		}

		[Test]
		public void TestExecute()
		{
			// act
			decimal result = _operation.Execute(5);

			// assert
			Assert.AreEqual(1*2*3*4*5, result);
		}
	}
}
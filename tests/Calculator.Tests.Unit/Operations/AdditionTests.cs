using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class AdditionTests
	{
		private Addition _operation;

		[SetUp]
		public void SetUp()
		{
			_operation = Addition.Instance;
		}

		[Test]
		public void HasAddSymbol()
		{
			// assert
			Assert.AreEqual('+', _operation.Symbol);
		}

		[Test]
		public void HasTwoPriority()
		{
			// assert
			Assert.AreEqual(2, _operation.Priority);
		}

		[Test]
		public void TestExecute()
		{
			// act
			decimal result = _operation.Execute(10, 20);

			// assert
			Assert.AreEqual(30, result);
		}
	}
}
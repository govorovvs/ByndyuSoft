using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class SubtractionTests
	{
		private Subtraction _operation;

		[SetUp]
		public void SetUp()
		{
			_operation = Subtraction.Instance;
		}

		[Test]
		public void HasSubtractionSymbol()
		{
			// assert
			Assert.AreEqual('-', _operation.Symbol);
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
			Assert.AreEqual(-10, result);
		}
	}
}
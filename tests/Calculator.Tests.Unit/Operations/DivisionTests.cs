using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests.Unit.Operations
{
	[TestFixture]
	public class DivisionTests
	{
		private Division _operation;

		[SetUp]
		public void SetUp()
		{
			_operation = Division.Instance;
		}

		[Test]
		public void HasDivisionSymbol()
		{
			// assert
			Assert.AreEqual('/', _operation.Symbol);
		}

		[Test]
		public void HasThreePriority()
		{
			// assert
			Assert.AreEqual(3, _operation.Priority);
		}

		[Test]
		public void TestExecute()
		{
			// act
			decimal result = _operation.Execute(10, 3);

			// assert
			Assert.AreEqual(10.0m / 3, result);
		}
	}
}
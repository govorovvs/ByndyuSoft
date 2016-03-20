using Calculator.Tests.Unit.Helpers;
using NUnit.Framework;

namespace Calculator.Tests.Unit
{
	[TestFixture]
	public class MathematicalExpressionExecutorTests
	{
		private MathematicalExpressionExecutor _executor;

		[SetUp]
		public void SetUp()
		{
			_executor = new MathematicalExpressionExecutor();
		}

		[Test]
		public void CalculateAddition()
		{
			// arrange
			var presentation = MathematicalExpressionBuilder.Build(1, 2, '+');

			// act
			var result = _executor.Execute(presentation);

			// assert
			Assert.AreEqual(1+2, result);
		}

		[Test]
		public void CalculateMultipleOperations()
		{
			// arrange
			var presentation = MathematicalExpressionBuilder.Build(1, 2, '+', 3 ,'*');

			// act
			var result = _executor.Execute(presentation);

			// assert
			Assert.AreEqual((1 + 2)*3, result);
		}
	}
}
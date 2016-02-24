using Calculator.Operations;
using Moq;
using NUnit.Framework;

namespace Calculator.Tests.Unit
{
	[TestFixture]
	public class MathematicalExpressionPresentationTests
	{
		private MathematicalExpressionPresentation _presentation;

		[SetUp]
		public void SetUp()
		{
			_presentation = new MathematicalExpressionPresentation();
		}

		[Test]
		public void TestAddValue()
		{
			// arrange
			const decimal value = 10;

			// act
			_presentation.AddValue(value);

			// assert
			CollectionAssert.AreEquivalent(
				new[] {new MathematicalExpressionPresentationValueItem(value)}, _presentation);
		}

		[Test]
		public void TestAddOperations()
		{
			// arrange
			var fakeOperation = Mock.Of<IArithmeticOperation>();

			// act
			_presentation.AddOperation(fakeOperation);

			// assert
			CollectionAssert.AreEquivalent(
				new[] { new MathematicalExpressionPresentationOperationItem(fakeOperation) }, _presentation);
		}

		[Test]
		public void TestCreate()
		{
			// arrange
			const decimal value = 10;
			var fakeOperation = Mock.Of<IArithmeticOperation>();

			// act
			var presentation = MathematicalExpressionPresentation.Create(value, fakeOperation);

			// assert
			CollectionAssert.AreEquivalent(
				new MathematicalExpressionPresentationItem[]
				{
					new MathematicalExpressionPresentationValueItem(value),
					new MathematicalExpressionPresentationOperationItem(fakeOperation)
				}, presentation);
		}
	}
}
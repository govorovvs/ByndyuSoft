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
	}
}
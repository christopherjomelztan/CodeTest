using Moq;
using NUnit.Framework;

namespace CodeTest
{
    [TestFixture]
    public class ClassATests
    {
        private Mock<IClassB> _mockClassB;
        private ClassA _classA;

        [SetUp]
        public void Setup()
        {
            _mockClassB = new Mock<IClassB>();
            _classA = new ClassA(_mockClassB.Object);
        }

        [TestCase(5.0, 25.0)]
        [TestCase(10.0, 100.0)]
        [TestCase(7.0, 49.0)]
        public void Square_ShouldSquareValue(double numToSquare, double result)
        {
            Assert.That(_classA.Square(numToSquare), Is.EqualTo(result));
        }

        [Test]
        public void DoSomething_CallsClassBDoSomething()
        {
            _classA.DoSomething();

            _mockClassB.Verify(c => c.DoSomething(5));
        }

        [TestCase(5)]
        [TestCase(34)]
        [TestCase(18)]
        public void ReturnSomething_ReturnsFromClassBReturnSomething(int mockValue)
        {
            _mockClassB.Setup(c => c.ReturnSomething()).Returns(mockValue);
            var returnValue = _classA.ReturnSomething();

            Assert.That(returnValue, Is.EqualTo(mockValue));
        }
    }
}

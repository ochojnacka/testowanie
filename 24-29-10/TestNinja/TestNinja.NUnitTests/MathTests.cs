using TestNinja.Fundamentals;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.NUnitTests
{
    [TestFixture]
    internal class MathTests
    {
        [Test]
        public void Add_WhenCalled_ReturnsTheSumOfArguments()
        {
            var math = new Math();
            var result = math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }
    }
}

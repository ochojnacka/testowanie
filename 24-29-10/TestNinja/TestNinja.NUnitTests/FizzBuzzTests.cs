using TestNinja.Fundamentals;

namespace TestNinja.NUnitTests
{
    [TestFixture]
    internal class FizzBuzzTests
    {
        [Test]
        public void GetOutput_NumberIsDividedBy3And5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_NumberIsDividedOnlyBy3_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_NumberIsDividedOnlyBy5_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_NumberIsNotDividedBy3And5_ReturnsTheSameNumber()
        {
            var result = FizzBuzz.GetOutput(1);
            Assert.That(result, Is.EqualTo("1"));
        }
    }
}

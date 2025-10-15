using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestNinja.Fundamentals;
using Math = TestNinja.Fundamentals.Math;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        //  SetUp
        private Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }


        //[Test]
        //public void TestMethod1()
        //{
        //    //var math = new Math();
        //    var result = _math.Add(1, 2);
        //    Assert.That(result, Is.EqualTo(3));
        //}

        //[Test]
        //public void Max_FirstArgumentIsGreater_ReturnFirstArgument()
        //{
        //    //var math = new Math();
        //    var result = _math.Max(2, 1);
        //    Assert.That(result, Is.EqualTo(2));
        //}

        //[Test]
        //public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        //{
        //    //var math = new Math();
        //    var result = _math.Max(1, 2);
        //    Assert.That(result, Is.EqualTo(2));
        //}

        //[Test]
        //public void Max_ArgumentsAreEqual_ReturnSameArgument()
        //{ 
        //    //var math = new Math();
        //    var result = _math.Max(1, 1);
        //    Assert.That(result, Is.EqualTo(1));
        //}

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]

        public void Max_WhenCalled_ReturnGreatestArgument(int par1, int par2, int outcome)
        {
            var result = _math.Max(par1, par2);
            Assert.That(result, Is.EqualTo(outcome));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5); // 1, 3, 5
            // Assert.That(result, Is.Not.Empty);
            // Assert.That(result.Count(), Is.EqualTo(3));
            // Assert.That(result, Does.Contain(1));
            // Assert.That(result, Does.Contain(3));
            // Assert.That(result, Does.Contain(5));
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 })); // Exact same values regardless of order
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}

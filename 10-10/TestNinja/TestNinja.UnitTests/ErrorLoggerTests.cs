using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using TestNinja.Fundamentals;
using Assert = NUnit.Framework.Assert;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetLastErrorProperty()
        {
            var logger = new ErrorLogger();
            logger.Log("error");
            Assert.That(logger.LastError, Is.EqualTo("error"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_EmptyOrWhitespaceError_ThrowsArgumentNullException(string error)
        {
            var logger = new ErrorLogger();
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());
        }
    }
}

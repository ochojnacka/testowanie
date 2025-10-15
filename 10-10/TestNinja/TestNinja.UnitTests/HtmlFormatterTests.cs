using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using TestNinja.Fundamentals;
using Assert = NUnit.Framework.Assert;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void Format_WhenCalled_ReturnsFormattedString()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abc");

            // Specific
            Assert.That(result, Is.EqualTo("<strong>abc</strong>"));

            // General
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
            Assert.That(result, Does.Match("<strong>.*</strong>"));

        }
    }
}

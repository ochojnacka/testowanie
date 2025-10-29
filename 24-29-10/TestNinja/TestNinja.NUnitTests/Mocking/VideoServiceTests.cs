using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.NUnitTests.Mocking
{
    [TestFixture]
    internal class VideoServiceTests
    {
        var _fileReader;
        var _videoService;

        [SetUp]
        public void Setup() {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //  Moq
            _fileReader.Setup (fr => fr.Read("video.txt")).Returns("");
            
            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("Error"));

        }
    }
}

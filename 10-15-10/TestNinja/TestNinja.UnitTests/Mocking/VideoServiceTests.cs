using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //  Moq
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var service = new VideoService(fileReader.Object);
            var result = service.ReadVideoTitle();
            Assert.That(result, Does.Contain("Error"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmptystring()
        {
            var repository = new Mock<IVideoRepository>();
            repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var fileReader = new Mock<IFileReader>();

            var videoService = new VideoService(fileReader.Object, repository.Object);
            var result = videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }
    }
}

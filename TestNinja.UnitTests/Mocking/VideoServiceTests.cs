using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _repo;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repo = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repo.Object);
            
        }

        [Test]
        public void ReadVideoTitle_VideoIsEmpty_ReturnError()
        {

            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideos_NoVideos_ReturnsEmptyString()
        {
            _repo.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideos_ContainsVideos_ReturnsIdString()
        {
            var videos = new List<Video>
            {
                new Video{ Id = 1, IsProcessed = true, Title = "Titanic"},
                new Video{ Id = 2, IsProcessed = true, Title = "Minions"}
            };
            _repo.Setup(r => r.GetUnprocessedVideos()).Returns(videos);

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2"));
        }
    }
}

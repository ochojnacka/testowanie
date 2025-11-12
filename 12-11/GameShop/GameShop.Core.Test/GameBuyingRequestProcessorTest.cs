using GameShop.Core.Interface;
using Moq;

namespace GameShop.Core
{
    public class GameBuyingRequestProcessorTests
    {
        private GameBuyingRequestProcessor _processor;
        private GameBuyingRequest _request;
        private Mock<IGameBuyingRepository> _repositoryMock;
        public GameBuyingRequestProcessorTests()
        {
            _repositoryMock = new Mock<IGameBuyingRepository>();
            _processor = new GameBuyingRequestProcessor(_repositoryMock.Object);

            // Arrange
            _request = new GameBuyingRequest()
            {
                FirstName = "Cezary",
                LastName = "Walenciuk",
                Email = "walenciukc@gmail.com",
                Date = DateTime.Now
            };
        }

        [Fact]
        public void ShouldReturnBuyingGameResultWhitRequestValues()
        {
            //Act
            var processor = new GameBuyingRequestProcessor();
            GameBuyingResult result = _processor.BuyGame(_request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => BuyGame(null, _processor));

            Assert.Equal("request", exception.ParamName);
        }

        private void BuyGame(object value, GameBuyingRequestProcessor processor)
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void ShouldReturnStatusTrueWhenSendedCorrectValues()
        {
            var request = new GameBuyingRequest()
            {
                FirstName = "Oliwia",
                LastName = "Chojnacka",
                Email = "oliwiachojnack@gmail.com",
                Date = DateTime.Now
            };

            GameBuyingResult result = _processor.BuyGame(request);

            Assert.Equal(true, result.IsStatusOk);
            Assert.Equal(0, result.Errors.Count);
        }

        [Fact]
        public void ShouldSaveBoughtGame()
        {
            _processor.BuyGame(_request);

            // Arrange
            _request = new GameBuyingRequest()
            {
                FirstName = "Cezary",
                LastName = "Walenciuk",
                Email = "walenciuk@gmail.com",
                Date = DateTime.Now
            };
        }
    }
}

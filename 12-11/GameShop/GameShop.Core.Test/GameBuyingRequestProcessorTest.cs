using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Core
{
    public class GameBuyingRequestProcessorTests
    {
        private GameBuyingRequestProcessor _processor;
        public GameBuyingRequestProcessorTests()
        {
            _processor = new GameBuyingRequestProcessor();
        }

        [Fact]
        public void ShouldReturnBuyingGameResultWhitRequestValues()
        {
            // Arrange
            var request = new GameBuyingRequest()
            {
                FirstName = "Cezary",
                LastName = "Walenciuk",
                Email = "walenciukc@gmail.com",
                Date = DateTime.Now
            };

            //Act
            var processor = new GameBuyingRequestProcessor();
            GameBuyingResult result = BuyGame(request, processor);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }

        private static GameBuyingResult BuyGame(GameBuyingRequest request, GameBuyingRequestProcessor processor)
        {
            return processor.BuyGame(request);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => BuyGame(null, _processor));

            Assert.Equal("request", exception.ParamName);
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
    }
}

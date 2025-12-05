using GameShop.Core;
using GameShop.Core.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameBuyingRequestProcessorTests
{
    private Mock<IGameBuyingRepository> _repositoryMock;
    private Mock<IGameRepository> _repositoryGameMock;
    private GameBuyingRequestProcessor _processor;
    private readonly GameBuyingRequest _request;

    private bool _isGameAvailable = true;
    public GameBuyingRequestProcessorTests()
    {
        _repositoryMock = new Mock<IGameBuyingRepository>();
        _repositoryGameMock = new Mock<IGameRepository>();

        // Arrange
        _request = new GameBuyingRequest()
        {
            FirstName = "Cezary",
            LastName = "Walenciuk",
            Email = "walenciukc@gmail.com",
            Date = DateTime.Now,
            GameToBuy = new Game() { Id = 7 }
        };

        _repositoryGameMock.Setup(x => x.IsGameAvailable(_request.GameToBuy))
            .Returns(_isGameAvailable);

        _processor = new GameBuyingRequestProcessor(_repositoryMock.Object,
            _repositoryGameMock.Object);
    }

    [Fact]
    public void ShouldReturnBuyingGameResultWhitRequestValues()
    {
        //Act
        GameBuyingResult result = _processor.BuyGame(_request);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(_request.FirstName, result.FirstName);
        Assert.Equal(_request.LastName, result.LastName);
        Assert.Equal(_request.Email, result.Email);
        Assert.Equal(_request.Date, result.Date);
    }

    [Fact]
    public void ShouldThrowExecptionIfRequestIsNull()
    {
        var exception = Assert.Throws<ArgumentNullException>(
             () => _processor.BuyGame(null)
        );

        Assert.Equal("request", exception.ParamName);
    }

    [Fact]
    public void ShouldReturnStatusTrueWhenSendedCorrectValues()
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
        GameBuyingResult result = _processor.BuyGame(request);

        //Assert
        Assert.Equal(true, result.IsStatusOk);
        Assert.Equal(0, result.Errors.Count);
    }

    [Fact]
    public void ShouldSaveBoughtGame()
    {
        GameBought savedgameBought = null;

        _repositoryMock.Setup(x => x.Save(It.IsAny<GameBought>()))
            .Callback<GameBought>(game =>
            {
                savedgameBought = game;
            }
        );

        _processor.BuyGame(_request);

        _repositoryMock.Verify(x => x.Save(It.IsAny<GameBought>()), Times.Once);

        Assert.NotNull(savedgameBought);
        Assert.Equal(_request.FirstName, savedgameBought.FirstName);
        Assert.Equal(_request.LastName, savedgameBought.LastName);
        Assert.Equal(_request.Email, savedgameBought.Email);
        Assert.Equal(_request.Date, savedgameBought.Date);
        Assert.Equal(_request.GameToBuy.Id, savedgameBought.GameId);
    }

    [Fact]
    public void ShouldNotSaveBoughtGameIfGameIsNotAvailable()
    {
        _isGameAvailable = false;
        _processor.BuyGame(_request);
        _isGameAvailable = true;
        _repositoryMock.Verify(x => x.Save(It.IsAny<GameBought>()), Times.Never);
    }
}
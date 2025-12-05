using GameShop.Core;
using GameShop.Core.Interface;

public class GameBuyingRequestProcessor
{
    private IGameBuyingRepository _repository;
    private IGameRepository _gameRepository;
    private static T Create<T>(GameBuyingRequest request) where T : GameBuyingBase, new()
    {
        return new T()
        {
            Date = request.Date,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
    }

    public GameBuyingRequestProcessor(IGameBuyingRepository repository, 
        IGameRepository gameRepository)
    {
        _repository = repository;
        _gameRepository = gameRepository;
    }

    public GameBuyingResult BuyGame(GameBuyingRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        GameBought gameBought = Create<GameBought>(request);
        gameBought.GameId = request.GameToBuy.Id;

        if (_gameRepository.IsGameAvailable(request.GameToBuy))
            _repository.Save(gameBought);

        var result = Create<GameBuyingResult>(request);

        result.IsStatusOk = true;
        result.Errors = new System.Collections.Generic.List<string>();

        return result;
    }
}
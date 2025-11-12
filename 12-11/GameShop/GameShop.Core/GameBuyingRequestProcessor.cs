namespace GameShop.Core
{
    public class GameBuyingRequestProcessor
    {
        private object @object;

        public GameBuyingRequestProcessor()
        {
        }

        public GameBuyingRequestProcessor(object @object)
        {
            this.@object = @object;
        }

        public GameBuyingResult BuyGame(GameBuyingRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var result = new GameBuyingResult();

            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.Email = request.Email;
            result.Date = request.Date;
            result.IsStatusOk = true;
            result.Errors = new List<string>();

            return result;

        }
    }
}
using GameShop.Core;

public class GameBuyingRequest : GameBuyingBase
{
    public Game GameToBuy {  get; set; }
    public GameBuyingRequest()
    {
    }
}
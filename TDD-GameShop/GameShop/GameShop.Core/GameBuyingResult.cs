using GameShop.Core;

public class GameBuyingResult : GameBuyingBase
{
    //public bool IsStatusOk { get; set; }
    //public List<string> Errors { get; set; }
    public enum GameBuyingResultCode
    {
        Success = 0,
        GameIsNotAvailable = 1,
    }
    public GameBuyingResultCode StatusCode { get; set; }
}
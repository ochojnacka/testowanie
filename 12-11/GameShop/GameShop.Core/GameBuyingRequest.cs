
namespace GameShop.Core
{
    public class GameBuyingRequest
    {
        public GameBuyingRequest()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public bool IsStatusOk { get; set; }
        public List<string> Errors { get; set; }

    }
}
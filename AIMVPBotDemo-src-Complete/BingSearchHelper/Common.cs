using Microsoft.Bot.Schema;
namespace AIMVPBotDemo.BingSearchHelper
{
    public static class Common
    {
        public const string accessKey = "";
        public const string searchText = "Sachin Tendulkar";

        public static CardAction BuildViewCardAction(string url, string contentType)
        {
            return new CardAction
            {
                Type = ActionTypes.OpenUrl,
                Title = contentType == "News" ? "Read News" 
                        : contentType == "Images" ? "View Image" 
                        : contentType == "Videos" ? "Watch Video"
                        : contentType == "WebPage" ? "View Web Page"
                        : string.Empty,
                Value = url
            };
        }
    }
}

using AIMVPBotDemo.Models;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace AIMVPBotDemo.BingSearchHelper
{
    public class WebPagesHelper
    {
        const string searchUriBase = "https://australiaeast.api.cognitive.microsoft.com/bing/v7.0/search";
        const string queryString = "&responsefilter=WebPages";

        public static WebPageList BingWebPageSearch(string searchQuery)
        {
            // Construct the URI of the search request
            var uriQuery = searchUriBase + "?q=" + Uri.EscapeDataString(searchQuery) + queryString;

            // Perform the Web request and get the response
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = Common.accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            WebPageList webPages = JsonConvert.DeserializeObject<WebPageList>(json);
            return webPages;
        }

        public static List<ThumbnailCard> GetHeroCardsForWebPages(WebPageList webPages)
        {
            var cards =
                (from webPage in webPages.WebPages.Value
                 select new ThumbnailCard
                 {
                     Title = webPage.Name,
                     Subtitle = webPage.About != null ? "About: " + webPage.About.FirstOrDefault()?.Name : string.Empty,
                     Text = webPage.Snippet != null ? webPage.Snippet : string.Empty,
                     Images = new List<CardImage>
                     {
                         new CardImage
                         {
                             Alt = webPage.Snippet,
                             Tap = Common.BuildViewCardAction(webPage.Url, "WebPage"),
                             Url = webPage.ThumbnailUrl
                         }
                     },
                     Buttons = new List<CardAction>
                     {
                         Common.BuildViewCardAction(webPage.Url, "WebPage")
                     }
                 })
                .ToList();
            return cards;
        }

    }
}

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
    public class NewsHelper
    {
        const string newsUriBase = "https://australiaeast.api.cognitive.microsoft.com/bing/v7.0/news/search";

        public static News BingNewsSearch(string searchQuery)
        {
            // Construct the URI of the search request
            var uriQuery = newsUriBase + "?q=" + Uri.EscapeDataString(searchQuery);

            // Perform the Web request and get the response
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = Common.accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            News articles = JsonConvert.DeserializeObject<News>(json);
            return articles;
        }

        public static List<ThumbnailCard> GetHeroCardsForArticles(News articles)
        {
            var cards =
                (from article in articles.Value
                 select new ThumbnailCard
                 {
                     Title = article.Name,
                     Subtitle = article.About != null ? "About: " + article.About.FirstOrDefault()?.Name : string.Empty,
                     Text = article.Description != null ? article.Description : string.Empty,
                     Images = new List<CardImage>
                     {
                         new CardImage
                         {
                             Alt = article.Description,
                             Tap = Common.BuildViewCardAction(article.Url, "News"),
                             Url = article.Image.Thumbnail.ContentUrl
                         }
                     },
                     Buttons = new List<CardAction>
                     {
                         Common.BuildViewCardAction(article.Url, "News")
                     }
                 })
                .ToList();
            return cards;
        }

    }
}

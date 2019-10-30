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
    public class VideoHelper
    {
        public const string videosUriBase = "https://australiaeast.api.cognitive.microsoft.com/bing/v7.0/videos/search";

        public static Videos BingVideosSearch(string searchQuery)
        {
            // Construct the URI of the search request
            var uriQuery = videosUriBase + "?q=" + Uri.EscapeDataString(searchQuery);

            // Perform the Web request and get the response
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = Common.accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Videos recordings = JsonConvert.DeserializeObject<Videos>(json);
            return recordings;
        }

        public static List<ThumbnailCard> GetHeroCardsForVideos(Videos recordings)
        {
            var cards =
                (from recording in recordings.Value
                 select new ThumbnailCard
                 {
                     Title = recording.Name,
                     Text = recording.Description != null ? recording.Description : string.Empty,
                     Images = new List<CardImage>
                     {
                         new CardImage
                         {
                             Alt = recording.Description,
                             Tap = Common.BuildViewCardAction(recording.ContentUrl, "Videos"),
                             Url = recording.ThumbnailUrl
                         }
                     },
                     Buttons = new List<CardAction>
                     {
                         Common.BuildViewCardAction(recording.ContentUrl, "Videos")
                     }
                 })
                .ToList();
            return cards;
        }


    }
}

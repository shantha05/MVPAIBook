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
    public class ImageHelper
    {
        const string imagesUriBase = "https://australiaeast.api.cognitive.microsoft.com/bing/v7.0/images/search";

        public static Images BingImagesSearch(string searchQuery)
        {
            // Construct the URI of the search request
            var uriQuery = imagesUriBase + "?q=" + Uri.EscapeDataString(searchQuery);

            // Perform the Web request and get the response
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = Common.accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Images pictures = JsonConvert.DeserializeObject<Images>(json);
            return pictures;
        }

        public static List<ThumbnailCard> GetHeroCardsForImages(Images pictures)
        {
            var cards =
                (from picture in pictures.Value
                 select new ThumbnailCard
                 {
                     Title = picture.Name,
                     Text = picture.DatePublished != null ? "Published Date: " + picture.DatePublished.ToShortDateString() : string.Empty,
                     Images = new List<CardImage>
                     {
                         new CardImage
                         {
                             Alt = picture.Name,
                             Tap = Common.BuildViewCardAction(picture.ThumbnailUrl, "Images"),
                             Url = picture.ThumbnailUrl
                         }
                     },
                     Buttons = new List<CardAction>
                     {
                         Common.BuildViewCardAction(picture.ContentUrl, "Images")
                     }
                 })
                .ToList();
            return cards;
        }
    }
}

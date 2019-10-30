using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIMVPBotDemo.Models
{
    public class Videos
    {
        public string Id { get; set; }
        public string ReadLink { get; set; }
        public string WebSearchUrl { get; set; }
        public bool IsFamilyFriendly { get; set; }
        public VideosValue[] Value { get; set; }
        public string Scenario { get; set; }
    }

    public class VideosValue
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebSearchUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string DatePublished { get; set; }
        public VideosPublisher[] Publisher { get; set; }
        public string ContentUrl { get; set; }
        public string hostPageUrl { get; set; }
        public string EncodingFormat { get; set; }
        public string HostPageDisplayUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Duration { get; set; }
        public string MotionThumbnailUrl { get; set; }
        public string EmbedHtml { get; set; }
        public bool AllowHttpsEmbed { get; set; }
        public int ViewCount { get; set; }
        public VideosThumbnail Thumbnail { get; set; }
        public bool AllowMobileEmbed { get; set; }
        public bool IsSuperfresh { get; set; }
    }
    public class VideosPublisher
    {
        public string Name { get; set; }
    }

    public class VideosThumbnail
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}

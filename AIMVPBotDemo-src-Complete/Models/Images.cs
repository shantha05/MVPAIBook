using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIMVPBotDemo.Models
{
    public class Images
    {
        public string _type { get; set; }
        public string ReadLink { get; set; }
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public ImagesValue[] Value { get; set; }
        public int NextOffsetAddCount { get; set; }
        public bool DisplayShoppingSourcesBadges { get; set; }
        public bool DisplayRecipeSourcesBadges { get; set; }
    }

    public class ImagesValue
    {
        public string Name { get; set; }
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DatePublished { get; set; }
        public string ContentUrl { get; set; }
        public string HostPageUrl { get; set; }
        public string HostPageUrlPingSuffix { get; set; }
        public string ContentSize { get; set; }
        public string EncodingFormat { get; set; }
        public string HostPageDisplayUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ImageInsightsToken { get; set; }
        public string ImageId { get; set; }
        public string AccentColor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIMVPBotDemo.Models
{
    public class WebPageList
    {
        public string _type { get; set; }
        public WebPageItems WebPages { get; set; }
    }

    public class WebPageItems
    {
        public string WebSearchUrl { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public WebPageValue[] Value { get; set; }
    }
    public class WebPageValue
    { 
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public WebPagesAbout[] About { get; set; }
        public string DisplayUrl { get; set; }
        public string Snippet { get; set; }
        public WebPagesDeepLink[] DeepLinks { get; set; }
        public string DateLastCrawled { get; set; }
    }

    public class WebPagesAbout
    {
        public string Name { get; set; }
    }
    public class WebPagesDeepLink
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}

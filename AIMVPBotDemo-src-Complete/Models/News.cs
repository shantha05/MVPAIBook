using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIMVPBotDemo.Models
{
    public class News
    {
        public string _type { get; set; }
        public string ReadLink { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public NewsSort[] Sort { get; set; }
        public NewsValue[] Value { get; set; }
    }

    public class NewsSort
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsSelected { get; set; }
        public string Url { get; set; }
    }

    public class NewsValue
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public NewsImage Image { get; set; }
        public string Description { get; set; }
        public NewsAbout[] About { get; set; }
        public NewsProvider[] Provider { get; set; }
        public DateTime DatePublished { get; set; }
        public string Category { get; set; }
        public NewsClusteredarticle[] ClusteredArticles { get; set; }
    }

    public class NewsImage
    {
        public NewsThumbnail Thumbnail { get; set; }
    }

    public class NewsThumbnail
    {
        public string ContentUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class NewsAbout
    {
        public string ReadLink { get; set; }
        public string Name { get; set; }
    }

    public class NewsProvider
    {
        public string _type { get; set; }
        public string Name { get; set; }
    }

    public class NewsClusteredarticle
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public NewsClusteredArticleAbout[] About { get; set; }
        public NewsClusteredArticleProvider[] Provider { get; set; }
        public DateTime DatePublished { get; set; }
        public string Category { get; set; }
    }

    public class NewsClusteredArticleAbout
    {
        public string ReadLink { get; set; }
        public string Name { get; set; }
    }

    public class NewsClusteredArticleProvider
    {
        public string _type { get; set; }
        public string Name { get; set; }
    }
}

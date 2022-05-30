using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PFM5.resources.web;

namespace PFM5.resources.content
{
    public class ContentLoader
    /* This class is responsible for managing the retrieval of any information related to the
     * Anime contents present in the website. It does not perform any hard web scraping/parsing,
     * rather, mediates the interactions between the AnimeParser and the AnimeListGUI form necessities.
     */
    {
        private const string AnimeListingPattern = @"\/[0-9]*\/[^/]*";
        private const string AnimesUrl = "https://animecountdown.com/trending";
        private const string TrendingXPath =
            "/html/body/countdown-root/countdown/countdown-content/countdown-content-trending/countdown-content-trending-info";
        
        private readonly HtmlWeb _htmlWeb = new HtmlWeb();

        public Anime[] GetTrendingAnimes()
        /* Parse out a list of the trending anime links from the website and
         * send them over to the AnimeParser class to be parsed out and cleaned up.
         *
         * :return Anime[]: A list of the trending anime objects.
         */ 
        {
            HtmlDocument htmlDocument = this._htmlWeb.Load(AnimesUrl);
            HtmlNode trendingAnimes = htmlDocument.DocumentNode.SelectSingleNode(TrendingXPath);

            foreach (HtmlNode link in trendingAnimes.SelectNodes("//a[@href]"))
            {
                if (Regex.IsMatch(link.Attributes["href"].Value, AnimeListingPattern))
                {
                        
                }
            }

            return null;
        }
        
        
    }
}
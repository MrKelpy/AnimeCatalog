using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace PFM5.resources.web
{
    public static class AnimeParser
    {
        private static readonly HtmlWeb HtmlWeb = new HtmlWeb();
        
        public static Dictionary<string, dynamic> GetAnimeInfo(string animeUrl)
        /* Performs heavy parsing on the specified URL and returns the information
         * for the specific anime in a dictionary.
         *
         * :return Dictionary<string, string>: The dictionary containing the anime information
         */
        {
            HtmlDocument animePage = HtmlWeb.Load(animeUrl);
            string animeName = animePage.DocumentNode.SelectSingleNode("//h1[@class='h1']").InnerText;
            string animeLastEpisode = animePage.DocumentNode.SelectNodes("//span[@class='type-airing']")[1].InnerText;
            
        }


    }
}
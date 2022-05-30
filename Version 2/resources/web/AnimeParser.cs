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
            // Loads the URLs for the sites to scrape.
            string animeCountdownUrl = $@"https://animecountdown.com/{animeUrl}";
            string simklUrl = $@"https://simkl.com/anime/{animeUrl}";
            
            // Retrieves the information from the loaded websites
            HtmlDocument animeCountdownPage = HtmlWeb.Load(animeCountdownUrl);
            HtmlDocument simklPage = HtmlWeb.Load(simklUrl);

            string animeName = animeCountdownPage.DocumentNode.SelectSingleNode("//h1[@class='h1']").InnerText;
            string animeLastEpisode = animeCountdownPage.DocumentNode.SelectNodes("//span[@class='type-airing']")[1].InnerText;
            string animePosterUrl = simklPage.DocumentNode.SelectSingleNode("//div[@id='detailPosterImg']").Attributes["src"].Value;
        }


    }
}
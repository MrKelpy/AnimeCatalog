using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace PFM5.resources.utils
{
    public static class AnimeParser
    {
        private static readonly HtmlWeb HtmlWeb = new HtmlWeb();
        
        private static string BuildSynopsis(HtmlDocument simklPage)
        /* Accesses the simkl page for the given anime and builds the synopsis from it.
         * Because the synopsis is usually divided in two parts, extracts the first part, and checks
         * if a second one exists. If so, adds it to the first.
         * 
         * :return string: The synopsis of the anime.
         */
        {
            string synopsis = simklPage.DocumentNode.SelectSingleNode("//td[@class='SimklTVAboutDetailsText']").InnerText;
            string additionalSynopsis = simklPage.DocumentNode.SelectSingleNode("//span[@id='moreDesc']")?.InnerText;
            
            if (additionalSynopsis != null) 
                synopsis += $" {additionalSynopsis}";

            return synopsis.Length <= 495 ? synopsis : synopsis.Substring(0, 495) + " (...)";
        }
        
        public static Dictionary<string, dynamic> GetAnimeInfo(string animeUrl)
        /* Performs heavy parsing on the specified URL and returns the information
         * for the specific anime in a dictionary.
         *
         * :return Dictionary<string, string>: The dictionary containing the anime information
         */
        {
            // Loads the URLs for the sites to scrape.
            string animeCountdownUrl = $@"https://animecountdown.com{animeUrl}";
            string simklUrl = $@"https://simkl.com/anime{animeUrl}";
            HtmlDocument animeCountdownPage = HtmlWeb.Load(animeCountdownUrl);
            HtmlDocument simklPage = HtmlWeb.Load(simklUrl);
            
            // Retrieves the information from the loaded websites
            string animeName = animeCountdownPage.DocumentNode.SelectSingleNode("//h1").InnerText;
            HtmlNodeCollection contentPages = animeCountdownPage.DocumentNode.SelectNodes("//countdown-content-page-item-left-desc");
            string animeLastEpisode = 'E' + contentPages[contentPages.Count != 2 ? 2 : contentPages.Count - 1]
                .InnerText.Split(' ')[1];
            
            string animeNextEpisodeTimestampString = animeCountdownPage.DocumentNode.SelectNodes("//span")[3].Attributes["data-ts"].Value;
            int.TryParse(animeNextEpisodeTimestampString, out int animeNextEpisodeTimestamp);
            string animePosterUrl = simklPage.DocumentNode.SelectSingleNode("//img[@id='detailPosterImg']").Attributes["src"].Value;
            string animeSynopsis = BuildSynopsis(simklPage);
            
            // Creates the dictionary to return
            Dictionary<string, dynamic> rawDataDict = new Dictionary<string, dynamic>()
            {
                { "animeName", animeName },
                { "animeLastEpisode", animeLastEpisode },
                { "animeNextEpisodeTimestamp", animeNextEpisodeTimestamp },
                { "animePosterUrl", "https:" + animePosterUrl },
                { "animeImagePath", null },
                { "animeSynopsis", animeSynopsis },
                { "animeUrl", animeUrl },
                { "animeIsFavourite", false },
                { "animeFavouriteQuote", "" }
            };
        
            GC.Collect();
            return rawDataDict ;
        }


    }
}
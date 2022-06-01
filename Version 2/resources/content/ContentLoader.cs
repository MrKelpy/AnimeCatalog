using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PFM5.resources.utils;
using PFM5.resources.web;
// ReSharper disable RedundantJumpStatement

namespace PFM5.resources.content
{
    public class ContentLoader
    /* This class is responsible for managing the retrieval of any information related to the
     * Anime contents present in the website. It does not perform any hard web scraping/parsing,
     * rather, mediates the interactions between the AnimeParser and the AnimeListGUI form necessities.
     */
    {
        private const string AnimeListingPattern = @"/[0-9]{1,}/[^/]{1,}";
        private const string AnimesUrl = "https://animecountdown.com/trending";
        private const string TrendingXPath =
            "/html/body/countdown-root/countdown/countdown-content/countdown-content-trending/countdown-content-trending-info";
        
        private readonly HtmlWeb _htmlWeb = new HtmlWeb();

        public List<Anime> GetTrendingAnimes()
        /* Parse out a list of the trending anime links from the website and
         * send them over to the AnimeParser class to be parsed out and cleaned up.
         *
         * :return List<Anime>: A list of the trending anime objects.
         */ 
        {
            HtmlDocument htmlDocument = this._htmlWeb.Load(AnimesUrl);
            HtmlNode trendingAnimes = htmlDocument.DocumentNode.SelectSingleNode(TrendingXPath);
            List<Anime> trendingAnimeList = new List<Anime>();

            foreach (HtmlNode link in trendingAnimes.SelectNodes("//a[@href]"))
            {
                if (!Regex.IsMatch(link.Attributes["href"].Value, AnimeListingPattern)) continue;
                
                // Skip the anime if it's already in the registry
                if (AnimeRegistry.CheckInRegistry(link.Attributes["href"].Value)) continue;  
                
                // Parse out the anime object from the link. And add an instance of Anime to the final list
                try
                {
                    Dictionary<string, dynamic> result = AnimeParser.GetAnimeInfo(link.Attributes["href"].Value);
                    Anime newAnime = new Anime(result);
                    trendingAnimeList.Add(newAnime);
                }
                catch (Exception) { continue; } // ignored
            }

            return trendingAnimeList;
        }

        public async Task<string> LoadPosterImageFor(Anime anime)
        /* Asynchronously downloads the Poster Image for a given anime and saves
         * it into ./assets/anime_posters/<anime_name>.png
         *
         * :param Anime anime: The anime object to download the poster image for.
         * :return void:
         */
        {
            // Builds the path to save the image at
            Directory.CreateDirectory(ConfigManager.GetPathValue("anime_posters"));
            
            string animeImagePath = ConfigManager.GetPathValue("anime_posters") + $"/{anime.GetAnimeId()}" + ".png";
            animeImagePath = animeImagePath.Replace(" ", "_");
            
            // Downloads the image and saves it to the path
            if (File.Exists(animeImagePath)) return animeImagePath;
            
            try {
                await HttpClientUtils.DownloadFileAsync(anime.GetImageUrl(), animeImagePath);
            } catch (Exception) { return animeImagePath; }

            return animeImagePath;
        }
        
    }
}
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PFM5.resources.content
{
    public class ContentLoader
    /* This class is responsible for managing the retrieval of any information related to the
     * Anime contents present in the website. It does not perform any hard web scraping/parsing,
     * rather, mediates the interactions between the AnimeParser and the AnimeListGUI form necessities.
     */
    {
        private const string AnimesUrl = "https://animecountdown.com/trending";
        private readonly HttpClient _httpClient = new HttpClient();
        
        public async Task<Anime> GetTrendingAnimesAsync()
        /* Parse out a list of the trending anime links from the website and
         * send them over to the AnimeParser class to be parsed out and cleaned up.
         *
         * :return Dictionary<string, string>: A dictionary of the cleaned up relevant information for the animes
         */ 
        {
            string response = await this._httpClient.GetStringAsync(AnimesUrl);
            
            
        }
        
        
    }
}
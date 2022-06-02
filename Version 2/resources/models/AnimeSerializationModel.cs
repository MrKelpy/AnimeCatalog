using System.Collections.Generic;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace PFM5.resources.models
{
    public class AnimeSerializationModel
    /* This class implements a model to serialize and deserialize the anime data.
     */
    {
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string LastEpisode { get; set; }
        public string AnimeUrl { get; set; }
        public int NextEpisodeTimestamp { get; set; }
        public string ImageUrl { get; set; }
        public string ImagePath { get; set; }
        public bool IsFavourite { get; set; }
        public string FavouriteQuote { get; set; }

        public Anime FromSerializationModel()
        /* Returns an instance of Anime with the current instance context.
         * For this, a Dictionary<string, dynamic> has to be built.
         */
        {
            Dictionary<string, dynamic> animeDict = new Dictionary<string, dynamic>
            {
                { "animeName", this.Name },
                { "animeSynopsis", this.Synopsis },
                { "animeLastEpisode", this.LastEpisode },
                { "animeNextEpisodeTimestamp", this.NextEpisodeTimestamp },
                { "animeImagePath", this.ImagePath },
                { "animePosterUrl", this.ImageUrl },
                { "animeUrl", this.AnimeUrl },
                { "animeIsFavourite", this.IsFavourite },
                { "animeFavouriteQuote", this.FavouriteQuote }
            };

            return new Anime(animeDict);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PFM5.resources.models
{
    [SuppressMessage("ReSharper", "RedundantDefaultMemberInitializer")]
    public class Anime : IComparable<Anime>
    /* This class implements a convenient way to store and access data
     * for a given anime.
     */
    {
        public string Name { get; }
        public string Synopsis { get; }
        public string LastEpisode { get; }
        public string AnimeUrl { get; }
        public int NextEpisodeTimestamp { get; }
        public string ImageUrl { get; }
        public string ImagePath { get; set; }
        public string FavouriteQuote { get; set; }
        public bool IsFavourite { get; private set; }
        public string Id => this.AnimeUrl.Split('/')[1];

        public Anime(Dictionary<string, dynamic> animeDict)
        /* Overloading the class with a secondary constructor, usually to quickly create a new
         * instance of Anime going from a raw data dictionary.
         */
        {
            this.Name = animeDict["animeName"];
            this.Synopsis = animeDict["animeSynopsis"];
            this.LastEpisode = animeDict["animeLastEpisode"];
            this.NextEpisodeTimestamp = animeDict["animeNextEpisodeTimestamp"];
            this.ImagePath = animeDict["animeImagePath"];
            this.ImageUrl = animeDict["animePosterUrl"];
            this.AnimeUrl = animeDict["animeUrl"];
            this.IsFavourite = animeDict["animeIsFavourite"];
            this.FavouriteQuote = animeDict["animeFavouriteQuote"];
        }
        
        public AnimeSerializationModel ToSerializationModel()
        /* Returns a serializable AnimeSerializationModel with the attribute context
         * of the current instance.
         */
        {
            return new AnimeSerializationModel()
            {
                Name = this.Name,
                Synopsis = this.Synopsis,
                LastEpisode = this.LastEpisode,
                NextEpisodeTimestamp = this.NextEpisodeTimestamp,
                AnimeUrl = this.AnimeUrl,
                ImageUrl = this.ImageUrl,
                ImagePath = this.ImagePath,
                IsFavourite = this.IsFavourite,
                FavouriteQuote = this.FavouriteQuote
            };
        }
        
        public void ToggleFavourite() { this.IsFavourite = !this.IsFavourite; }
        public override string ToString() => this.Name;
        public int CompareTo(Anime other) => String.Compare(this.Name, other.Name, StringComparison.Ordinal);

    }
}
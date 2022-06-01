using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PFM5.resources.content
{
    [SuppressMessage("ReSharper", "RedundantDefaultMemberInitializer")]
    public class Anime
    /* This class implements a convenient way to store and access data
     * for a given anime.
     */
    {
        private readonly string _name;
        private readonly string _synopsis;
        private readonly string _lastEpisode;
        private readonly string _animeUrl;
        private readonly int _nextEpisodeTimestamp;
        private readonly string _imageUrl;
        private string _imagePath;
        private bool _isFavourite;
        private string _favouriteQuote;

        public Anime(Dictionary<string, dynamic> animeDict)
        /* Overloading the class with a secondary constructor, usually to quickly create a new
         * instance of Anime going from a raw data dictionary.
         */
        {
            this._name = animeDict["animeName"];
            this._synopsis = animeDict["animeSynopsis"];
            this._lastEpisode = animeDict["animeLastEpisode"];
            this._nextEpisodeTimestamp = animeDict["animeNextEpisodeTimestamp"];
            this._imagePath = animeDict["animeImagePath"];
            this._imageUrl = animeDict["animePosterUrl"];
            this._animeUrl = animeDict["animeUrl"];
            this._isFavourite = animeDict["animeIsFavourite"];
            this._favouriteQuote = animeDict["animeFavouriteQuote"];
        }
        
        // All of the getter methods for each property
        public string GetName() { return this._name; }
        public string GetSynopsis() { return this._synopsis; }
        public string GetLastEpisode() { return this._lastEpisode; }
        public int GetNextEpisodeTimestamp() { return this._nextEpisodeTimestamp; }
        public string GetImagePath() { return this._imagePath; }
        public string GetImageUrl() { return this._imageUrl; }
        public bool GetFavouriteBool() { return this._isFavourite; }
        public string GetFavouriteQuote() { return this._favouriteQuote; }
        public string GetAnimeUrl() { return this._animeUrl; }
        public string GetAnimeId() { return this.GetAnimeUrl().Split('/')[1]; }
        
        // All of the setter methods for the properties that can be changed.
        public void SetFavouriteQuote(string favouriteQuote) { this._favouriteQuote = favouriteQuote; }
        public void ToggleFavourite() { this._isFavourite = !this._isFavourite; }
        public void SetImagePath(string image) { this._imagePath = image; }
        
        // Class methods

        public AnimeSerializationModel ToSerializationModel()
        /* Returns a serializable AnimeSerializationModel with the attribute context
         * of the current instance.
         */
        {
            return new AnimeSerializationModel()
            {
                Name = this._name,
                Synopsis = this._synopsis,
                LastEpisode = this._lastEpisode,
                NextEpisodeTimestamp = this._nextEpisodeTimestamp,
                AnimeUrl = this._animeUrl,
                ImageUrl = this._imageUrl,
                ImagePath = this._imagePath,
                IsFavourite = this._isFavourite,
                FavouriteQuote = this._favouriteQuote
            };
        }
    }
}
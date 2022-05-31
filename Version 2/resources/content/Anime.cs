using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

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
        private string _imageUrl;
        private Image _image;
        private bool _isFavourite;
        private string _favouriteQuote;

        public Anime(string name, string synopsis, string lastEpisode, int nextEpisodeTimestamp,
                string imageUrl, string animeUrl)
        /* First class constructor for manual input without the need of a dictionary 
         */
        {
            this._name = name;
            this._synopsis = synopsis;
            this._lastEpisode = lastEpisode;
            this._nextEpisodeTimestamp = nextEpisodeTimestamp;
            this._imageUrl = imageUrl;
            this._animeUrl = animeUrl;
            this._isFavourite = false;
            this._favouriteQuote = string.Empty;
        }

        public Anime(Dictionary<string, dynamic> animeDict)
        /* Overloading the class with a secondary constructor, usually to quickly create a new
         * instance of Anime going from a raw data dictionary.
         */
        {
            this._name = animeDict["animeName"];
            this._synopsis = animeDict["animeSynopsis"];
            this._lastEpisode = animeDict["animeLastEpisode"];
            this._nextEpisodeTimestamp = animeDict["animeNextEpisodeTimestamp"];
            this._imageUrl = animeDict["animePosterUrl"];
            this._animeUrl = animeDict["animeUrl"];
            this._isFavourite = false;
            this._favouriteQuote = string.Empty;
        }
        
        // All of the getter methods for each property
        public string GetName() { return this._name; }
        public string GetSynopsis() { return this._synopsis; }
        public string GetLastEpisode() { return this._lastEpisode; }
        public double GetNextEpisodeTimestamp() { return this._nextEpisodeTimestamp; }
        public Image GetImage() { return this._image; }
        public string GetImageUrl() { return this._imageUrl; }
        public bool GetFavouriteBool() { return this._isFavourite; }
        public string GetFavouriteQuote() { return this._favouriteQuote; }
        public string GetAnimeUrl() { return this._animeUrl; }
        
        // All of the setter methods for the properties that can be changed.
        public void SetFavouriteQuote(string favouriteQuote) { this._favouriteQuote = favouriteQuote; }
        public void ToggleFavourite() { this._isFavourite = !this._isFavourite; }
        public void SetImage(Image image) { this._image = image; }
    }
}
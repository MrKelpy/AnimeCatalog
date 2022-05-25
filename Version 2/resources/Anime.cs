using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace PFM5.resources
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
        private readonly double _nextEpisodeTimestamp;
        private readonly Image _image;
        private bool _isFavourite = false;
        private string _favouriteQuote = string.Empty;
        
        public Anime(string name, string synopsis, string lastEpisode, double nextEpisodeTimestamp, Image image)
        {
            this._name = name;
            this._synopsis = synopsis;
            this._lastEpisode = lastEpisode;
            this._nextEpisodeTimestamp = nextEpisodeTimestamp;
            this._image = image;
        }
        
        // All of the getter methods for each property
        public string GetName() { return this._name; }
        public string GetSynopsis() { return this._synopsis; }
        public string GetLastEpisode() { return this._lastEpisode; }
        public double GetNextEpisodeTimestamp() { return this._nextEpisodeTimestamp; }
        public Image GetImage() { return this._image; }
        public bool GetIsFavourite() { return this._isFavourite; }
        public string GetFavouriteQuote() { return this._favouriteQuote; }
        
        // All of the setter methods for the properties that can be changed.
        public void SetFavouriteQuote(string favouriteQuote) { this._favouriteQuote = favouriteQuote; }
        public void ToggleFavourite() { this._isFavourite = !this._isFavourite; }
    }
}
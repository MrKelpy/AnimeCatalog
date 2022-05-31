using System.Drawing;
using System.Windows.Forms;

namespace PFM5
{
    public struct Anime
        /* This struct implements a convenient way to store information
         * about a given anime.
         */
    {
        public readonly string Name;
        public readonly string Synopsis;
        public readonly string LastEpisode;
        public readonly string NextEpisodeDate;
        public readonly Image Banner;
        public bool IsFavourite;
        public string FavouriteQuote;

        public Anime(string name, string synopsis, string lastEpisode, string nextEpisodeDate, 
            Image banner, bool isFavourite, string favouriteQuote)
        {
            this.Name = name;
            this.Synopsis = synopsis;
            this.LastEpisode = lastEpisode;
            this.NextEpisodeDate = nextEpisodeDate;
            this.Banner = banner;
            this.IsFavourite = isFavourite;
            this.FavouriteQuote = favouriteQuote;
        }
    }
    
    #region Form Code
    public partial class AnimeStruct : Form
    {
        public AnimeStruct()
        {
            InitializeComponent();
        }
    }
    #endregion
}
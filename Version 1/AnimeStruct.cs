using System.Drawing;
using System.Windows.Forms;

namespace PFM5
{
    public struct Anime
        /* This struct implements a convenient way to store the information
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
            Name = name;
            Synopsis = synopsis;
            LastEpisode = lastEpisode;
            NextEpisodeDate = nextEpisodeDate;
            Banner = banner;
            IsFavourite = isFavourite;
            FavouriteQuote = favouriteQuote;
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
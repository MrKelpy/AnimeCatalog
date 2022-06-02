using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PFM5.resources;
using PFM5.resources.models;

// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace PFM5.forms
{
    public partial class AnimeListGUI : Form
    {
        private int _navigationHeader;
        public readonly List<Anime> _animeList;

        public AnimeListGUI()
        {
            InitializeComponent();
            this.CenterToScreen();
            this._animeList = AnimeRegistry.ReadRegistry().Values.ToList();
            this.ShowCatalogPage(0);  // Displays the first page of the catalog
        }

        private void ShowCatalogPage(int catalogPage)
        /* Returns the information from the anime list array for a given index
         * and displays it correctly in the GUI catalog page.
         * 
         * This function will also update the visual header, and change the text in the favourites button
         * to remove or add the anime to the favourites list.
         *
         * :return void:
         */
        {
            // Method primary logic
            lblAnimeName.Text = this._animeList[catalogPage].GetName();
            lblSynopsis.Text = this._animeList[catalogPage].GetSynopsis();
            string formattedDate = DateTimeOffset
                .FromUnixTimeSeconds(this._animeList[catalogPage].GetNextEpisodeTimestamp()).ToString();
            lblLastEpisodeNumber.Text = @"Last Episode: " + this._animeList[catalogPage].GetLastEpisode();
            lblNextEpisodeDate.Text = @"Next Episode Date: " + formattedDate;
            pictureAnimeLogo.Image = new Bitmap(this._animeList[catalogPage].GetImagePath());
            
            // Method side effects
            lblVisualHeader.Text = $@"Page {this._navigationHeader+1} of {this._animeList.Count}";
            btnFavourites.Text = this._animeList[catalogPage].GetFavouriteBool() ? "Remove from Favourites" : "Add to Favourites";
        }

        private List<Anime> BuildFavouritesArray()
        /* Creates a List containing all of the favoured animes.
         * :return List<Anime>: The list of favoured animes.
         */
        {
            List<Anime> favouritesList = new List<Anime>();
            
            for (byte i = 0; i < this._animeList.Count; i++)
            {
                if (!this._animeList[i].GetFavouriteBool()) continue;
                favouritesList.Add(this._animeList[i]);
            }
            
            return favouritesList;
        }
        

        private void btnPrevious_Click(object sender, EventArgs e)
        /* Navigates to the previous page of the catalog. If the current page is the first page,
         * loop around to the last page.
         *
         * :return void:
         */
        {
            this._navigationHeader = 
                this._navigationHeader - 1 >= 0 ? this._navigationHeader - 1 : this._animeList.Count - 1;
            
            this.ShowCatalogPage(this._navigationHeader);
        }

        private void btnNext_Click(object sender, EventArgs e)
        /* Navigates to the next page of the catalog. If the current page is the last page,
         * loop around to the first page.
         *
         * :return void:
         */
        {
            this._navigationHeader = 
                this._navigationHeader + 1 < this._animeList.Count ? this._navigationHeader + 1 : 0;
            
            this.ShowCatalogPage(this._navigationHeader);
        }

        private void btnFavourites_Click(object sender, EventArgs e)
        /* Adds or removes the current anime from the favourites list.
         * This will also update the text of the button to reflect the new state, by updating
         * the whole page through ShowCatalogPage, and will clear the favourite quote.
         *
         * :return void:
         */
        {
            this._animeList[this._navigationHeader].ToggleFavourite();
            this.ShowCatalogPage(this._navigationHeader);
        }
    
        private void btnShowFavourites_Click(object sender, EventArgs e)
        /* Brings up the Favourite Animes Dialog, which displays the list of favourites selected.
         * :return void:
         */
        {
            List<Anime> favouriteAnimesList = this.BuildFavouritesArray();

            Favourites favouritesAnimeList = new Favourites(favouriteAnimesList, this);
            favouritesAnimeList.ShowDialog();
        }

        private void addAnimeBtn_Click(object sender, EventArgs e)
        /* Brings up four Limited Text Dialogs in succession to allow the user to add in
         * a new anime entry, and adds their results into the array.
         *
         * :return None:
         */
        { }

        private void btnDeleteAnime_Click(object sender, EventArgs e)
        /* Removes the current anime from the animes list array and updates the page.
         * The new page will be either the current index in the array, or the one before it, if the current page is the last.
         * :return void:
         */
        {
            this.RemoveAnime(this._animeList[this._navigationHeader]);
            
            // This is a semi-complex ternary operation to handle the page repositioning upon deletion of an anime.
            this._navigationHeader = this._navigationHeader > 0 || this._navigationHeader == this._animeList.Count
                    ? this._navigationHeader - 1
                    : this._navigationHeader;
            this.ShowCatalogPage(this._navigationHeader);
            
            // As a precaution, lock the delete anime button if there's only one anime left.
            if (this._animeList.Count == 1)
                btnDeleteAnime.Enabled = false;
        }
        
        private void AddAnime(Anime newAnime) => this._animeList.Add(newAnime);
        // Adds a new Anime object to the anime list array.

        private void RemoveAnime(Anime animeToRemove) => this._animeList.Remove(animeToRemove);
        // Removes an Anime object from the anime list array.
    }
}
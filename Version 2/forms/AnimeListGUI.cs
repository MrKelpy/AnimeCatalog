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
            this._animeList.Sort();
            this.ShowCatalogPage(0);  // Displays the first page of the catalog
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void ShowCatalogPage(int catalogPage)
        /* Returns the information from the anime list for a given index
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
            lblNotFound.Visible = false;
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
         * This also affects the Anime Registry.
         *
         * :return void:
         */
        {
            // Update the buffer
            this._animeList[this._navigationHeader].ToggleFavourite();
            this.ShowCatalogPage(this._navigationHeader);

            // Update the registry
            Anime anime = AnimeRegistry.RemoveFromRegistry(this._animeList[this._navigationHeader].GetAnimeUrl());
            anime.ToggleFavourite();
            AnimeRegistry.LoadIntoAnimeRegistry(anime);
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
        /* Brings up a Limited Text Dialog for the user to enter the name of the anime to add.
         * :return None:
         */
        {
            LimitedTextDialog animeNameDialog = new LimitedTextDialog(60, "Enter Anime Name");
            animeNameDialog.ShowDialog();
            
            if (animeNameDialog.DialogResult == DialogResult.OK)
                this.AddAnime(animeNameDialog.TextReturned);
        }

        private void btnHideAnime_Click(object sender, EventArgs e)
        /* Removes the current anime from the animes list list and updates the page.
         * The new page will be either the current index in the list, or the one before it, if the current page is the last.
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
                btnHideAnime.Enabled = false;
        }

        private async void AddAnime(string newAnime)
        /* Adds an anime to the current anime list list, and updates the Anime Registry
         * with the new anime.
         */
        {
            
            // If the anime is already in the list, jump to its page.
            if (this._animeList.Any(x => String.Equals(x.GetName(), newAnime, StringComparison.CurrentCultureIgnoreCase)))
            {
                Anime selectedAnime = this._animeList.Where(x 
                    => String.Equals(x.GetName(), newAnime, StringComparison.CurrentCultureIgnoreCase)).ToList()[0];
                this._navigationHeader = this._animeList.IndexOf(selectedAnime);
                this.ShowCatalogPage(_navigationHeader);
                return;
            }
                
            // Loads up the content loader and searches for a new anime
            ContentLoader contentLoader = new ContentLoader();
            Anime anime = contentLoader.SearchForAnime(newAnime);
                
            if (anime != null)
            {
                // If the anime is found, load the poster image for it and set it into the anime object.
                string animeImagePath = await contentLoader.LoadPosterImageFor(anime);
                anime.SetImagePath(animeImagePath);

                // Load the anime into the registry and the current buffer
                AnimeRegistry.LoadIntoAnimeRegistry(anime);
                this._animeList.Add(anime);
                
                // Update the page
                this._navigationHeader = this._animeList.Count - 1;
                this.ShowCatalogPage(this._navigationHeader);
            }
            else {  
                lblNotFound.Text = $@"Couldn't find anime: '{newAnime}'";
                lblNotFound.Visible = true;
            }
        }

        private void RemoveAnime(Anime animeToRemove)
        /* Removes an anime from the current anime list, and updates the Anime Registry
         * to have it also removed from there.
         * 
         * :return void
         */
        {
            this._animeList.Remove(animeToRemove);
            AnimeRegistry.RemoveFromRegistry(animeToRemove.GetName());
        }
    }
}
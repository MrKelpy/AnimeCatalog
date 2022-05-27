using System;
using System.Windows.Forms;

namespace PFM5
{
    public partial class Favourites : Form
    {
        private readonly Anime[] _favouriteList;
        private int _navigationHeader;
        private readonly AnimeListGUI _caller;

        public Favourites(Anime[] animeList, AnimeListGUI caller)
        {
            InitializeComponent();
            CenterToParent();
            this._favouriteList = animeList;
            this._caller = caller;
            this.ShowCatalogPage(0);  // Displays the first page of the catalog
        }
        
        private bool CheckForFavourites()
        /* Checks whether there is at least one favourite in the array and sets up
         * the screen for the scenario after checking.
         *
         * :return bool: True if there is at least one favourite in the array, false otherwise.
         */
        {
            if (this._favouriteList.Length == 0) return this.SetMainComponentsState(false);
            return this.SetMainComponentsState(true);
        }

        private bool SetMainComponentsState(bool state)
        /* Sets the visibility and/or accessibility of every main component
         * in the favourites catalog form into the required state.
         *
         * :return void:
         */
        {
            foreach (Control component in panelComponents.Controls)
                component.Visible = state;

            btnNext.Enabled = state;
            btnPrevious.Enabled = state;
            btnEditQuote.Enabled = state;
            lblVisualHeader.Text = state ? lblVisualHeader.Text : "There are no favourites yet.";
            return state;
        }
        
        private void ShowCatalogPage(int catalogPage)
        /* Returns the information from the anime list array for a given index
         * and displays it correctly in the GUI catalog page.
         * 
         * This function will also update the visual header.
         *
         * :return void:
         */
        {
            // Ensures that there is at least one favourite in the list
            if (!this.CheckForFavourites()) return;

            // Method primary logic
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            lblAnimeName.Text = this._favouriteList[catalogPage].Name;
            lblSynopsis.Text = this._favouriteList[catalogPage].Synopsis;
            lblLastEpisodeNumber.Text = @"Last Episode: " + this._favouriteList[catalogPage].LastEpisode;
            lblNextEpisodeDate.Text = @"Next Episode Date: " + this._favouriteList[catalogPage].NextEpisodeDate;
            pictureAnimeLogo.Image = this._favouriteList[catalogPage].Banner;
            lblQuote.Text = this._favouriteList[catalogPage].FavouriteQuote;
            
            // Method side effects
            lblVisualHeader.Text = $@"Page {this._navigationHeader+1} of {this._favouriteList.GetLength(0)}";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        /* Navigates to the previous page of the catalog. If the current page is the first page,
         * loop around to the last page.
         *
         * :return void:
         */
        {
            this._navigationHeader = 
                _navigationHeader - 1 >= 0 ? _navigationHeader - 1 : _favouriteList.GetLength(0) - 1;
            
            this.ShowCatalogPage(_navigationHeader);
        }

        private void btnNext_Click(object sender, EventArgs e)
        /* Navigates to the next page of the catalog. If the current page is the last page,
         * loop around to the first page.
         *
         * :return void:
         */
        {
            this._navigationHeader = 
                _navigationHeader + 1 < _favouriteList.GetLength(0)  ? _navigationHeader + 1 : 0;
            
            this.ShowCatalogPage(_navigationHeader);
        }

        private void btnEditQuote_Click(object sender, EventArgs e)
        /* Brings up a dialog to edit the current favourite quote for the selected anime.
         * :return void:
         */
        {
            LimitedTextDialog quoteDialog =  new LimitedTextDialog(60, initialText:_favouriteList[this._navigationHeader].FavouriteQuote);
            quoteDialog.ShowDialog();

            if (quoteDialog.DialogResult != DialogResult.OK) return;
            lblQuote.Text = quoteDialog.TextReturned;
            
            // Find and modify the anime list array with the new quote on the AnimeListGUI form.
            int currentCharacterIndex =
                Array.IndexOf(this._caller._animeList, this._favouriteList[this._navigationHeader]);
            
            this._caller._animeList[currentCharacterIndex].FavouriteQuote = quoteDialog.TextReturned;
            this._favouriteList[_navigationHeader].FavouriteQuote = quoteDialog.TextReturned;
        }
        
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}
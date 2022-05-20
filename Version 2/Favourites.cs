using System;
using System.Drawing;
using System.Windows.Forms;

namespace PFM5
{
    public partial class Favourites : Form
    {
        private readonly object[,] _favouriteList;
        private int _navigationHeader;
        private readonly AnimeListGUI _caller;

        public Favourites(object[,] animeList, AnimeListGUI caller)
        {
            InitializeComponent();
            CenterToParent();
            this._favouriteList = animeList;
            this._caller = caller;
            this.ShowCatalogPage(0);  // Displays the first page of the catalog
        }
        
        private void btnBack_Click(object sender, EventArgs e) => this.Close();
        
        private bool CheckForFavourites()
        /* Checks whether there is at least one favourite in the list and sets up
         * the screen for the scenario after checking.
         *
         * :return bool: True if there is at least one favourite in the list, false otherwise.
         */
        {
            if (!this.IsMatrixEmpty(_favouriteList)) return this.SetMainComponentsState(false);
            return this.SetMainComponentsState(true);
        }

        private bool SetMainComponentsState(bool state)
        /* Sets the visibility and/or accessibility of every main component
         * in the favourites catalog form into the requires state.
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

        private bool IsMatrixEmpty(object[,] matrix)
        /* Checks if a given matrix is empty or no favourites exist inside it.
         * :return bool: Whether the matrix is empty or not.
         */
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] != default(object[,]) && (bool) matrix[i, 5])
                        return true; // One of the values isn't defaulted and is favoured so the matrix isn't empty

            } return false;  // All the values are defaulted so the matrix is empty 
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
            lblAnimeName.Text = this._favouriteList[catalogPage, 0].ToString();
            lblSynopsis.Text = this._favouriteList[catalogPage, 1].ToString();
            lblLastEpisodeNumber.Text = @"Last Episode: " + this._favouriteList[catalogPage, 2];
            lblNextEpisodeDate.Text = @"Next Episode Date: " + this._favouriteList[catalogPage, 3];
            pictureAnimeLogo.Image = (Image) this._favouriteList[catalogPage, 4];
            lblQuote.Text = this._favouriteList[catalogPage, 6].ToString();
            
            // Method side effects
            lblVisualHeader.Text = $@"Page {_navigationHeader+1} of {_favouriteList.GetLength(0)}";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        /* Navigates to the previous page of the catalog. If the current page is the first page,
         * loop around to the last page.
         *
         * :return void:
         */
        {
            this._navigationHeader = _navigationHeader - 1 >= 0 ? _navigationHeader - 1 : _favouriteList.GetLength(0) - 1;
            this.ShowCatalogPage(_navigationHeader);
        }

        private void btnNext_Click(object sender, EventArgs e)
        /* Navigates to the next page of the catalog. If the current page is the last page,
         * loop around to the first page.
         *
         * :return void:
         */
        {
            this._navigationHeader = _navigationHeader + 1 < _favouriteList.GetLength(0)  ? _navigationHeader + 1 : 0;
            this.ShowCatalogPage(_navigationHeader);
        }

        private void btnEditQuote_Click(object sender, EventArgs e)
        /* Brings up a dialog to edit the current favourite quote for the selected anime.
         * :return void:
         */
        {
            QuoteDialog quoteDialog = new QuoteDialog(_favouriteList[_navigationHeader, 6].ToString());
            quoteDialog.ShowDialog();

            if (quoteDialog.DialogResult == DialogResult.OK)
            {
                lblQuote.Text = quoteDialog.QuoteText;
                
                // Find and modify the anime list array with the new quote on the AnimeListGUI form.
                int currentCharacterIndex =
                    this.FindIndexOfArrayWithElementInMatrix(this._caller._animeList, _favouriteList[_navigationHeader, 1]);
                
                this._caller._animeList[currentCharacterIndex, 6] = quoteDialog.QuoteText;
                this._favouriteList[_navigationHeader, 6] = quoteDialog.QuoteText;
            }
        }

        private int FindIndexOfArrayWithElementInMatrix(object[,] matrix, object element)
        /* Iterates over a given matrix and returns the index of the first occurence
         * of an array with a certain element within.
         *
         * :return int: The index of the array. If not found, returns -1.
         */
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == element)
                        return i;
            }
            return -1;
        }
    }
}
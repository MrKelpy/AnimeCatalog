using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using PFM5.resources;

// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace PFM5
{
    public partial class AnimeListGUI : Form
    {
        #region Synopsises
        private static String _synopsisAttackOnTitan =
            "Attack on Titan (Japanese: 進撃の巨人) is a Japanese manga series written and illustrated by Hajime Isayama. It is set in a world where humanity is forced to live in cities surrounded by three enormous walls that protect them from gigantic man-eating humanoids referred to as Titans; the story follows Eren Yeager, who vows to exterminate the Titans after they bring about the destruction of his hometown and the death of his mother.";

        private static String _synopsisOnePiece = 
            @"One Piece is a Japanese manga series written and illustrated by Eiichiro Oda. The story follows the adventures of Monkey D. Luffy, a boy whose body gained the properties of rubber after unintentionally eating a Devil Fruit. With his pirate crew, the Straw Hat Pirates, Luffy explores the Grand Line in search of the deceased King of the Pirates Gol D Roger's ultimate treasure known as the 'One Piece' in order to become the next King of the Pirates.";
        
        private static String _synopsisAssassination = 
            @"Assassination Classroom is a Japanese science fiction comedy manga series written and illustrated by Yusei Matsui. The series follows the daily life of an extremely powerful octopus-like being working as a junior high homeroom teacher, and his students dedicated to the task of assassinating him to prevent Earth from being destroyed. The students are considered “misfits” in their school and are taught in a separate building; the class he teaches is called 3-E.";

        private static String _synopsisJujutsu =
            @"Jujutsu Kaisen (呪術廻戦) is a Japanese manga series written and illustrated by Gege Akutami. The story follows high school student Yuji Itadori as he joins a secret organization of Jujutsu Sorcerers in order to kill a powerful Curse named Ryomen Sukuna, of whom Yuji becomes the host.";

        private static String _synopsisKaguyaSama =
            @"In the senior high school division of Shuchiin Academy, student council president Miyuki Shirogane and vice president Kaguya Shinomiya appear to be a perfect match. Kaguya is the daughter of a wealthy conglomerate family, and Miyuki is the top student at the school and well-known across the prefecture. Although they like each other, they are too proud to confess their love, as they believe whoever does so first would lose. The story follows their many schemes to make the other one confess or at least show signs of affection.";
        
        #endregion
        private int _navigationHeader;
            
        // This will be changed in v2 for a dynamic list of anime fetched from some websites.
        // The format for the information in these arrays is:
        // NAME, SYNOPSIS, EPISODE NUMBER, NEXT EPISODE, IMAGE, IS_FAVOURITE, FAVOURITE QUOTE
        public ArrayList _animeList = new ArrayList();

            public AnimeListGUI()
        {
            InitializeComponent();
            this.CenterToScreen();
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
            lblAnimeName.Text = this._animeList[catalogPage, 0].ToString();
            lblSynopsis.Text = this._animeList[catalogPage, 1].ToString();
            lblLastEpisodeNumber.Text = @"Last Episode: " + this._animeList[catalogPage, 2];
            lblNextEpisodeDate.Text = @"Next Episode Date: " + this._animeList[catalogPage, 3];
            pictureAnimeLogo.Image = (Image) this._animeList[catalogPage, 4];
            
            // Method side effects
            lblVisualHeader.Text = $@"Page {this._navigationHeader+1} of {this._animeList.GetLength(0)}";
            btnFavourites.Text = (bool) this._animeList[catalogPage, 5]? "Remove from Favourites" : "Add to Favourites";
        }
        
        private int GetFavouriteAnimeCount()
        /* Iterates over all of the registered animes and returns the count of those
         * that are favoured.
         *
         * :return void:
         */
        {
            int favouriteCount = 0;

            for (byte i = 0; i < this._animeList.GetLength(0); i++)
            {
                if ((bool) this._animeList[i, 5])
                    favouriteCount++;
            }

            return favouriteCount;
        }
        
        private object[,] BuildFavouritesMatrix()
        /* Creates a new matrix with only the registered favourite animes.
         * :return object[,]: The new array containing only the favourites.
         */
        {
            int newMatrixSize = this.GetFavouriteAnimeCount();
            object[,] newMatrix = new object[newMatrixSize, this._animeList.GetLength(1)];
            int newMatrixHeader = 0;  // The header controls the x position of the new matrix for copying.
            
            for (byte i = 0; i < this._animeList.GetLength(0); i++)
            {
                if (!(bool) this._animeList[i, 5]) 
                    continue;
                
                // Copy the values from the old matrix to the new one
                for (int j = 0; j < this._animeList.GetLength(1); j++)
                    newMatrix[newMatrixHeader, j] = this._animeList[i, j];
                
                newMatrixHeader += 1;  // Jump to the next available node
            }
            
            return newMatrix;
        }

        private void AddAnime(object[] newAnimeArray)
            /* Gathers the anime list matrix and adds a new anime into it.
             * :return void:
             */
        {
            int newMatrixSize = this._animeList.GetLength(0) + 1;
            object[,] newMatrix = new object[newMatrixSize, this._animeList.GetLength(1)];

            // Copy the old matrix to the new one
            for (int i = 0; i < this._animeList.GetLength(0); i++)
            {
                for (int j = 0; j < this._animeList.GetLength(1); j++)
                    newMatrix[i, j] = this._animeList[i, j];
            }

            // Add the new anime to the new matrix
            for (int i = 0; i < newAnimeArray.Length; i++)
                newMatrix[newMatrixSize - 1, i] = newAnimeArray[i];

            // Update the anime list matrix
            this._animeList = newMatrix;
        }

        private void RemoveAnime(string animeToRemove)
        /* Gathers the anime list matrix and copies it to a new one, excluding
         * the anime to remove. This will match with the anime name.
         * Afterwards, update the old matrix with the new one.
         *
         * :return void:
         */
        {
            int newMatrixSize = this._animeList.GetLength(0) - 1;
            object[,] newMatrix = new object[newMatrixSize, this._animeList.GetLength(1)];
            int newMatrixHeader = 0;  // The header controls the x position of the new matrix for copying.
            
            // Copy the old matrix to the new one, excluding the anime to remove.
            for (int i = 0; i < this._animeList.GetLength(0); i++)
            {
                if (this._animeList[i, 0].ToString() == animeToRemove)
                    continue;

                for (int j = 0; j < newMatrix.GetLength(1); j++)
                    newMatrix[newMatrixHeader, j] = this._animeList[i, j];
                
                // Increments the header to the next available node, to mimic the iteration number.
                newMatrixHeader += 1;
            }
            
            // Update the list matrix
            this._animeList = newMatrix;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
            /* Navigates to the previous page of the catalog. If the current page is the first page,
             * loop around to the last page.
             *
             * :return void:
             */
        {
            this._navigationHeader = 
                this._navigationHeader - 1 >= 0 ? this._navigationHeader - 1 : this._animeList.GetLength(0) - 1;
            
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
                this._navigationHeader + 1 < this._animeList.GetLength(0) ? this._navigationHeader + 1 : 0;
            
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
            this._animeList[this._navigationHeader, 5] = !(bool) this._animeList[this._navigationHeader, 5];
            this._animeList[this._navigationHeader, 6] = "";
            this.ShowCatalogPage(this._navigationHeader);
        }
    
        private void btnShowFavourites_Click(object sender, EventArgs e)
        /* Brings up the Favourite Animes Dialog, which displays the list of favourites selected.
         * :return void:
         */
        {
            object[,] favouriteAnimesArray = this.BuildFavouritesMatrix();

            Favourites favouritesAnimeList = new Favourites(favouriteAnimesArray, this);
            favouritesAnimeList.ShowDialog();
        }

        private void addAnimeBtn_Click(object sender, EventArgs e)
        /* Brings up four Limited Text Dialogs in succession to allow the user to add in
         * a new anime entry.
         *
         * :return None:
         */
        {
            // Prepares all the dialogs with the anime information in them.
            LimitedTextDialog animeNameDialog = new LimitedTextDialog(50, dialogName:"Anime Name");
            LimitedTextDialog animeSynopsisDialog = new LimitedTextDialog(500, dialogName:"Anime Synopsis");
            LimitedTextDialog animeLastEpisodeDialog = new LimitedTextDialog(10, dialogName:"Last Episode");
            LimitedTextDialog animeNextEpisodeDialog = new LimitedTextDialog(10, dialogName:"Next Episode Date");
            LimitedTextDialog[] animeDialogArray = {animeNameDialog, animeSynopsisDialog, animeLastEpisodeDialog, animeNextEpisodeDialog};
            
            // Loops through the dialogs verifying the dialog results.
            foreach (var animeDialog in animeDialogArray)
            {
                animeDialog.ShowDialog();
                if (animeDialog.DialogResult == DialogResult.Cancel) return;
            }
            
            // Builds a new array with the new info, and adds that array into the matrix.
            object[] newAnimeArray = {animeNameDialog.TextReturned, animeSynopsisDialog.TextReturned,
                animeLastEpisodeDialog.TextReturned, animeNextEpisodeDialog.TextReturned, Resources.animes, false, ""};
            
            this.AddAnime(newAnimeArray);
            this._navigationHeader = this._animeList.GetLength(0) - 1;
            this.ShowCatalogPage(this._navigationHeader);
            
            // Unlock the delete anime button if there's more than one anime.
            if (this._animeList.GetLength(0) > 1)
                btnDeleteAnime.Enabled = true;
        }

        private void btnDeleteAnime_Click(object sender, EventArgs e)
        /* Removes the current anime from the animes list matrix and updates the page.
         * The new page will be either the current index in the array, or the one before it, if the current page is the last.
         * :return void:
         */
        {
            this.RemoveAnime(this._animeList[this._navigationHeader, 0].ToString());
            this._navigationHeader = this._navigationHeader > 0 || this._navigationHeader == this._animeList.GetLength(0)
                    ? this._navigationHeader - 1
                    : this._navigationHeader;
            this.ShowCatalogPage(this._navigationHeader);
            
            // As a precaution, lock the delete anime button if there's only one anime left.
            if (this._animeList.GetLength(0) == 1)
                btnDeleteAnime.Enabled = false;
        }
    }
}
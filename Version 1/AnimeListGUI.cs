using System;
using System.Drawing;
using System.Windows.Forms;
using PFM5.Properties;
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
        public readonly object[,] _animeList =  {
            {"Attack on Titan", _synopsisAttackOnTitan, "S4E28", "2023", Resources.attack_on_titan, false, ""},
            {"One Piece", _synopsisOnePiece, "1017", "May 15, 2022", Resources.onepiece, false, ""},
            {"Assassination Classroom", _synopsisAssassination, "47", "Finished", Resources.ansatsu_kyoshitsu, false, ""},
            {"Jujutsu Kaisen", _synopsisJujutsu, "S1E24", "2023", Resources.jujutsu_kaisen, false, ""},
            {"Kaguya-Sama: Love is War", _synopsisKaguyaSama, "S3E6", "May 20 2022", Resources.kaguya, false, ""}
        };
        
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
    }
}
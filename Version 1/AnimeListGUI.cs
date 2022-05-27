using System;
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
        
        public Anime[] _animeList =  {
            new Anime("Attack on Titan", _synopsisAttackOnTitan, "S4E28", "2023", Resources.attack_on_titan, false, ""),
            new Anime("One Piece", _synopsisOnePiece, "1017", "May 15, 2022", Resources.onepiece, false, ""),
            new Anime("Assassination Classroom", _synopsisAssassination, "47", "Finished", Resources.ansatsu_kyoshitsu, false, ""),
            new Anime("Jujutsu Kaisen", _synopsisJujutsu, "S1E24", "2023", Resources.jujutsu_kaisen, false, ""),
            new Anime("Kaguya-Sama: Love is War", _synopsisKaguyaSama, "S3E6", "May 20 2022", Resources.kaguya, false, "")
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
            lblAnimeName.Text = this._animeList[catalogPage].Name;
            lblSynopsis.Text = this._animeList[catalogPage].Synopsis;
            lblLastEpisodeNumber.Text = @"Last Episode: " + this._animeList[catalogPage].LastEpisode;
            lblNextEpisodeDate.Text = @"Next Episode Date: " + this._animeList[catalogPage].NextEpisodeDate;
            pictureAnimeLogo.Image = this._animeList[catalogPage].Banner;
            
            // Method side effects
            lblVisualHeader.Text = $@"Page {this._navigationHeader+1} of {this._animeList.GetLength(0)}";
            btnFavourites.Text = this._animeList[catalogPage].IsFavourite ? "Remove from Favourites" : "Add to Favourites";
        }

        private Anime[] BuildFavouritesArray()
        /* Creates a new Array of Anime objects that have the IsFavourite field set to True.
         * :return Anime[]: The array of Anime objects that have the IsFavourite field set to True.
         */
        {
            int lengthHeader = 0;
            Anime[] newArray = new Anime[this._animeList.GetLength(0)];
            
            for (byte i = 0; i < this._animeList.GetLength(0); i++)
            {
                if (!this._animeList[i].IsFavourite) continue;
                newArray[lengthHeader] = this._animeList[i];
                lengthHeader += 1;
            }
            
            Array.Resize(ref newArray, lengthHeader);
            return newArray;
        }

        private void AddAnime(Anime newAnime)
        /* Resizes the Array to be one element larger, and adds the new Anime object to the end of the array.
         * :return void:
         */
        {
            Array.Resize(ref this._animeList, this._animeList.Length + 1);

            // Update the anime list array
            this._animeList[this._animeList.GetUpperBound(0)] = newAnime;
        }

        private void RemoveAnime(Anime animeToRemove)
        /* Searches for the given Anime object in the array, and stores its index. From there, moves
         * every element (starting from the target index+1) in the array one index to the left,
         * and resizes the array to be one element smaller.
         * 
         * :return void:
         */
        {
            int indexToRemove = Array.IndexOf(this._animeList, animeToRemove);
            if (indexToRemove == -1) return;  // If the anime is not found, do nothing
            
            // Move every element in the array one index to the left, starting from the target index
            for (int i = indexToRemove + 1; i < this._animeList.GetLength(0); i++)
                this._animeList[i - 1] = this._animeList[i];
            
            Array.Resize(ref this._animeList, this._animeList.Length - 1);
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
            this._animeList[this._navigationHeader].IsFavourite = !this._animeList[this._navigationHeader].IsFavourite;
            this._animeList[this._navigationHeader].FavouriteQuote = "";
            this.ShowCatalogPage(this._navigationHeader);
        }
    
        private void btnShowFavourites_Click(object sender, EventArgs e)
        /* Brings up the Favourite Animes Dialog, which displays the list of favourites selected.
         * :return void:
         */
        {
            Anime[] favouriteAnimesArray = this.BuildFavouritesArray();

            Favourites favouritesAnimeList = new Favourites(favouriteAnimesArray, this);
            favouritesAnimeList.ShowDialog();
        }

        private void addAnimeBtn_Click(object sender, EventArgs e)
        /* Brings up four Limited Text Dialogs in succession to allow the user to add in
         * a new anime entry, and adds their results into the array.
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
            
            // Builds a new array with the new info, and adds that array into the array.
            Anime newAnime = new Anime(animeNameDialog.TextReturned, animeSynopsisDialog.TextReturned, animeLastEpisodeDialog.TextReturned,
                animeNextEpisodeDialog.TextReturned, Resources.animes, false, "");
            
            this.AddAnime(newAnime);
            this._navigationHeader = this._animeList.GetLength(0) - 1;
            this.ShowCatalogPage(this._navigationHeader);  // Show the new anime page.
            
            // Unlock the delete anime button if there's more than one anime.
            if (this._animeList.GetLength(0) > 1)
                btnDeleteAnime.Enabled = true;
        }

        private void btnDeleteAnime_Click(object sender, EventArgs e)
        /* Removes the current anime from the animes list array and updates the page.
         * The new page will be either the current index in the array, or the one before it, if the current page is the last.
         * :return void:
         */
        {
            this.RemoveAnime(this._animeList[this._navigationHeader]);
            
            // This is a semi-complex ternary operation to handle the page repositioning upon deletion of an anime.
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
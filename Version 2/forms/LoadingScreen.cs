using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PFM5.resources;
using PFM5.resources.models;

namespace PFM5.forms
{
    public partial class LoadingScreen : Form
    {
        // Dynamic loading of images :D
        private readonly List<Bitmap> _loadingImages = new List<Bitmap>();
        
        public LoadingScreen()
        {
            InitializeComponent();
            this.BuildLoadingImagesList();
            this.HandleStartup();
        }

        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        private void HandleStartup()
        /* Handles the creation of the loading screen and starts up the actual program.
         * :return void:
         */
        {
            this.SetRandomLoadingImage();
            this.AestheticFix();
        }
        
        private void SetRandomLoadingImage()
        /* Sets the background to a random Loading image from the provided Resources folder.
         * Also sets the loading gif into the loading picture box
         * :return void:
         */
        {
            var randomLoadingImage = this._loadingImages[new Random().Next(this._loadingImages.Count)];
            this.BackgroundImage = randomLoadingImage;
        }

        private void AestheticFix()
        /* Fixes the form and image to present itself in the best light for the user.
         * This will resize the form to fit the image perfectly and center the form to the center of the screen.
         * The values for the form size are according to my personal preferences.
         *
         * :return void:
         */
        {
            // Adjusts the new width to be half of the screen's width 
            int width = Screen.FromControl(this).Bounds.Width / 2;
            
            // Based on the new width, adjust the height in the context of the image.
            int height = (this.BackgroundImage.Height * width) / this.BackgroundImage.Width;
            
            this.Size = new Size(width, height);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.CenterToScreen();
            Cursor.Current = Cursors.Arrow;
        }

        private void BuildLoadingImagesList()
        /* Iterates over the assets directory and builds the Bitmap list containing all of the
         * loading images within.
         *
         * :return void:
         */
        {
            // Gather the list of files in the assets directory
            string loadingImagesPath = ConfigManager.GetPathValue("loadingScreens");
            string[] loadingImages = Directory.GetFiles(loadingImagesPath);
            
            // Add all of the images into the bitmap list
            foreach (var loadingScreen in loadingImages)
                this._loadingImages.Add(new Bitmap(loadingScreen));
        }
        
        private async void LoadingScreen_Load(object sender, EventArgs e)
        /* Loads all of the trending animes from the Anime Countdown website into the anime registry
         * and then starts the main program.
         *
         * :return void:
         */
        {
            this.Show();
            ContentLoader contentLoader = new ContentLoader();

            // Gets the trending anime contents and loads the poster images into the assets
            List<Anime> animesList = contentLoader.GetTrendingAnimes();
            
            string[] animePaths = await Task.WhenAll(animesList.Select(anime => contentLoader.LoadPosterImageFor(anime)));

            // Updates every anime in the registry with the new poster image
            for (int i = 0; i < animesList.Count; i++)
            {
                animesList[i].ImagePath = animePaths[i];
                AnimeRegistry.LoadIntoAnimeRegistry(animesList[i]);
            }

            this.Close();
        }
    }
}
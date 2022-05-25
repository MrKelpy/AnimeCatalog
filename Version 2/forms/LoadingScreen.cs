using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using PFM5.resources;

namespace PFM5.forms
{
    public partial class LoadingScreen : Form
    {
        // I actually spent a load of time trying to generate this array dynamically but
        // ended up being unable to because of the limitations imposed by the general scope
        // of what we've learned
        private readonly Bitmap[] _loadingImages;

        public LoadingScreen()
        {
            InitializeComponent();
            this._loadingImages = this.BuildLoadingImagesArray();
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
            var randomLoadingImage = this._loadingImages[new Random().Next(this._loadingImages.Length)];
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

        private Bitmap[] BuildLoadingImagesArray()
        /* Iterates over the assets directory and builds a Bitmap array containing all of the
         * loading images within.
         *
         * :return Bitmap[]: The Bitmap array of loading images.
         */
        {
            // Gather the list of files in the assets directory
            ConfigManager configManager = new ConfigManager();
            string loadingImagesPath = configManager.GetPathValue("loadingScreens");
            string[] loadingImages = Directory.GetFiles(loadingImagesPath);
            
            // Create a bitmap array and add each image to the array after conversion
            Bitmap[] loadingImagesArray = new Bitmap[loadingImages.Length];
            
            for (int i = 0; i < loadingImages.Length; i++)
                loadingImagesArray[i] = new Bitmap(loadingImages[i]);

            return loadingImagesArray;
        }
        
        private void LoadingScreen_Load(object sender, EventArgs e)
        /* Because I'm limited on what I can do for the Version 1 of this project, aka the version
         * that has *only* the stuff we learned, what happens upon load is pretty much just being fancy lol.
         *
         * :return void:
         */
        {
            this.Show();
            Thread.Sleep(3*1000);
            this.Close();
        }
    }
}
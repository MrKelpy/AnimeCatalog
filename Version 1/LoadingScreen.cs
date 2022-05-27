using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PFM5.Properties;

namespace PFM5
{
    public partial class LoadingScreen : Form
    {
        // I actually spent a load of time trying to generate this array dynamically but
        // ended up being unable to because of the limitations imposed by the general scope
        // of what we've learned
        private readonly Bitmap[] _loadingImages =
        {
            Resources.eula_loading, Resources.loading_ayaka,
            Resources.loading_dunno, Resources.loading_itto, Resources.loading_kazuha,
            Resources.loading_many, Resources.loading_miko, Resources.loading_starry,
            Resources.loading_traveller, Resources.loading_yakshas
        };
        
        public LoadingScreen()
        {
            InitializeComponent();
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
        
        private void LoadingScreen_Load(object sender, EventArgs e)
        /* Because I'm limited on what I can do for the Version 1 of this project, aka the version
         * that has *only* the stuff we learned, what happens upon load is pretty much just being fancy lol.
         *
         * :return void:
         */
        {
            this.Show();
            Thread.Sleep(3*1000);  // sleep ftw lmao
            this.Close();
        }
    }
}
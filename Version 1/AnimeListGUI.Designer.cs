using System.ComponentModel;

namespace PFM5
{
    partial class AnimeListGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimeListGUI));
            this.lblNextEpisodeDate = new System.Windows.Forms.Label();
            this.btnFavourites = new System.Windows.Forms.Button();
            this.lblLastEpisodeNumber = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.lblAnimeName = new System.Windows.Forms.Label();
            this.pictureAnimeLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVisualHeader = new System.Windows.Forms.Label();
            this.btnShowFavourites = new System.Windows.Forms.Button();
            this.addAnimeBtn = new System.Windows.Forms.Button();
            this.btnDeleteAnime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnimeLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNextEpisodeDate
            // 
            this.lblNextEpisodeDate.Location = new System.Drawing.Point(15, 93);
            this.lblNextEpisodeDate.Name = "lblNextEpisodeDate";
            this.lblNextEpisodeDate.Size = new System.Drawing.Size(175, 36);
            this.lblNextEpisodeDate.TabIndex = 15;
            this.lblNextEpisodeDate.Text = "NEXT EPISODE DATE";
            this.lblNextEpisodeDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFavourites
            // 
            this.btnFavourites.Location = new System.Drawing.Point(246, 278);
            this.btnFavourites.Name = "btnFavourites";
            this.btnFavourites.Size = new System.Drawing.Size(126, 47);
            this.btnFavourites.TabIndex = 14;
            this.btnFavourites.Text = "Add To Favourites";
            this.btnFavourites.UseVisualStyleBackColor = true;
            this.btnFavourites.Click += new System.EventHandler(this.btnFavourites_Click);
            // 
            // lblLastEpisodeNumber
            // 
            this.lblLastEpisodeNumber.Location = new System.Drawing.Point(15, 25);
            this.lblLastEpisodeNumber.Name = "lblLastEpisodeNumber";
            this.lblLastEpisodeNumber.Size = new System.Drawing.Size(175, 36);
            this.lblLastEpisodeNumber.TabIndex = 13;
            this.lblLastEpisodeNumber.Text = "LAST EPISODE NUMBER HERE";
            this.lblLastEpisodeNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(583, 278);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(141, 47);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(12, 278);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(141, 47);
            this.btnPrevious.TabIndex = 11;
            this.btnPrevious.Text = "< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.Location = new System.Drawing.Point(242, 50);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(248, 158);
            this.lblSynopsis.TabIndex = 10;
            this.lblSynopsis.Text = resources.GetString("lblSynopsis.Text");
            this.lblSynopsis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnimeName
            // 
            this.lblAnimeName.Location = new System.Drawing.Point(242, 22);
            this.lblAnimeName.Name = "lblAnimeName";
            this.lblAnimeName.Size = new System.Drawing.Size(248, 39);
            this.lblAnimeName.TabIndex = 9;
            this.lblAnimeName.Text = "ANIME NAME GOES HERE";
            this.lblAnimeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureAnimeLogo
            // 
            this.pictureAnimeLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureAnimeLogo.Location = new System.Drawing.Point(25, 12);
            this.pictureAnimeLogo.Name = "pictureAnimeLogo";
            this.pictureAnimeLogo.Size = new System.Drawing.Size(211, 207);
            this.pictureAnimeLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureAnimeLogo.TabIndex = 8;
            this.pictureAnimeLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(712, 2);
            this.label1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNextEpisodeDate);
            this.panel1.Controls.Add(this.lblLastEpisodeNumber);
            this.panel1.Location = new System.Drawing.Point(496, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 157);
            this.panel1.TabIndex = 17;
            // 
            // lblVisualHeader
            // 
            this.lblVisualHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblVisualHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVisualHeader.Location = new System.Drawing.Point(496, 230);
            this.lblVisualHeader.Name = "lblVisualHeader";
            this.lblVisualHeader.Size = new System.Drawing.Size(204, 34);
            this.lblVisualHeader.TabIndex = 18;
            this.lblVisualHeader.Text = "0/0";
            this.lblVisualHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowFavourites
            // 
            this.btnShowFavourites.Location = new System.Drawing.Point(378, 278);
            this.btnShowFavourites.Name = "btnShowFavourites";
            this.btnShowFavourites.Size = new System.Drawing.Size(130, 47);
            this.btnShowFavourites.TabIndex = 19;
            this.btnShowFavourites.Text = "Show Favourites";
            this.btnShowFavourites.UseVisualStyleBackColor = true;
            this.btnShowFavourites.Click += new System.EventHandler(this.btnShowFavourites_Click);
            // 
            // addAnimeBtn
            // 
            this.addAnimeBtn.Location = new System.Drawing.Point(25, 227);
            this.addAnimeBtn.Name = "addAnimeBtn";
            this.addAnimeBtn.Size = new System.Drawing.Size(101, 34);
            this.addAnimeBtn.TabIndex = 20;
            this.addAnimeBtn.Text = "New Anime";
            this.addAnimeBtn.UseVisualStyleBackColor = true;
            this.addAnimeBtn.Click += new System.EventHandler(this.addAnimeBtn_Click);
            // 
            // btnDeleteAnime
            // 
            this.btnDeleteAnime.Location = new System.Drawing.Point(135, 227);
            this.btnDeleteAnime.Name = "btnDeleteAnime";
            this.btnDeleteAnime.Size = new System.Drawing.Size(101, 34);
            this.btnDeleteAnime.TabIndex = 21;
            this.btnDeleteAnime.Text = "Delete Anime";
            this.btnDeleteAnime.UseVisualStyleBackColor = true;
            this.btnDeleteAnime.Click += new System.EventHandler(this.btnDeleteAnime_Click);
            // 
            // AnimeListGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(736, 342);
            this.Controls.Add(this.btnDeleteAnime);
            this.Controls.Add(this.addAnimeBtn);
            this.Controls.Add(this.btnShowFavourites);
            this.Controls.Add(this.lblVisualHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFavourites);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblSynopsis);
            this.Controls.Add(this.lblAnimeName);
            this.Controls.Add(this.pictureAnimeLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "AnimeListGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Anime Catalog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnimeLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnDeleteAnime;

        private System.Windows.Forms.Button addAnimeBtn;

        private System.Windows.Forms.Button btnShowFavourites;

        private System.Windows.Forms.Label lblVisualHeader;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label lblNextEpisodeDate;
        private System.Windows.Forms.Button btnFavourites;
        private System.Windows.Forms.Label lblLastEpisodeNumber;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.Label lblAnimeName;
        private System.Windows.Forms.PictureBox pictureAnimeLogo;

        #endregion
    }
}
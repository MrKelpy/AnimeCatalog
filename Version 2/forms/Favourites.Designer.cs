using System.ComponentModel;

namespace PFM5.forms
{
    partial class Favourites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Favourites));
            this.infoCarry = new System.Windows.Forms.Label();
            this.lblVisualHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.lblAnimeName = new System.Windows.Forms.Label();
            this.pictureAnimeLogo = new System.Windows.Forms.PictureBox();
            this.panelComponents = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNextEpisodeDate = new System.Windows.Forms.Label();
            this.lblLastEpisodeNumber = new System.Windows.Forms.Label();
            this.lblQuote = new System.Windows.Forms.Label();
            this.btnEditQuote = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnimeLogo)).BeginInit();
            this.panelComponents.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoCarry
            // 
            this.infoCarry.Location = new System.Drawing.Point(0, 0);
            this.infoCarry.Name = "infoCarry";
            this.infoCarry.Size = new System.Drawing.Size(0, 0);
            this.infoCarry.TabIndex = 0;
            this.infoCarry.Visible = false;
            // 
            // lblVisualHeader
            // 
            this.lblVisualHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblVisualHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVisualHeader.Location = new System.Drawing.Point(496, 230);
            this.lblVisualHeader.Name = "lblVisualHeader";
            this.lblVisualHeader.Size = new System.Drawing.Size(204, 34);
            this.lblVisualHeader.TabIndex = 27;
            this.lblVisualHeader.Text = "There are no favourites yet.";
            this.lblVisualHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(712, 2);
            this.label1.TabIndex = 25;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(583, 278);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(141, 47);
            this.btnNext.TabIndex = 23;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Location = new System.Drawing.Point(12, 278);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(141, 47);
            this.btnPrevious.TabIndex = 22;
            this.btnPrevious.Text = "< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.Location = new System.Drawing.Point(236, 56);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(248, 158);
            this.lblSynopsis.TabIndex = 21;
            this.lblSynopsis.Text = resources.GetString("lblSynopsis.Text");
            this.lblSynopsis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSynopsis.Visible = false;
            // 
            // lblAnimeName
            // 
            this.lblAnimeName.Location = new System.Drawing.Point(236, 17);
            this.lblAnimeName.Name = "lblAnimeName";
            this.lblAnimeName.Size = new System.Drawing.Size(248, 39);
            this.lblAnimeName.TabIndex = 20;
            this.lblAnimeName.Text = "ANIME NAME GOES HERE";
            this.lblAnimeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAnimeName.Visible = false;
            // 
            // pictureAnimeLogo
            // 
            this.pictureAnimeLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureAnimeLogo.Location = new System.Drawing.Point(19, 7);
            this.pictureAnimeLogo.Name = "pictureAnimeLogo";
            this.pictureAnimeLogo.Size = new System.Drawing.Size(211, 207);
            this.pictureAnimeLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureAnimeLogo.TabIndex = 19;
            this.pictureAnimeLogo.TabStop = false;
            // 
            // panelComponents
            // 
            this.panelComponents.BackColor = System.Drawing.Color.Transparent;
            this.panelComponents.Controls.Add(this.panel1);
            this.panelComponents.Controls.Add(this.lblSynopsis);
            this.panelComponents.Controls.Add(this.lblAnimeName);
            this.panelComponents.Controls.Add(this.pictureAnimeLogo);
            this.panelComponents.Location = new System.Drawing.Point(5, 5);
            this.panelComponents.Name = "panelComponents";
            this.panelComponents.Size = new System.Drawing.Size(718, 222);
            this.panelComponents.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNextEpisodeDate);
            this.panel1.Controls.Add(this.lblLastEpisodeNumber);
            this.panel1.Location = new System.Drawing.Point(490, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 157);
            this.panel1.TabIndex = 22;
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
            // lblLastEpisodeNumber
            // 
            this.lblLastEpisodeNumber.Location = new System.Drawing.Point(15, 25);
            this.lblLastEpisodeNumber.Name = "lblLastEpisodeNumber";
            this.lblLastEpisodeNumber.Size = new System.Drawing.Size(175, 36);
            this.lblLastEpisodeNumber.TabIndex = 13;
            this.lblLastEpisodeNumber.Text = "LAST EPISODE NUMBER HERE";
            this.lblLastEpisodeNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuote
            // 
            this.lblQuote.BackColor = System.Drawing.Color.Transparent;
            this.lblQuote.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblQuote.Location = new System.Drawing.Point(25, 230);
            this.lblQuote.Name = "lblQuote";
            this.lblQuote.Size = new System.Drawing.Size(211, 34);
            this.lblQuote.TabIndex = 31;
            this.lblQuote.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEditQuote
            // 
            this.btnEditQuote.Location = new System.Drawing.Point(367, 278);
            this.btnEditQuote.Name = "btnEditQuote";
            this.btnEditQuote.Size = new System.Drawing.Size(130, 47);
            this.btnEditQuote.TabIndex = 33;
            this.btnEditQuote.Text = "Edit Favourite Quote";
            this.btnEditQuote.UseVisualStyleBackColor = true;
            this.btnEditQuote.Click += new System.EventHandler(this.btnEditQuote_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(242, 278);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(126, 47);
            this.btnBack.TabIndex = 32;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Favourites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 342);
            this.Controls.Add(this.btnEditQuote);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblQuote);
            this.Controls.Add(this.panelComponents);
            this.Controls.Add(this.lblVisualHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.infoCarry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Favourites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Favourites";
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnimeLogo)).EndInit();
            this.panelComponents.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.Label lblQuote;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Panel panelComponents;

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEditQuote;

        private System.Windows.Forms.Label lblVisualHeader;
        private System.Windows.Forms.Label lblNextEpisodeDate;
        private System.Windows.Forms.Label lblLastEpisodeNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.Label lblAnimeName;
        private System.Windows.Forms.PictureBox pictureAnimeLogo;

        private System.Windows.Forms.Label infoCarry;

        #endregion
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PFM5
{
    public partial class QuoteDialog : Form
    {
        // Return values
        public string QuoteText;

        public QuoteDialog(string quoteText)
        {
            InitializeComponent();
            this.CenterToParent();
            lblCharCount.SendToBack();
            this.QuoteText = quoteText;
            txtQuoteEdit.Text = this.QuoteText;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        /* Cancels the quote edit and returns no QuoteText property. Exits the dialog.
         * :return void:
         */
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        /* Closes the dialog returning a QuoteText property with the text in
         * the txtQuoteEdit text box.
         * :return void:
         * 
         */
        {
            this.QuoteText = txtQuoteEdit.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtQuoteEdit_TextChanged(object sender, EventArgs e)
        /* Prevents the user from inputting a quote with more than 60 characters,
         * otherwise it wouldn't look good on the favourites dialog.
         * Updates the lblCharCount to show the current/maximum number of chars.
         *
         * :return void:
         */
        {
            lblCharCount.Text = $@"{txtQuoteEdit.Text.Length}/60";
            
            if (txtQuoteEdit.Text.Length <= 60)
            {
                btnOK.Enabled = true;
                lblCharCount.ForeColor = Color.Black;  // Just a small aesthetic indicator
                return;
            }

            btnOK.Enabled = false;
            lblCharCount.ForeColor = Color.Crimson;  // Same here
        }
    }
}
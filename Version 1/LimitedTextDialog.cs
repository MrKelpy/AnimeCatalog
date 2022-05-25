using System;
using System.Drawing;
using System.Windows.Forms;
// ReSharper disable VirtualMemberCallInConstructor

namespace PFM5
{
    public partial class LimitedTextDialog : Form
    {
        private readonly int _charLimit;
        public string TextReturned;  // This is a property to be returned from the form.

        public LimitedTextDialog(int charLimit, string dialogName = "Edit Text", string initialText = "")
        {
            InitializeComponent();
            this.CenterToParent();
            this.TextReturned = initialText;
            this._charLimit = charLimit;
            
            lblCharCount.SendToBack();
            lblCharCount.Text = $@"{txtQuoteEdit.Text.Length}/{this._charLimit}";
            txtQuoteEdit.Text = this.TextReturned;
            this.Text = dialogName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        /* Cancels the quote edit and returns no TextReturned property. Exits the dialog.
         * :return void:
         */
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        /* Closes the dialog returning a TextReturned property with the text in
         * the txtQuoteEdit text box.
         * :return void:
         * 
         */
        {
            this.TextReturned = txtQuoteEdit.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtQuoteEdit_TextChanged(object sender, EventArgs e)
        /* Prevents the user from inputting a quote with more than x characters,
         * otherwise it wouldn't look good on the favourites dialog.
         * Updates the lblCharCount to show the current/maximum number of chars.
         *
         * :return void:
         */
        {
            lblCharCount.Text = $@"{txtQuoteEdit.Text.Length}/{this._charLimit}";
            
            if (txtQuoteEdit.Text.Length <= this._charLimit)
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
using System.ComponentModel;

namespace PFM5.forms
{
    partial class QuoteDialog
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
            this.txtQuoteEdit = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblCharCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtQuoteEdit
            // 
            this.txtQuoteEdit.BackColor = System.Drawing.Color.White;
            this.txtQuoteEdit.Location = new System.Drawing.Point(8, 9);
            this.txtQuoteEdit.Multiline = true;
            this.txtQuoteEdit.Name = "txtQuoteEdit";
            this.txtQuoteEdit.Size = new System.Drawing.Size(370, 150);
            this.txtQuoteEdit.TabIndex = 0;
            this.txtQuoteEdit.TextChanged += new System.EventHandler(this.txtQuoteEdit_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 164);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(247, 164);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 38);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCharCount
            // 
            this.lblCharCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCharCount.Location = new System.Drawing.Point(8, 167);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(370, 33);
            this.lblCharCount.TabIndex = 3;
            this.lblCharCount.Text = "0/65";
            this.lblCharCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuoteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 209);
            this.Controls.Add(this.lblCharCount);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtQuoteEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QuoteDialog";
            this.Text = "Edit Quote";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCharCount;

        private System.Windows.Forms.TextBox txtQuoteEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;

        #endregion
    }
}
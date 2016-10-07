namespace Adressbok
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStreetAddress = new System.Windows.Forms.Label();
            this.txtStreetAddress = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lblContact = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdAddContact = new System.Windows.Forms.Button();
            this.listViewInformation = new System.Windows.Forms.ListView();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdShowAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(32, 101);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(128, 22);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(29, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblStreetAddress
            // 
            this.lblStreetAddress.AutoSize = true;
            this.lblStreetAddress.Location = new System.Drawing.Point(29, 126);
            this.lblStreetAddress.Name = "lblStreetAddress";
            this.lblStreetAddress.Size = new System.Drawing.Size(102, 17);
            this.lblStreetAddress.TabIndex = 4;
            this.lblStreetAddress.Text = "Street Address";
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.Location = new System.Drawing.Point(32, 143);
            this.txtStreetAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.Size = new System.Drawing.Size(128, 22);
            this.txtStreetAddress.TabIndex = 1;
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(32, 167);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(102, 17);
            this.lblZip.TabIndex = 6;
            this.lblZip.Text = "Zip/Postalcode";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(32, 186);
            this.txtZip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(128, 22);
            this.txtZip.TabIndex = 2;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(29, 210);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(31, 17);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(32, 229);
            this.txtCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(128, 22);
            this.txtCity.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(29, 254);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(32, 273);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(128, 22);
            this.txtEmail.TabIndex = 4;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(29, 298);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(99, 17);
            this.lblPhoneNumber.TabIndex = 12;
            this.lblPhoneNumber.Text = "PhoneNumber";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(32, 319);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(128, 22);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(168, 374);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(384, 22);
            this.txtSearch.TabIndex = 8;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(167, 356);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 17);
            this.lblSearch.TabIndex = 14;
            this.lblSearch.Text = "Search";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(661, 129);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(113, 25);
            this.cmdSave.TabIndex = 12;
            this.cmdSave.Text = "Save Change";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(559, 375);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(96, 23);
            this.cmdSearch.TabIndex = 9;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(164, 80);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(63, 17);
            this.lblContact.TabIndex = 20;
            this.lblContact.Text = "Contacts";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(661, 158);
            this.cmdDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(113, 23);
            this.cmdDelete.TabIndex = 13;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdAddContact
            // 
            this.cmdAddContact.Location = new System.Drawing.Point(32, 347);
            this.cmdAddContact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdAddContact.Name = "cmdAddContact";
            this.cmdAddContact.Size = new System.Drawing.Size(129, 23);
            this.cmdAddContact.TabIndex = 6;
            this.cmdAddContact.Text = "Add contact";
            this.cmdAddContact.UseVisualStyleBackColor = true;
            this.cmdAddContact.Click += new System.EventHandler(this.cmdAddContact_Click);
            // 
            // listViewInformation
            // 
            this.listViewInformation.Location = new System.Drawing.Point(168, 101);
            this.listViewInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewInformation.Name = "listViewInformation";
            this.listViewInformation.Size = new System.Drawing.Size(485, 242);
            this.listViewInformation.TabIndex = 10;
            this.listViewInformation.UseCompatibleStateImageBehavior = false;
            this.listViewInformation.View = System.Windows.Forms.View.List;
            this.listViewInformation.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listInformation_ItemSelectionChanged);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(32, 375);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(129, 23);
            this.cmdClear.TabIndex = 7;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdShowAll
            // 
            this.cmdShowAll.Location = new System.Drawing.Point(661, 101);
            this.cmdShowAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdShowAll.Name = "cmdShowAll";
            this.cmdShowAll.Size = new System.Drawing.Size(113, 23);
            this.cmdShowAll.TabIndex = 11;
            this.cmdShowAll.Text = "Show All";
            this.cmdShowAll.UseVisualStyleBackColor = true;
            this.cmdShowAll.Click += new System.EventHandler(this.cmdShowAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 613);
            this.Controls.Add(this.cmdShowAll);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.listViewInformation);
            this.Controls.Add(this.cmdAddContact);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.lblStreetAddress);
            this.Controls.Add(this.txtStreetAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStreetAddress;
        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdAddContact;
        private System.Windows.Forms.ListView listViewInformation;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdShowAll;
    }
}


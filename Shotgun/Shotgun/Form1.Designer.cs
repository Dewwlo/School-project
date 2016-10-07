namespace Shotgun
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
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdBlock = new System.Windows.Forms.Button();
            this.cmdFire = new System.Windows.Forms.Button();
            this.cmdShotgun = new System.Windows.Forms.Button();
            this.lblComputerAmmo = new System.Windows.Forms.Label();
            this.lblComputerAmmoCurrent = new System.Windows.Forms.Label();
            this.lblYourAmmoCurrent = new System.Windows.Forms.Label();
            this.lblYourAmmo = new System.Windows.Forms.Label();
            this.lblComputerLastAction = new System.Windows.Forms.Label();
            this.lblYourLastAction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(115, 180);
            this.cmdLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(75, 58);
            this.cmdLoad.TabIndex = 0;
            this.cmdLoad.Text = "Load";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdBlock
            // 
            this.cmdBlock.Location = new System.Drawing.Point(196, 180);
            this.cmdBlock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdBlock.Name = "cmdBlock";
            this.cmdBlock.Size = new System.Drawing.Size(75, 58);
            this.cmdBlock.TabIndex = 1;
            this.cmdBlock.Text = "Block";
            this.cmdBlock.UseVisualStyleBackColor = true;
            this.cmdBlock.Click += new System.EventHandler(this.cmdBlock_Click);
            // 
            // cmdFire
            // 
            this.cmdFire.Enabled = false;
            this.cmdFire.Location = new System.Drawing.Point(277, 180);
            this.cmdFire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdFire.Name = "cmdFire";
            this.cmdFire.Size = new System.Drawing.Size(75, 58);
            this.cmdFire.TabIndex = 2;
            this.cmdFire.Text = "Fire";
            this.cmdFire.UseVisualStyleBackColor = true;
            this.cmdFire.Click += new System.EventHandler(this.cmdFire_Click);
            // 
            // cmdShotgun
            // 
            this.cmdShotgun.Location = new System.Drawing.Point(115, 244);
            this.cmdShotgun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdShotgun.Name = "cmdShotgun";
            this.cmdShotgun.Size = new System.Drawing.Size(237, 64);
            this.cmdShotgun.TabIndex = 3;
            this.cmdShotgun.Text = "Shotgun!";
            this.cmdShotgun.UseVisualStyleBackColor = true;
            this.cmdShotgun.Visible = false;
            this.cmdShotgun.Click += new System.EventHandler(this.cmdShotgun_Click);
            // 
            // lblComputerAmmo
            // 
            this.lblComputerAmmo.AutoSize = true;
            this.lblComputerAmmo.Location = new System.Drawing.Point(74, 91);
            this.lblComputerAmmo.Name = "lblComputerAmmo";
            this.lblComputerAmmo.Size = new System.Drawing.Size(116, 17);
            this.lblComputerAmmo.TabIndex = 4;
            this.lblComputerAmmo.Text = "Computer Ammo:";
            // 
            // lblComputerAmmoCurrent
            // 
            this.lblComputerAmmoCurrent.AutoSize = true;
            this.lblComputerAmmoCurrent.Location = new System.Drawing.Point(184, 91);
            this.lblComputerAmmoCurrent.Name = "lblComputerAmmoCurrent";
            this.lblComputerAmmoCurrent.Size = new System.Drawing.Size(16, 17);
            this.lblComputerAmmoCurrent.TabIndex = 5;
            this.lblComputerAmmoCurrent.Text = "0";
            // 
            // lblYourAmmoCurrent
            // 
            this.lblYourAmmoCurrent.AutoSize = true;
            this.lblYourAmmoCurrent.Location = new System.Drawing.Point(354, 91);
            this.lblYourAmmoCurrent.Name = "lblYourAmmoCurrent";
            this.lblYourAmmoCurrent.Size = new System.Drawing.Size(16, 17);
            this.lblYourAmmoCurrent.TabIndex = 7;
            this.lblYourAmmoCurrent.Text = "0";
            // 
            // lblYourAmmo
            // 
            this.lblYourAmmo.AutoSize = true;
            this.lblYourAmmo.Location = new System.Drawing.Point(274, 91);
            this.lblYourAmmo.Name = "lblYourAmmo";
            this.lblYourAmmo.Size = new System.Drawing.Size(85, 17);
            this.lblYourAmmo.TabIndex = 6;
            this.lblYourAmmo.Text = "Your Ammo:";
            // 
            // lblComputerLastAction
            // 
            this.lblComputerLastAction.AutoSize = true;
            this.lblComputerLastAction.Location = new System.Drawing.Point(74, 125);
            this.lblComputerLastAction.Name = "lblComputerLastAction";
            this.lblComputerLastAction.Size = new System.Drawing.Size(137, 17);
            this.lblComputerLastAction.TabIndex = 8;
            this.lblComputerLastAction.Text = "Computer last action";
            // 
            // lblYourLastAction
            // 
            this.lblYourLastAction.AutoSize = true;
            this.lblYourLastAction.Location = new System.Drawing.Point(274, 125);
            this.lblYourLastAction.Name = "lblYourLastAction";
            this.lblYourLastAction.Size = new System.Drawing.Size(106, 17);
            this.lblYourLastAction.TabIndex = 9;
            this.lblYourLastAction.Text = "Your last action";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 453);
            this.Controls.Add(this.lblYourLastAction);
            this.Controls.Add(this.lblComputerLastAction);
            this.Controls.Add(this.lblYourAmmoCurrent);
            this.Controls.Add(this.lblYourAmmo);
            this.Controls.Add(this.lblComputerAmmoCurrent);
            this.Controls.Add(this.lblComputerAmmo);
            this.Controls.Add(this.cmdShotgun);
            this.Controls.Add(this.cmdFire);
            this.Controls.Add(this.cmdBlock);
            this.Controls.Add(this.cmdLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdBlock;
        private System.Windows.Forms.Button cmdFire;
        private System.Windows.Forms.Button cmdShotgun;
        private System.Windows.Forms.Label lblComputerAmmo;
        private System.Windows.Forms.Label lblComputerAmmoCurrent;
        private System.Windows.Forms.Label lblYourAmmoCurrent;
        private System.Windows.Forms.Label lblYourAmmo;
        private System.Windows.Forms.Label lblComputerLastAction;
        private System.Windows.Forms.Label lblYourLastAction;
    }
}


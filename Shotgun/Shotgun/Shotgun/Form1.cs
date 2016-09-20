using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shotgun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int computerAmmo = 0;
        int playerAmmo = 0;

        // Action 1 = Load
        // Action 2 = Block
        // Action 3 = Fire
        // Action 4 = Shotgun
        int compChoice = 0;
        int playerChoice = 0;

        // result 0 Nothing happends
        // result 1 Draw
        // result 2 Computer Win
        // result 3 Player win
        int result = 0;
        

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            playerChoice = 1;
            ResolveTurn();
        }

        private void cmdBlock_Click(object sender, EventArgs e)
        {
            playerChoice = 2;
            ResolveTurn();
        }

        private void cmdFire_Click(object sender, EventArgs e)
        {
            playerChoice = 3;
            ResolveTurn();
        }
            
        private void cmdShotgun_Click(object sender, EventArgs e)
        {
            playerChoice = 4;
            ResolveTurn();
        }

        public void ResolveTurn()
        {
            ComputerAction();
            UpdateLabelAmmoInfo();

            if (playerChoice == 1)
            {
                switch (compChoice)
                {
                    case 3: result = 2;
                        break;
                    case 4: result = 2;
                        break;
                    default: result = 0;
                        break;
                }
            }
            else if (playerChoice == 2)
            {
                switch (compChoice)
                {
                    case 4: result = 2;
                        break;
                    default: result = 0;
                        break;
                }

            }
            else if (playerChoice == 3)
            {
                switch (compChoice)
                {
                    case 1: result = 3;
                        break;
                    case 2: result = 0;
                        break;
                    case 3: result = 0;
                        break;
                    case 4: result = 2;
                        break;
                }
            }
            else if (playerChoice == 4)
            {
                switch (compChoice)
                {
                    case 4: result = 1;
                        break;
                    default: result = 3;
                        break;
                }
            }

            EnableFire();
            CheckWinner();
        }

        public void UpdateLabelAmmoInfo()
        {
            if (playerChoice == 1)
            {
                playerAmmo++;
                lblYourLastAction.Text = "You load";
                lblYourAmmoCurrent.Text = playerAmmo.ToString();
            }
            else if (playerChoice == 2)
            {
                lblYourLastAction.Text = "You block";
            }
            else if (playerChoice == 3)
            {
                playerAmmo--;
                lblYourLastAction.Text = "You fire";
                lblYourAmmoCurrent.Text = playerAmmo.ToString();
            }
            else if (playerChoice == 4)
            {
                lblYourLastAction.Text = "You used shotgun";
            }
        }

        public void ComputerAction()
        {
            compChoice = CompRandomNumber();

            if (compChoice == 1)
            {
                computerAmmo++;
                lblComputerLastAction.Text = "Computer Loads";
                lblComputerAmmoCurrent.Text = computerAmmo.ToString();
            }
            else if (compChoice == 2)
            {
                lblComputerLastAction.Text = "Computer Blocks";
            }
            else if (compChoice == 3)
            {
                computerAmmo--;
                lblComputerLastAction.Text = "Computer Fires";
                lblComputerAmmoCurrent.Text = computerAmmo.ToString();
            }
            else if (compChoice == 4)
            {
                lblComputerLastAction.Text = "Computer use Shotgun!";
            }
        }

        public int CompRandomNumber()
        {
            int i = 1;

            if (playerAmmo > 0 && computerAmmo == 0)
            {
                Random first = new Random();
                i = first.Next(1, 3);
            }
            else if (computerAmmo > 0 && computerAmmo < 3)
            {
                Random second = new Random();
                i = second.Next(1, 4);
            }
            else if (computerAmmo == 3)
            {
                i = 4;
            }

            return i;
        }
                
        public void EnableShotgun()
        {
            if (playerAmmo == 3)
            {
                cmdShotgun.Visible = true;
                cmdLoad.Visible = false;
                cmdBlock.Visible = false;
                cmdFire.Visible = false;
            }
            else
            {

            }
        }

        public void EnableFire()
        {
            if (playerAmmo > 0)
            {
                cmdFire.Enabled = true;
            }
            else
            {
                cmdFire.Enabled = false;
            }
        }

        public void CheckWinner()
        {
            EnableShotgun();

            if (result == 2)
            {
                MessageBox.Show("You are defeated!");
                RestartOrExit();
            }
            else if (result == 3)
            {
                MessageBox.Show("You defeated your opponent!");
                RestartOrExit();
            }
            else if (result == 1)
            {
                MessageBox.Show("The battle ended with a draw!");
                RestartOrExit();
            }
        }

        public void RestartOrExit()
        {
            DialogResult playAgain = MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo);
            if (playAgain == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
            else if (playAgain  == DialogResult.No)
            {
                Application.Exit();
            }
        }
    }
}
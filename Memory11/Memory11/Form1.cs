using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string checkFirst = "";
        string buttonPressed = "";
        int checkColor = 0;
        string colorControl = "A";
        string lastButtonName = "";

        private void MatchLetter(object sender, EventArgs e)
        {
            var buttonName = (sender as Button).Name;
            if (buttonName == lastButtonName)
            {
                return;
            }
            lastButtonName = buttonName;
            GetButtonName(buttonName);
            ShowColor(buttonName);


            if (buttonPressed == "")
            {
                buttonPressed = checkFirst;
                if (checkColor == 1)
                {
                    ResetColor(colorControl);
                    checkColor = 0;
                    ShowColor(buttonName);
                }
            }
            else if (buttonPressed != "")
            {
                if (buttonPressed == checkFirst)
                {
                    HideLetter(buttonPressed);
                    buttonPressed = "";
                }
                else if (buttonPressed != checkFirst)
                {
                    checkColor = 1;
                    buttonPressed = "";
                }
            }
        }
        public void HideLetter(string letter)
        {
            switch (letter)
            {
                case "A": cmdA1.Visible = false; cmdA2.Visible = false; break;
                case "B": cmdB1.Visible = false; cmdB2.Visible = false; break;
                case "C": cmdC1.Visible = false; cmdC2.Visible = false; break;
                case "D": cmdD1.Visible = false; cmdD2.Visible = false; break;
                case "E": cmdE1.Visible = false; cmdE2.Visible = false; break;
                case "F": cmdF1.Visible = false; cmdF2.Visible = false; break;
                case "G": cmdG1.Visible = false; cmdG2.Visible = false; break;
                case "H": cmdH1.Visible = false; cmdH2.Visible = false; break;
            }
        }
        public void GetButtonName(string letter)
        {
            switch (letter)
            {
                case "cmdA1": checkFirst = "A"; break;
                case "cmdB1": checkFirst = "B"; break;
                case "cmdC1": checkFirst = "C"; break;
                case "cmdD1": checkFirst = "D"; break;
                case "cmdE1": checkFirst = "E"; break;
                case "cmdF1": checkFirst = "F"; break;
                case "cmdG1": checkFirst = "G"; break;
                case "cmdH1": checkFirst = "H"; break;
                case "cmdA2": checkFirst = "A"; break;
                case "cmdB2": checkFirst = "B"; break;
                case "cmdC2": checkFirst = "C"; break;
                case "cmdD2": checkFirst = "D"; break;
                case "cmdE2": checkFirst = "E"; break;
                case "cmdF2": checkFirst = "F"; break;
                case "cmdG2": checkFirst = "G"; break;
                case "cmdH2": checkFirst = "H"; break;
            }
        }
        public void ShowColor(string letter)
        {
            switch (letter)
            {
                case "cmdA1": cmdA1.BackColor = Color.Green; break;
                case "cmdB1": cmdB1.BackColor = Color.Blue; break;
                case "cmdC1": cmdC1.BackColor = Color.Yellow; break;
                case "cmdD1": cmdD1.BackColor = Color.Red; break;
                case "cmdE1": cmdE1.BackColor = Color.Tan; break;
                case "cmdF1": cmdF1.BackColor = Color.Orange; break;
                case "cmdG1": cmdG1.BackColor = Color.Purple; break;
                case "cmdH1": cmdH1.BackColor = Color.Aqua; break;
                case "cmdA2": cmdA2.BackColor = Color.Green; break;
                case "cmdB2": cmdB2.BackColor = Color.Blue; break;
                case "cmdC2": cmdC2.BackColor = Color.Yellow; break;
                case "cmdD2": cmdD2.BackColor = Color.Red; break;
                case "cmdE2": cmdE2.BackColor = Color.Tan; break;
                case "cmdF2": cmdF2.BackColor = Color.Orange; break;
                case "cmdG2": cmdG2.BackColor = Color.Purple; break;
                case "cmdH2": cmdH2.BackColor = Color.Aqua; break;
            }
        }
        public void ResetColor(string letter)
        {
            switch (letter)
            {
                case "A":   cmdA1.BackColor = Color.Black; 
                            cmdB1.BackColor = Color.Black; 
                            cmdC1.BackColor = Color.Black;
                            cmdD1.BackColor = Color.Black;
                            cmdE1.BackColor = Color.Black;
                            cmdF1.BackColor = Color.Black;
                            cmdG1.BackColor = Color.Black;
                            cmdH1.BackColor = Color.Black;
                            cmdA2.BackColor = Color.Black;
                            cmdB2.BackColor = Color.Black;
                            cmdC2.BackColor = Color.Black;
                            cmdD2.BackColor = Color.Black;
                            cmdE2.BackColor = Color.Black;
                            cmdF2.BackColor = Color.Black;
                            cmdG2.BackColor = Color.Black;
                            cmdH2.BackColor = Color.Black; break;
            }
        }
    }
}

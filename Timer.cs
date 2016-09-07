using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int duration = 0;
        private void Timer(object sender, EventArgs e)
        {
            duration++;
            txtTimer.Text = duration.ToString();
        }
        private void StartTimer(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Start();
        }

        private void StopTimer(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}

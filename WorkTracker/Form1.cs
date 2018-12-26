using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StampTime(true);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StampTime(false);
        }

        private void StampTime(bool start)
        {
            
            DateTime dt = DateTime.Now;
            string message = "";
            
            if (start)
            {
                StartButton.Visible = false;
                StopButton.Visible = true;
                message = Printer.StartTime(dt);
            }
            else
            {
                StopButton.Visible = false;
                StartButton.Visible = true;
                message = Printer.StopTime(dt);
            }

            OutputText.Text = message;
        }
    }
}

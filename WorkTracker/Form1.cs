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
        string path = @"C:\Users\USER\Documents\Yehoshua\WorkTrackerOutputs\";

        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!JobTextBox.Text.Equals("")) StampTime(true);
            else OutputText.Text = NoJobEntered();
        }

        private string NoJobEntered()
        {
            return "Please enter a job in the job text box above.";
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (!JobTextBox.Text.Equals("")) StampTime(false);
            else OutputText.Text = NoJobEntered();
        }

        private void StampTime(bool start)
        {

            DateTime dt = DateTime.Now;
            string message = "";
            string job = JobTextBox.Text;
            Printer printer = new Printer(path, job);
            string TimeElapsed = "";

            if (start)
            {
                StartButton.Visible = false;
                StopButton.Visible = true;
                message = printer.StartTime(dt);
            }
            else
            {
                StopButton.Visible = false;
                StartButton.Visible = true;
                message = printer.StopTime(dt);
                TimeElapsed = printer.TimeWorked();
            }

            OutputText.Text = message;
            if (!start) OutputText.Text += "\n" + TimeElapsed;
        }
    }
}

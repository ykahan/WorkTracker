﻿using System;
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
        string path = @"C:\Users\USER\Documents\Yehoshua\WorkTrackerOutputs\whatever.txt";

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
            Printer printer = new Printer(path);
            string TimeElapsed = "";
            if (start)
            {
                StartButton.Visible = false;
                StopButton.Visible = true;
                message = printer.StartTime(dt, path);
            }
            else
            {
                StopButton.Visible = false;
                StartButton.Visible = true;
                message = printer.StopTime(dt, path);
                TimeElapsed = printer.TimeWorked();
            }

            OutputText.Text = message;
            if (!start) OutputText.Text += "\n" + TimeElapsed;
        }
    }
}

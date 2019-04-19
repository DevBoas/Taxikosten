using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Taxikosten
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float timeMath(DateTime startDate, DateTime endDate, float geld)
        {
            if (startDate > endDate)
                return 0;
            double hours = (endDate - startDate).TotalHours;
            float minuten = (float) (endDate - startDate).TotalMinutes;
            DateTime HourDate = startDate;
            if (hours >= 1)
            {
                HourDate = startDate.AddHours(1);
                hours = (endDate - HourDate).TotalHours;
                ///MessageBox.Show("Hours Left = " + hours.ToString());
                if (HourDate.Hour > 8 && HourDate.Hour <= 18)
                {
                    ///MessageBox.Show("binnen periode");
                    geld += 0.25f * 60;
                }
                else
                {
                    ///MessageBox.Show("buiten periode");
                    geld += 0.45f * 60;
                }
            }
            else if (hours >= 0)
            {
                ///MessageBox.Show("Minutes Left = " + minuten.ToString());
                if (HourDate.Hour > 8 && HourDate.Hour < 18)
                {
                    geld += 0.25f * minuten;
                }
                else
                    geld += 0.45f * minuten;
                return geld;
            }
            //return geld;
            return timeMath(HourDate, endDate, geld);
        }


        private void Bereken_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse(start.Text);
            DateTime endDate = DateTime.Parse(end.Text);
            float geld = timeMath(startDate, endDate, 0);
            float km = float.Parse(Kilometers.Text);
            float total = geld + km;
            Uitslag.Text = "Uitslag: " + total.ToString();
        }
    }
}

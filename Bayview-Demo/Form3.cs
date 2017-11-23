using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Bayview_Demo
{
    public partial class Form3 : Form
    {
        public Form3(string inString, int inCust, string inName)
        {
            InitializeComponent();
            conString = inString;
            custid = inCust;
            tbLN.Text = inName;     //uses the passed name to poulate this text box
        }

        string conString;       
        int custid;                 //tracks customer's primary key value
        int partySize;          //as name suggests, reports current size of party for booking
        string d1, d2;          //used to determing start and end dates of a booking


        private void Form3_Load(object sender, EventArgs e)
        {
            //populate party size options
            cbAdult.Items.Add(1);
            cbAdult.Items.Add(2);
            cbAdult.Items.Add(3);
            cbAdult.Items.Add(4);
            cbChild.Items.Add(0);
            cbChild.Items.Add(1);
            cbChild.Items.Add(2);
            cbChild.Items.Add(3);
            //set earliest booking to tomorrow
            dtIn.MinDate = DateTime.Now.AddDays(1);
            //set initial adult and child count
            cbAdult.SelectedIndex = 0;
            cbChild.SelectedIndex = 0;
        }

        //if number of nights changes, recompute end date
        private void nudNights_ValueChanged(object sender, EventArgs e)
        {
            //compute new end date
            dtOut.Value = dtIn.Value.AddDays(Convert.ToInt32(nudNights.Value));
        }

        //if start date changes, reset end date
        private void dtIn_ValueChanged(object sender, EventArgs e)
        {
            dtOut.MinDate = dtIn.Value.AddDays(1);      //reset end to start day plus one
            nights();
        }

        //compute and update number of nights for a booking
        private void nights()
        {
            nudNights.Value = (dtOut.Value.AddHours(1) - dtIn.Value).Days;
        }

        //if end date changes, recompute nights
        private void dtOut_ValueChanged(object sender, EventArgs e)
        {
            nights();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

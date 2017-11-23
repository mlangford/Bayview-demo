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
            tbLN.Text = inName;
        }

        string conString;       
        int custid;                 //tracks customer's primary key value
        int partySize;          //as name suggests, reports current size of party for booking
        string d1, d2;          //used to determing start and end dates of a booking

        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
}

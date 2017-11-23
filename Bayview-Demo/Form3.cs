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

        private void btnRmPick_Click(object sender, EventArgs e)
        {
            //reset UI appropriately
            cbAdult.Enabled = false;        //prevent use
            cbChild.Enabled = false;
            panel1.Enabled = false;         //switch panels to
            panel2.Enabled = true;          //activate new controls

            //set up room types according to business rules
            cbType.Items.Clear();
            partySize = Convert.ToInt32(cbAdult.Text) + Convert.ToInt32(cbChild.Text);
            if (partySize > 2)
                cbType.Items.Add("Family");
            if (partySize <= 2)
                cbType.Items.Insert(0, "Double");
            if (partySize == 1)
                cbType.Items.Insert(0, "Single");
            cbType.SelectedIndex = 0;
        }

        private void btnRmCancel_Click(object sender, EventArgs e)
        {
            //reset UI accordingly
            btnCost.Enabled = false;
            lblCost.Visible = false;
            lbRooms.Items.Clear();      //empty rooms list
            cbType.Items.Clear();       //empty room type list
            cbType.Text = "";
            cbBreakfast.Checked = false;
            cbAdult.Enabled = true;
            cbChild.Enabled = true;
            panel1.Enabled = true;
            panel2.Enabled = false;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbRooms.Items.Clear();
            try
            {
                //create list of all rooms of selected type
                using (SQLiteConnection dbcon = new SQLiteConnection(conString))
                {
                    string sql1 = @"Select number From room Where type = @rmtyp And disabled = @da";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql1, dbcon))
                    {
                        cmd.Parameters.AddWithValue("@rmtyp", cbType.Text);
                        if (cbDisabled.Checked)
                        {
                            cmd.Parameters.AddWithValue("@da", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@da", 0);
                        }
                        dbcon.Open();
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lbRooms.Items.Add(dr[0].ToString());
                            }
                        }
                        dbcon.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                showlabel("Error: " + ex.Message, 4000);
            }
        }

        //display a feedback label
        private void showlabel(string detail, int time)
        {
            lbFeedback.Text = detail;
            lbFeedback.Visible = true;
            timer1.Interval = time;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbFeedback.Visible = false;
            timer1.Stop();
        }


        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

﻿using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Bayview_Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string conString = dbConnection.source;

        private void Form2_Load(object sender, EventArgs e)
        {
            cbTitle.Items.Add("Mr");
            cbTitle.Items.Add("Ms");
            cbTitle.Items.Add("Mx");
            cbTitle.Items.Add("Dr");
            cbTitle.Items.Add("Professor");
            cbTitle.Items.Add("Reverend");
            cbTitle.Items.Add("Sir");
            cbTitle.Items.Add("Dame");
            cbTitle.Items.Add("Lord");
            cbTitle.Items.Add("Lady");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            setinputs(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setinputs(false);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //write new customer data to db
                using (SQLiteConnection dbcon = new SQLiteConnection())
                {
                    dbcon.ConnectionString = conString;
                    string sql = "Insert Into customer(title,firstname,lastname,address1,address2,address3,postcode,phone) Values(@t,@f,@l,@a1,@a2,@a3,@pc,@pn)";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, dbcon))
                    {
                        cmd.Parameters.AddWithValue("t", cbTitle.Text);
                        cmd.Parameters.AddWithValue("f", tbFN.Text);
                        cmd.Parameters.AddWithValue("l", tbLN.Text);
                        cmd.Parameters.AddWithValue("a1", tbA1.Text);
                        cmd.Parameters.AddWithValue("a2", tbA2.Text);
                        cmd.Parameters.AddWithValue("a3", tbA3.Text);
                        cmd.Parameters.AddWithValue("pc", tbPC.Text);
                        cmd.Parameters.AddWithValue("pn", tbPhone.Text);
                        dbcon.Open();
                        cmd.ExecuteNonQuery();
                        dbcon.Close();
                    }
                }
                showlabel("New Customer Added OK", 4000);
                setinputs(false);
            }
            catch (Exception ex)
            {
                showlabel(ex.Message, 4000);
                setinputs(false);
            }
        }

        private void setinputs(Boolean setas)
        {
            clrinputs();
            cbTitle.Enabled = setas;
            tbFN.Enabled = setas;
            tbLN.Enabled = setas;
            tbA1.Enabled = setas;
            tbA2.Enabled = setas;
            tbA3.Enabled = setas;
            tbPC.Enabled = setas;
            tbPhone.Enabled = setas;
            btnCancel.Enabled = setas;
            btnSubmit.Enabled = setas;
        }

        private void clrinputs()
        {
            cbTitle.Text = "";
            tbFN.Clear();
            tbLN.Clear();
            tbA1.Clear();
            tbA2.Clear();
            tbA3.Clear();
            tbPC.Clear();
            tbPhone.Clear();
        }

        //display a feedback label
        private void showlabel(string detail, int time)
        {
            lbFeedback.Text = detail;
            lbFeedback.Visible = true;
            timer1.Interval = time;
            timer1.Start();
        }
        //turn off feedback label after3 seconds
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

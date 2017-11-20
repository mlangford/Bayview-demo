using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace Bayview_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //global variable used to keep track of
        //the currently logged-in staff member
        int stfid;
        //global variable to hold the db path/filename 
        string db;

        private void Form1_Load(object sender, EventArgs e)
        {
            //try to get db connection details from LKG file
            try
            {
                using (StreamReader sr = new StreamReader("lkg.txt"))
                {
                    db = sr.ReadLine();
                }
            }
            catch (Exception)
            {
                //otherwise, get details from user
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Select SQLite database file",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "Database files (*.db)|*.db",
                    FilterIndex = 1,
                    FileName = ""
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    db = ofd.FileName;
                }
                else
                {
                    //as no db file was established; exit gracefully
                    MessageBox.Show("Unable to continue without a database connection\n\rApplication will now close");
                    Environment.Exit(0);
                }
            }
            //if  named database file does not exist, the SQLiteconnection Class
            //will create a new, empty, one when you connect. This checks the file
            // exists before we connect; dont want to connect to a new empty one
            if (!File.Exists(db))
            {
                //details in LKG not good, so delete, and advise to restart
                MessageBox.Show("The 'Last Known Good' details were invalid\r\nRestart application and try again");
                File.Delete("lkg.txt");
                Environment.Exit(0);
            }
            //final test, try to read from table
            try
            {
                using (SQLiteConnection dbcon = new SQLiteConnection())
                {
                    dbcon.ConnectionString = @"Data Source=" + db;
                    string sql = "SELECT * FROM room";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, dbcon))
                    {
                        dbcon.Open();
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            //if no data, throw an exception
                            if (!dr.HasRows)
                                throw new Exception();
                        }
                        //connection fully validated
                        dbcon.Close();
                    }
                }
                //save Last Known Good details
                using (StreamWriter sw = new StreamWriter("lkg.txt", false))
                {
                    sw.WriteLine(db);
                }
            }
            catch (Exception ex)
            {
                //catch any remaining connection problems here
                MessageBox.Show("Db connection failed\r\nApplication will close\r\n" + ex.Message);
                Environment.Exit(0);
            };

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection dbcon = new SQLiteConnection())
                {
                    dbcon.ConnectionString = @"Data Source=" + db;
                    //we wish to retrieve the password and staff-ID
                    string sql = "SELECT passwd, staffID FROM staff WHERE staffname=@name";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, dbcon))
                    {
                        //using a user-supplied staff name
                        cmd.Parameters.AddWithValue("name", tbusername.Text);
                        dbcon.Open();
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            //if no match to name in Db, throw an exception
                            if (!dr.HasRows)
                                throw new Exception();
                            //if pasword hash codes dont match, throw an exception
                            string hsh = Coder.GetHash(tbpasswd.Text);
                            dr.Read();
                            if (hsh != dr[0].ToString())
                                throw new Exception();
                            //OK, the login is valid
                            stfid = Convert.ToInt32(dr[1]);  //keep track of current staff member
                            dbcon.Close();
                            setlogin(true);  //and set up interface for a logged-in user
                        }
                    }
                }
            }
            catch
            {
                //if something went wrong, show details
                showlabel("Login unsuccessful - try again", 4000);
                tbusername.Focus();
            }
            finally
            {
                //clear the user input fields
                tbusername.Clear();
                tbpasswd.Clear();
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            setlogin(false); //set up interface for a logged-out user
        }

        private void btnnewpwd_Click(object sender, EventArgs e)
        {
            setpwdchng(true);  //show controls for password change
        }

        private void btncnl_Click(object sender, EventArgs e)
        {
            setpwdchng(false);   //hide controls for password change
        }

        private void btnpwd_Click(object sender, EventArgs e)
        {
            //coding actions to reset the logged-in user's password
            SQLiteDataReader dr;
            string sql;
            try
            {
                //if new passwords don't match (case sensitive), throw an exception
                if (string.Compare(tbreset1.Text, tbreset2.Text, false) == -1)
                    throw new Exception(" New passwords don't match");

                //retrieve old password from db
                string dbhsh;
                using (SQLiteConnection dbcon = new SQLiteConnection())
                {
                    dbcon.ConnectionString = @"Data Source=" + db;
                    sql = "SELECT passwd FROM staff WHERE staffID=@id";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, dbcon))
                    {
                        cmd.Parameters.AddWithValue("id", stfid);
                        dbcon.Open();
                        using (dr = cmd.ExecuteReader())
                        {
                            dr.Read();
                            dbhsh = dr[0].ToString();
                        }
                        dbcon.Close();
                    }
                    //if entered password is incorrect, throw an exception
                    if (Coder.GetHash(tbreset0.Text) != dbhsh)
                        throw new Exception("Old password is incorrect");
                }

                //write the newly supplied password out to the db
                using (SQLiteConnection dbcon = new SQLiteConnection())
                {
                    dbcon.ConnectionString = @"Data Source=" + db;
                    sql = "UPDATE staff SET passwd=@hsh WHERE staffID=@id";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, dbcon))
                    {
                        cmd.Parameters.AddWithValue("hsh", Coder.GetHash(tbreset1.Text));
                        cmd.Parameters.AddWithValue("id", stfid);
                        dbcon.Open();
                            cmd.ExecuteNonQuery();
                        dbcon.Close();
                    }
                }
                showlabel("Password was reset", 4000);
                setpwdchng(false);
            }
            catch (Exception ex)
            {
                showlabel(ex.Message, 4000);
                tbreset0.Clear();
                tbreset1.Clear();
                tbreset2.Clear();
                tbreset0.Focus();
            }
        }

        private void setlogin(Boolean setas)
        {
            //set up the interface for a logged-in (setas=true) or logged-out (setas=false) user
            btnnewpwd.Enabled = setas;
            btncust.Enabled = setas;
            btnbook.Enabled = setas;
            btnlogout.Enabled = setas;
            btnlogin.Enabled = !setas;
            tbusername.Enabled = !setas;
            tbpasswd.Enabled = !setas;
        }

        private void setpwdchng(Boolean setas)
        {
            //activate (setas=true), or deactivate (setas=false), the password change controls
            lboldpwd.Visible = setas;
            lbnewpwd1.Visible = setas;
            lblnewpwd2.Visible = setas;
            tbreset0.Clear();
            tbreset1.Clear();
            tbreset2.Clear();
            tbreset0.Visible = setas;
            tbreset1.Visible = setas;
            tbreset2.Visible = setas;
            btnpwd.Visible = setas;
            btncnl.Visible = setas;
            btnlogout.Enabled = !setas;
            btnnewpwd.Enabled = !setas;
            btncust.Enabled = !setas;
            btnbook.Enabled = !setas;
        }

        private void btncust_Click(object sender, EventArgs e)
        {
            //Display Form 2 when the "Customers" button is clicked
            Form2 frm2 = new Form2(@"Data Source=" + db);
            frm2.ShowDialog();
        }

        //deal with return keys in login boxes
        private void tbpasswd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnlogin_Click(null, null);
            }
        }
        private void tbusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                tbpasswd.Focus();
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
        //hide feedback label after n seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbFeedback.Visible = false;
            timer1.Stop();
        }

        private void btncust_Click_1(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(@"Data Source=" + db);
            frm2.ShowDialog();
        }

    }
}

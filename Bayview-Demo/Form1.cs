using System;
using System.Windows.Forms;
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

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection dbcon = new SQLiteConnection())
                {
                    dbcon.ConnectionString = dbConnection.source;
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
                            //if paswords dont match, throw an exception
                            dr.Read();
                            if (tbpasswd.Text != dr[0].ToString())
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
                MessageBox.Show("Login unsuccessful");
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
            try
            {
                //write the newly supplied password out to the db
                using (SQLiteConnection dbcon = new SQLiteConnection())
                {
                    dbcon.ConnectionString = dbConnection.source;
                    string sql = "UPDATE staff SET passwd=@pw WHERE staffID=@id";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, dbcon))
                    {
                        cmd.Parameters.AddWithValue("pw", tbreset1.Text);
                        cmd.Parameters.AddWithValue("id", stfid);
                        dbcon.Open();
                        cmd.ExecuteNonQuery();
                        dbcon.Close();
                    }
                }
                MessageBox.Show("Password reset");
                setpwdchng(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbreset1.Clear();
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
            lbnewpwd1.Visible = setas;
            tbreset1.Clear();
            tbreset1.Visible = setas;
            btnpwd.Visible = setas;
            btncnl.Visible = setas;
            btnlogout.Enabled = !setas;
            btnnewpwd.Enabled = !setas;
            btncust.Enabled = !setas;
            btnbook.Enabled = !setas;
        }

    }
}

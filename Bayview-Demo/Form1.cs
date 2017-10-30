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
                        }
                    }
                }
            }
            catch
            {
                //if something went wrong, show details
                MessageBox.Show("Login unsuccessful");
            }
            finally
            {
                //clear the user input fields
                tbusername.Clear();
                tbpasswd.Clear();
            }
        }
    }
}

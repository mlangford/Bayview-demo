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

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
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

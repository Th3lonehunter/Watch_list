using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Watch_list.Properties;//this allows for the access to the settings property to store a user name through out the application 

namespace Watch_list
{
    public partial class Main : Form
    {

        TVList_screen frm1;
        Account_Creation frm3;
        Login frm4;
       
     

        public Main()
        {
            InitializeComponent();
            
        }

       

        private void tVListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1 = new TVList_screen();
            frm1.MdiParent = this;
            frm1.Show();
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

            DBConnection.verification_cleanup();
            string un = Settings.Default["Username"].ToString();

          
          

           /*if (un == "")
            {
                Menu.Enabled = false;
            }
            else
            {
                Menu.Enabled = true;
            }*/
        }

        
        

  

        private void login_Click(object sender, EventArgs e)
        {
            frm4 = new Login();
            frm4.MdiParent = this;
            frm4.Show();
            Main m = new Main();
            m.Enabled = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            logout.Enabled = false;
            logout.Visible = false;
            login.Visible = true;
            login.Enabled = true;
            MessageBox.Show("Log out successful");
            Common.uID = 0;
            Common.UserName = null;
            

        }

        private void storedDataCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User ID:" + Common.uID + " Username: "+ Common.UserName);
        }

      
    }
}

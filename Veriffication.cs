using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watch_list
{
    public partial class Veriffication : Form
    {
        public Veriffication()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (DBConnection.verify(Common.uID, textBox1.Text))
            {
                DBConnection.Verification_confirm(Common.uID);
                MessageBox.Show("Account active! \nYou may now login to access the ammpliaction");
                this.Close();
            }
            else
            {
                MessageBox.Show("Account activation failed");
            }
        }

        private void Veriffication_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Account_Creation : Form
    {
        Veriffication ver;
        List<Users> userLog;
        public Account_Creation()
        {
            InitializeComponent();
        }
       
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox7.Text)
            {
                try
                {
                    if (VerificationCode.ValidEmailCheck(textBox1.Text))
                    {

                        string LN;
                    if (textBox5.Text == "")
                    {
                        LN = "N/A";
                    }
                    else
                    {
                        LN = textBox5.Text;
                    }
                    DBConnection.CreateAccount(textBox4.Text, textBox2.Text, LN, int.Parse(textBox6.Text), textBox1.Text, textBox3.Text);
                        userLog = DBConnection.getUSER(textBox4.Text, textBox3.Text);
                        Common.UserName = userLog.Find(i => i.userN == textBox4.Text).userN;
                        Common.uID = userLog.Find(i => i.userN == textBox4.Text).ID;
                        VerificationCode.emailsend(textBox1.Text, textBox2.Text);
                        ver = new Veriffication();
                        ver.MdiParent = this.MdiParent;
                        ver.Show();

                        this.Close();
                    }


                }
                catch (Exception E)
                {
                    MessageBox.Show("Please Enter the details" + E);
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Passwords do not match please ensure the password is entered both times correctly");
            }
        }

        private void Account_Creation_Load(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            textBox7.PasswordChar = '*';

        }
    }
}

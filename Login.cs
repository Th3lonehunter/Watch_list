using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watch_list.Properties;

namespace Watch_list
{
    public partial class Login : Form
    {
        List<Users> userLog;
        Account_Creation frm3;
        Veriffication veryfi;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DBConnection.Login_email_check(textBox1.Text, textBox2.Text))
            {
                if (DBConnection.Active_Account_check(textBox1.Text, textBox2.Text))
                {
                    Control[] controls = this.MdiParent.Controls.Find("menuStrip1", false);//here is the link to where i found how to enable features in the MdiParent: https://www.codeproject.com/Questions/422670/enable-disable-menu-items-of-mdiparent-from-anothe
                    foreach (Control ctrl in controls)
                    {
                        if (ctrl.Name == "menuStrip1")
                        {
                            MenuStrip strip = ctrl as MenuStrip;
                            strip.Items["Menu"].Enabled = true;
                            strip.Items["login"].Enabled = false;
                            strip.Items["logout"].Enabled = true;
                            strip.Items["login"].Visible = false;
                            strip.Items["logout"].Visible = true;

                        }
                    }
                    userLog = DBConnection.getUSER(textBox1.Text, textBox2.Text);

                    Common.UserName = userLog.Find(i => i.userN.ToUpper() == textBox1.Text.ToUpper()).userN;
                    Common.uID = userLog.Find(i => i.userN.ToUpper() == textBox1.Text.ToUpper()).ID;

                    MessageBox.Show("user id:" + Common.uID + " UserName is: " + Common.UserName);


                    this.Close();
                }
                else
                {
                    userLog = DBConnection.getUSER(textBox1.Text, textBox2.Text);

                    Common.UserName = userLog.Find(i => i.userN == textBox1.Text).userN;
                    Common.uID = userLog.Find(i => i.userN == textBox1.Text).ID;

                    if (DBConnection.verify_code_check(Common.uID))
                    {
                        MessageBox.Show("Please verify account");
                        veryfi = new Veriffication();
                        veryfi.MdiParent = this.MdiParent;
                        veryfi.Show();
                    }
                    else
                    {
                        MessageBox.Show("A new verification code will be sent to activate the account");
                        VerificationCode.emailsend(userLog.Find(i => i.userN == textBox1.Text).EMAil, userLog.Find(i => i.userN == textBox1.Text).FirstN);
                        veryfi = new Veriffication();
                        veryfi.MdiParent = this.MdiParent;
                        veryfi.Show();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("UserName or Password not found");

            }
        
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm3 = new Account_Creation();
            frm3.MdiParent = this.MdiParent;
            frm3.Show();
        }
    }
}

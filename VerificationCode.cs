using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Timers;

namespace Watch_list
{
    class VerificationCode
    {

        
        

        private static string verification_code(int VCL)//Code for the bellow was created following the example in the givven link: https://stackoverflow.com/questions/23011807/generating-a-random-alphanumeric-code-c-sharp
        {
            Random RNVC = new Random();
            var CSP = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var CODE = new string(
                Enumerable.Repeat(CSP, VCL).Select(s => s[RNVC.Next(s.Length)]).ToArray());
            return CODE;
        }

        public static bool ValidEmailCheck(string email) // the code for checking the validation of an email was sourced from https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        {
            try
            {
                var EA = new MailAddress(email);
                return EA.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static void message_sent(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled == true)
            {
                MessageBox.Show("Email send was Cancelled!!");
            }
            else
            {
                MessageBox.Show("Email sent to user successfully!!!");

            }
        }

        public static void emailsend(string email, string name)
        {
      
         
            MailMessage Verification_message;
            SmtpClient smtp;
            string vc = verification_code(6);

            int uid = Common.uID;
            DateTime codedtae = DateTime.Now;
            DBConnection.verification(uid, vc, codedtae);

            Verification_message = new MailMessage();
            // the code on how to send emails from inside C# windows froms was found here :  https://www.c-sharpcorner.com/UploadFile/deepak.sharma00/send-email-from-C-Sharp-windows-application-using-gmail-smtp/
            Verification_message.To.Add(email);
            Verification_message.Subject = "Watch List Account Verification code";
            Verification_message.From = new MailAddress("watchlistemailtest@gmail.com");
            Verification_message.Body = "Hello " + name + " \nYour verification code to activate your account is bellow \n" +
                vc;

            smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("watchlistemailtest@gmail.com", "Huntercain10176#");
            smtp.SendAsync(Verification_message, Verification_message.Subject);
            smtp.SendCompleted += new SendCompletedEventHandler(message_sent);



        }

    }
}

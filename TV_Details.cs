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
    public partial class TV_Details : Form
    {

        

        public TV_Details(string Show)
        {
            InitializeComponent();
            List<TVDetailsPull> tv = DBConnection.Movie_Details(Show);
            int tvID = tv.Find(i => i.Title == Show).TVID;
            List<GenreList> G_List = DBConnection.MovieDetails_G(tvID);
            List<WatchStatus> WS = DBConnection.watchstat(tvID);
            List<WSList> wsl = DBConnection.WSL();
            label1.Text = tv.Find(i => i.Title == Show).Title;
            richTextBox1.Text = tv.Find(i => i.Title == Show).decription;

            foreach(GenreList G in G_List)
            {
                richTextBox2.Text +=  G.GenrE + "\n";
            }

            if(DBConnection.watchstatbool(tvID)){
                label4.Text = WS.Find(i => i.showID == tvID && i.USRID == Common.uID).Stat;
            }
            else
            {
                label4.Text = wsl.Find(i => i.wsID == 1).Stat;
            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TV_Details_Load(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.SelectAll();
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
        }

       
    }
}

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
using System.Net;
using System.Net.Mail;


namespace Watch_list
{
    public partial class TVList_screen : Form
    {
        TV_Details frm2;
        Main M;

        private List<TVList> myTV;
        private List<Multi_Genre_Link> Linked_Genre;
        private List<GenreList> Genre;
        private List<ShowType> ShowType;
        

        public TVList_screen()
        {
            InitializeComponent();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int selected_index = dataGridView1.SelectedRows[0].Index;
                DataGridViewRow row = this.dataGridView1.Rows[selected_index];
                string show = (string)row.Cells["Title"].Value;
                frm2 = new TV_Details(show);
                frm2.MdiParent = this.MdiParent;
                frm2.Show();
            }

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

           
           
        }

        private void TVList_screen_Load(object sender, EventArgs e)
        {
            myTV = DBConnection.LoadTV();

            Linked_Genre = DBConnection.TV_Linked_Genre();
            Genre = DBConnection.LoadGenre();
            ShowType = DBConnection.LoadType();

            try
            {
                var source = new BindingSource();



                GenreCombo.DataSource = Genre;
                GenreCombo.DisplayMember = "Genre";
                GenreCombo.ValueMember = "ID";
                GenreCombo.SelectedIndex = 0;
                Showtype.DataSource = ShowType;
                Showtype.DisplayMember = "Type";
                Showtype.ValueMember = "ID";
                Showtype.SelectedIndex = 0;
                source.DataSource = myTV;
                dataGridView1.DataSource = source;
                dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



}

        private void GenreCombo_SelectedIndexChanged(object sender, EventArgs e)// needs work
        {
            int gid = int.Parse(GenreCombo.SelectedIndex.ToString());
       
            int tid = int.Parse(Showtype.SelectedIndex.ToString());

            if (gid != 0)
            {
                if (tid <= 0)
                {
                    myTV = DBConnection.Genre_Filtered_List(gid);



                    var source = new BindingSource();

                    source.DataSource = myTV;
                    dataGridView1.DataSource = source;


                }
                else
                {
                    myTV = DBConnection.type_Genre_Filtered_List(tid, gid);




                    var source = new BindingSource();

                    source.DataSource = myTV;
                    dataGridView1.DataSource = source;
                }
            }
            else
            {
                myTV = DBConnection.LoadTV();

               
                var source = new BindingSource();

                source.DataSource = myTV;
                dataGridView1.DataSource = source;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Showtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tid = int.Parse(Showtype.SelectedIndex.ToString());
            int gid = int.Parse(GenreCombo.SelectedIndex.ToString());

            
            if (tid != 0)
            {
                if (gid <= 0)
                {
                    myTV = DBConnection.type_Filtered_List(tid);



                    var source = new BindingSource();

                    source.DataSource = myTV;
                    dataGridView1.DataSource = source;
                }
                else
                {
                    myTV = DBConnection.type_Genre_Filtered_List(tid, gid);




                    var source = new BindingSource();

                    source.DataSource = myTV;
                    dataGridView1.DataSource = source;
                }
                    
            }
            else
            {

                myTV = DBConnection.LoadTV();

                

                var source = new BindingSource();

                source.DataSource = myTV;
                dataGridView1.DataSource = source;
            }
        }
    }

    

        
 }


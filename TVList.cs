using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class TVList
    {
        //private int TV_ID;
        private string TV_Name;
        //private string TV_description;
        private int EC;
        private string ARG;
    



        public TVList(string TV_Name, int EC, string ARG)

        {
            //this.TV_ID = TV_ID;
            this.TV_Name = TV_Name;
            this.EC = EC;
            this.ARG = ARG;
            //this.TV_description = TV_description;
           
            
        }

        /*public int TVID
        {
            get { return TV_ID; }
            set { TV_ID = value; }
        }*/
        public string Title
        {
            get { return TV_Name; }
            set { TV_Name = value; }
        }
        public int Episodes
        {
            get { return EC; }
            set { EC = value; }
        }
        public string Runt_time_minutes 
        {
            get { return ARG; }
            set { ARG = value; }
        }

        /*public string decription
        {
            get { return TV_description; }
            set { TV_description = value; }
        }*/
       
    }
}

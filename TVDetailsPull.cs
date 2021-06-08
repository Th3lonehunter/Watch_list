using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class TVDetailsPull
    {
        private int TV_ID;
        private string TV_Name;
        private string TV_description;
        private int EC;
        private string ARG;
        private int RID;
        private int TID;



        public TVDetailsPull(int TV_ID, string TV_Name, string TV_description, int EC, string ARG, int TID, int RID)

        {
            this.TV_ID = TV_ID;
            this.TV_Name = TV_Name;
            this.EC = EC;
            this.ARG = ARG;
            this.TV_description = TV_description;
            this.TID = TID;
            this.RID = RID;

        }

        public int TVID
        {
            get { return TV_ID; }
            set { TV_ID = value; }
        }
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
        public string Run_time
        {
            get { return ARG; }
            set { ARG = value; }
        }

        public string decription
        {
            get { return TV_description; }
            set { TV_description = value; }
        }
        public int TypeID
        {
            get { return TID; }
            set { TID = value; }
        }
        public int RatingID
        {
            get { return RID; }
            set { RID = value; }
        }
    }

}

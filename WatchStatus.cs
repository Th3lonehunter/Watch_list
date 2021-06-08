using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class WatchStatus
    {
        private int UID;
        private int ShowID;
        private string Status;

        public WatchStatus(int UID,int ShowID,string Status)
        {
            this.UID = UID;
            this.ShowID = ShowID;
            this.Status = Status;
        }


        public int USRID
        {
            get { return UID; }
            set { UID = value; }
        }
        public int showID
        {
            get { return ShowID; }
            set { ShowID = value; }
        }
        public string Stat
        {
            get { return Status; }
            set {Status = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class WSList
    {
        
        private int wID;
        private string Status;

        public WSList(int wID, string Status)
        {
            
            this.wID = wID;
            this.Status = Status;
        }


        
        public int wsID
        {
            get { return wID; }
            set { wID = value; }
        }
        public string Stat
        {
            get { return Status; }
            set { Status = value; }
        }





    }
}

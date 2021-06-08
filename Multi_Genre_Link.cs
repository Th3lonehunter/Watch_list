using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class Multi_Genre_Link
    {
        private int ID;
        private int GID;



        public Multi_Genre_Link(int ID, int GID)
        {
            this.ID = ID;
            this.GID = GID;
        }

        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public int gid
        {
            get { return GID; }
            set { GID = value; }
        }
    }
}

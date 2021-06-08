using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class Users
    {
        private int UID;
        private string UN;
        private string FN;
        private string AC;
        private string email;
        
        public Users(int UID, string UN,string FN,string AC, string email)
        {
            this.UID = UID;
            this.UN = UN;
            this.FN = FN;
            this.AC = AC;
            this.email = email;
        }


        public int ID
        {
            get { return UID;  }
            set { UID = value; }
        }

        public string userN
        {
            get { return UN; }
            set { UN = value; }
        }
        public string FirstN
        {
            get { return FN; }
            set { FN = value; }
        }
        public string Active
        {
            get { return AC; }
            set { AC = value; }
        }
        public string EMAil
        {
            get { return email; }
            set { email = value; }
        }
    }
}

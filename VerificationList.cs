using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class VerificationList
    {
        private int UID;
        private string Code;

        public VerificationList(int UID,string Code)
        {
            this.UID = UID;
            this.Code = Code;
        }

        public int UserID
        {
            get { return UID; }
            set { UID = value; }
        }

        public string VerificationCode
        {
            get { return Code; }
            set { Code = value; }
        }


    }
}

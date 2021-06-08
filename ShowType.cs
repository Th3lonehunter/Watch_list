using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class ShowType
    {

        private int id;
        private string Type;

        public ShowType(int id, string Type)
        {
            this.id = id;
            this.Type = Type;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string type
        {
            get { return Type; }
            set { Type = value; }
        }

    }
}

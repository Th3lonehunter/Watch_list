using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class GenreList
    {
        private int id;
        private string genre;

        public GenreList(int id, string genre)
        {
            this.id = id;
            this.genre = genre;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string GenrE
        {
            get { return genre; }
            set { genre = value; }
        }
    }
}

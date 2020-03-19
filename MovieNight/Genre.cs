using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    class Genre
    {
        private int id;
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Genre(string type)
        {
            this.Type = type;
        }
        
        public Genre(int id)
        {
            this.ID = id;
        }

        public Genre(int id, string type)
            :this(type)
        {
            this.ID = id;
        }

    }
}

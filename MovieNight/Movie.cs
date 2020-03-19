using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    class Movie
    {
        private int id; 
        private string title;
        private int releaseYear;
        private string description;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public Movie(int id, string title, int releaseYear, string description)
        {
            this.ID = id;
            this.Title = title;
            this.Description = description;
            this.ReleaseYear = releaseYear;
        }

        public Movie(string title)
        {
            this.Title = title;
        }
    }
}

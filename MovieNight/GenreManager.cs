using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    class GenreManager
    {
        public static Genre AddGenre(Genre genre)
        {
            return DalManager.InsertGenre(genre);
        }

        public static List<Genre> GenreList(string search)
        {
            return DalManager.GenreList(search);
        }

        public static Genre UpdateGenre(Genre genre)
        {
            return DalManager.UpdateGenre(genre);
        }

        public static Genre DeleteGenre(Genre genre)
        {
            return DalManager.DeleteGenre(genre);
        }
    }
}

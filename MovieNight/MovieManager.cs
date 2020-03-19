using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    static class MovieManager
    {

        public static List<Movie> MovieList(string search)
        {
            return DalManager.GetMovies(search);
        }
        
        public static List<Movie> GenreMovieList(string search)
        {
            return DalManager.GetMoviesByGenre(search);
        }
    }
}

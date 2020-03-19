using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MovieNight
{
    static class DalManager
    {
        private static string cs = @"Data Source=CASPER-PC;Initial Catalog=MovieNight;Integrated Security=True";

        public static List<Movie> GetMovies(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Movie WHERE title LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%"+search+"%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string title = (string)rdr["Title"];
                    string description = (string)rdr["Description"];
                    int releaseYear = (int)rdr["Year"];

                    Movie m = new Movie(id, title, releaseYear, description);

                    movies.Add(m);
                }
            }
            return movies;
        }

        public static List<Actor> GetActors(string search)
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Actor WHERE Name LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string firstName = (string)rdr["Name"];
                    string lastName = (string)rdr["LastName"];

                    Actor a = new Actor(firstName, lastName);

                    actors.Add(a);
                }
            }
            return actors;
        }

        public static List<Movie> GetMoviesByGenre(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Title FROM Movie INNER JOIN MovieGenre ON[Movie].[ID] = [MovieGenre].[MovieID] INNER JOIN Genre ON[Genre].[ID] = [MovieGenre].[GenreID] WHERE Type LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string title = (string)rdr["Title"];
                    
                    Movie m = new Movie(title);

                    movies.Add(m);
                }
            }
            return movies;
        }
    }
}

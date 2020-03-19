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

                    Movie mov = new Movie(id, title, releaseYear, description);

                    movies.Add(mov);
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
                    int id = (int)rdr["ID"];
                    string firstName = (string)rdr["Name"];
                    string lastName = (string)rdr["LastName"];

                    Actor act = new Actor(id, firstName, lastName);

                    actors.Add(act);
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
                    
                    Movie movg = new Movie(title);

                    movies.Add(movg);
                }
            }
            return movies;
        }

        public static List<Genre> GenreList(string search)
        {
            List<Genre> genres = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Genre WHERE Type LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string type = (string)rdr["Type"];

                    Genre mov = new Genre(id, type);

                    genres.Add(mov);
                }
            }
            return genres;
        }

        public static Actor InsertActor(Actor actor)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Actor(name,lastname) values(@fn,@ln)", connection);
                cmd.Parameters.Add(new SqlParameter("@fn", actor.FirstName));
                cmd.Parameters.Add(new SqlParameter("@ln", actor.LastName));
                cmd.ExecuteNonQuery();
            }
            return actor;
        }

        public static Movie InsertMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Movie(Title, Year, Description) values(@Title,@Year,@Des)", connection);
                cmd.Parameters.Add(new SqlParameter("@Title", movie.Title));
                cmd.Parameters.Add(new SqlParameter("@Year", movie.ReleaseYear));
                cmd.Parameters.Add(new SqlParameter("@Des", movie.Description));
                cmd.ExecuteNonQuery();
            }
            return movie;
        }

        public static Genre InsertGenre(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Genre(Type) values(@Type)", connection);
                cmd.Parameters.Add(new SqlParameter("@Type", genre.Type));
                cmd.ExecuteNonQuery();
            }
            return genre;
        }

        public static Actor UpdateActor(Actor actor)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Actor SET Name = @fn, LastName = @ln WHERE ID = @id", connection);
                cmd.Parameters.Add(new SqlParameter("@fn", actor.FirstName));
                cmd.Parameters.Add(new SqlParameter("@ln", actor.LastName));
                cmd.Parameters.Add(new SqlParameter("@id", actor.ID));
                cmd.ExecuteNonQuery();
            }
            return actor;
        }

        public static Movie UpdateMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Movie SET Title = @ti, Year = @ry, Description = @des WHERE ID = @id", connection);
                cmd.Parameters.Add(new SqlParameter("@ti", movie.Title));
                cmd.Parameters.Add(new SqlParameter("@ry", movie.ReleaseYear));
                cmd.Parameters.Add(new SqlParameter("@des", movie.Description));
                cmd.Parameters.Add(new SqlParameter("@id", movie.ID));
                cmd.ExecuteNonQuery();
            }
            return movie;
        }

        public static Genre UpdateGenre(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Genre SET Type = @ty WHERE ID = @id", connection);
                cmd.Parameters.Add(new SqlParameter("@ty", genre.Type));
                cmd.Parameters.Add(new SqlParameter("@id", genre.ID));
                cmd.ExecuteNonQuery();
            }
            return genre;
        }

        public static Actor DeleteActor(Actor actor)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Contributes WHERE ActorID = @id; DELETE FROM Actor WHERE ID = @id;", connection);
                cmd.Parameters.Add(new SqlParameter("@id", actor.ID));
                cmd.ExecuteNonQuery();
            }
            return actor;
        }

        public static Movie DeleteMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Contributes WHERE MovieID = @id; DELETE FROM MovieGenre WHERE MovieID = @id; DELETE FROM Movie WHERE ID = @id", connection);
                cmd.Parameters.Add(new SqlParameter("@id", movie.ID));
                cmd.ExecuteNonQuery();
            }
            return movie;
        }

        public static Genre DeleteGenre(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM MovieGenre WHERE GenreID = @id; DELETE FROM Genre WHERE ID = @id;", connection);
                cmd.Parameters.Add(new SqlParameter("@id", genre.ID));
                cmd.ExecuteNonQuery();
            }
            return genre;
        }
    }
}

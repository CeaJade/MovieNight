using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieNight
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("MOVIENIGHT\n");
                Console.Write("1) Search \n2) Edit data \n3) Exit \nInput: ");
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.Write("\nInvalid input.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Search();
                        break;

                    case 2:
                        Console.Clear();
                        EditData();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Write("\nInvalid input.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public static void Search()
        {
            int input;
            do
            {
                Console.Write("1) Search for a movie \n2) Search for an actor \n3) Search for Genre \n4) Back \n\nInput: ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("\nInvalid input.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        SearchMovie();
                        break;

                    case 2:
                        Console.Clear();
                        SearchActor();
                        break;

                    case 3:
                        Console.Clear();
                        SearchByGenre();
                        break;

                    case 4:
                        Console.Clear();
                        break;

                    default:
                        Console.Write("\nInvalid input.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (input != 4);
        }

        public static void SearchMovie()
        {
            Console.Write("Movie search: ");
            string searchMov = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nList of Movies");
            Console.ResetColor();
            List<Movie> movie = MovieManager.MovieList(searchMov);
            foreach (Movie item in movie)
            {
                Console.WriteLine("Movie title: " + item.Title + "\nRelease Year: " + item.ReleaseYear + "\nDescription: '" + item.Description + "'\n\n");
            }
            if(movie.Count == 0)
            {
                Console.WriteLine("\nNo result related to '" + searchMov + "'\nTry something else.\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void SearchActor()
        {
            Console.Write("Actor search: ");
            string searchAct = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nList of actors");
            Console.ResetColor();
            List<Actor> actor = ActorManager.ActorList(searchAct);
            foreach (Actor item in actor)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName + "\n");
            }
            if (actor.Count == 0)
            {
                Console.WriteLine("No result related to '" + searchAct + "'\nTry something else.\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void SearchByGenre()
        {
            Console.Write("search for genre: ");
            string genre = Console.ReadLine();

            Console.WriteLine("\nMovies related to: " + genre);
            List<Movie> movieByGenre = MovieManager.GenreMovieList(genre);
            foreach (Movie item in movieByGenre)
            {
                Console.WriteLine("\n" + item.Title);
            }
            if (movieByGenre.Count == 0)
            {
                Console.WriteLine("\nNo result related to '" + genre + "'\nTry something else.\n");
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void EditData()
        {
            int input;
            do
            {
                Console.Write("1) Add \n2) Update \n3) Delete \n4) Back \n\nInput: ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("\nInvalid input.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        AddData();
                        break;

                    case 2:
                        Console.Clear();
                        UpdateData();
                        break;

                    case 3:
                        Console.Clear();
                        DeleteData();
                        break;

                    case 4:
                        Console.Clear();
                        break;

                    default:
                        Console.Write("\nInvalid input.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (input != 4);
        }

        
        public static void AddData()
        {
            int input;
            do
            {
                Console.Write("1) Add a movie \n2) Add an actor \n3) Add Genre \n4) Back \n\nInput: ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("\nInvalid input.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        AddMovie();
                        break;

                    case 2:
                        Console.Clear();
                        AddActor();
                        break;

                    case 3:
                        Console.Clear();
                        AddGenre();
                        break;

                    case 4:
                        Console.Clear();
                        break;

                    default:
                        Console.Write("\nInvalid input.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (input != 4);
        }

        public static void AddMovie()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Clear();
            int releaseYear;
            bool notANum;
            do
            {
                notANum = false;
                Console.Write("Release year: ");
                if (!int.TryParse(Console.ReadLine(), out releaseYear))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    notANum = true;
                }
                Console.Clear();
            } while (notANum);
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.Clear();

            MovieManager.AddMovie(new Movie(title, releaseYear, desc));
            Console.Write(title + " has been added to Movies");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void AddActor()
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Clear();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            ActorManager.AddActor(new Actor(firstName, lastName));
            Console.Clear();
            Console.WriteLine(firstName + " " + lastName + " has been added to Actors.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void AddGenre()
        {
            Console.Write("Add Genre: ");
            string genre = Console.ReadLine();

            GenreManager.AddGenre(new Genre(genre));
            Console.Write(genre + " has been added to Genres");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void UpdateData()
        {
            int input;
            do
            {
                Console.Write("1) Update Actor \n2) Update Movie \n3) Update Genre \n4) Back \n\nInput: ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("\nInvalid input.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        UpdateActor();
                        break;

                    case 2:
                        Console.Clear();
                        UpdateMovie();
                        break;

                    case 3:
                        Console.Clear();
                        UpdateGenre();
                        break;

                    case 4:
                        Console.Clear();
                        break;

                    default:
                        Console.Write("\nInvalid input.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (input != 4);
        }

        public static void UpdateActor()
        {
            int actId;
            bool notANum;
            List<Actor> actors;
            do
            {
                Console.Write("Which actor would you like to edit?\n");
                actors = ActorManager.ActorList("");
                int i = 0;
                foreach (Actor actor in actors)
                {
                    i++;
                    Console.WriteLine(i + ") " + actor.FirstName + " " + actor.LastName);
                }

                notANum = false;
                Console.Write("Input: ");
                if (!int.TryParse(Console.ReadLine(), out actId))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    notANum = true;
                }
                Console.Clear();

            } while (notANum);
            int updAct = actors[actId - 1].ID;

            Console.Clear();
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Clear();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Clear();

            ActorManager.UpdateActor(new Actor(updAct, firstName, lastName));

            Console.WriteLine("Actor has now been updated");
            Console.ReadKey();
            Console.Clear();
        }

        public static void UpdateMovie()
        {
            int movId;
            bool notANum;
            List<Movie> movies;
            do
            {   
                Console.Write("Which movie would you like to edit?\n");
                movies = MovieManager.MovieList("");
                int i = 0;
                foreach (Movie movie in movies)
                {
                    i++;
                    Console.WriteLine(i + ") " + movie.Title);
                }

                notANum = false;
                Console.Write("Input: ");
                if (!int.TryParse(Console.ReadLine(), out movId))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    notANum = true;
                }
                Console.Clear();

            } while (notANum);
            int updMov = movies[movId - 1].ID;

            Console.Clear();
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Clear();

            int releaseYear;
            bool noNum;
            do
            {
                noNum = false;
                Console.Write("Release year: ");
                if (!int.TryParse(Console.ReadLine(), out releaseYear))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    noNum = true;
                }
                Console.Clear();
            } while (noNum);

            Console.Write("Description: ");
            string des = Console.ReadLine();
            Console.Clear();

            MovieManager.UpdateMovie(new Movie(updMov, title, releaseYear, des));

            Console.WriteLine("Movie has now been updated");
            Console.ReadKey();
            Console.Clear();
        }

        public static void UpdateGenre()
        {
            Console.Write("Which genre would you like to edit?\n");
            List<Genre> genres = GenreManager.GenreList("");
            int i = 0;
            foreach (Genre genre in genres)
            {
                i++;
                Console.WriteLine(i + ") " + genre.Type);
            }

            int genId;
            bool notANum;
            do
            {
                notANum = false;
                Console.Write("Input: ");
                if (!int.TryParse(Console.ReadLine(), out genId))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    notANum = true;
                }
                Console.Clear();
            } while (notANum);

            Console.Clear();
            int updGen = genres[genId - 1].ID;

            Console.Clear();
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Console.Clear();

            GenreManager.UpdateGenre(new Genre(updGen, type));

            Console.WriteLine("Genre has now been updated");
            Console.ReadKey();
            Console.Clear();
        }


        public static void DeleteData()
        {
            int input;
            do
            {
                Console.Write("1) Delete Movie \n2) Delete Actor \n3) Delete Genre \n4) Back \n\nInput: ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("\nInvalid input.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        DeleteMovie();
                        break;

                    case 2:
                        Console.Clear();
                        DeleteActor();
                        break;

                    case 3:
                        Console.Clear();
                        DeleteGenre();
                        break;

                    case 4:
                        Console.Clear();
                        break;

                    default:
                        Console.Write("\nInvalid input.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (input != 4);
        }

        public static void DeleteActor()
        {
            int actId;
            bool notANum;
            List<Actor> actors;
            do
            {
                Console.Write("Which actor would you like to delete?\n");
                actors = ActorManager.ActorList("");
                int i = 0;
                foreach (Actor actor in actors)
                {
                    i++;
                    Console.WriteLine(i + ") " + actor.FirstName + " " + actor.LastName);
                }

                notANum = false;
                Console.Write("Input: ");
                if (!int.TryParse(Console.ReadLine(), out actId))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    notANum = true;
                }
                Console.Clear();

            } while (notANum);
            int delAct = actors[actId - 1].ID;

            Console.Write("Are you sure you want to delete " + actors[actId - 1].FirstName + " " + actors[actId - 1].LastName + "? \n1) Yes \n2) No \nInput: ");
            if (!int.TryParse(Console.ReadLine(), out int sure))
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
                notANum = true;
            }
            if (sure == 1)
            {
                ActorManager.DeleteActor(actors[actId - 1]);
                Console.Write("Actor has been deleted");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Deletion has been cancelled");
                Console.ReadKey();
                Console.Clear();
            }   
        }

        public static void DeleteMovie()
        {
            int movId;
            bool notANum;
            List<Movie> movies;
            do
            {
                Console.Write("Which movie would you like to delete?\n");
                movies = MovieManager.MovieList("");
                int i = 0;
                foreach (Movie movie in movies)
                {
                    i++;
                    Console.WriteLine(i + ") " + movie.Title);
                }

                notANum = false;
                Console.Write("Input: ");
                if (!int.TryParse(Console.ReadLine(), out movId))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    notANum = true;
                }
                Console.Clear();

            } while (notANum);
            int delMov = movies[movId - 1].ID;

            Console.Write("Are you sure you want to delete " + movies[movId - 1].Title + "? \n1) Yes \n2) No \nInput: ");
            if (!int.TryParse(Console.ReadLine(), out int sure))
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
                notANum = true;
            }
            if (sure == 1)
            {
                MovieManager.DeleteMovie(movies[movId - 1]);
                Console.Write("Movie has been deleted");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Deletion has been cancelled");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void DeleteGenre()
        {
            int genId;
            bool notANum;
            List<Genre> genres;
            do
            {
                Console.Write("Which actor would you like to delete?\n");
                genres = GenreManager.GenreList("");
                int i = 0;
                foreach (Genre genre in genres)
                {
                    i++;
                    Console.WriteLine(i + ") " + genre.Type);
                }

                notANum = false;
                Console.Write("Input: ");
                if (!int.TryParse(Console.ReadLine(), out genId))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    notANum = true;
                }
                Console.Clear();

            } while (notANum);
            int delGen = genres[genId - 1].ID;

            Console.Write("Are you sure you want to delete " + genres[genId - 1].Type + "? \n1) Yes \n2) No \nInput: ");
            if (!int.TryParse(Console.ReadLine(), out int sure))
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
                notANum = true;
            }
            if (sure == 1)
            {
                GenreManager.DeleteGenre(genres[genId - 1]);
                Console.Write("Genre has been deleted");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Deletion has been cancelled");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}

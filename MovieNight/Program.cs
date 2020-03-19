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
                Console.WriteLine("MOVIES\n");
                Console.Write("1) Search for a movie \n2) Search for an actor \n3) Search for Genre \n4) Exit \n\nInput: ");
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

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Categories
{
    class Program
    {
        

        static void Main(string[] args)
        {
            _Movies pathloc = new _Movies();


            string MovieDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)))) + @"\Hangman\bin\Debug\Movies.txt";

            string MoviePath = new Uri(MovieDir).LocalPath;

            List<_Movies> Movies = new List<_Movies>();

            Movies.Add(new _Movies("Die Hard".ToUpper()));
            Movies.Add(new _Movies("Transformers".ToUpper()));
            Movies.Add(new _Movies("Thor".ToUpper()));
            Movies.Add(new _Movies("Rocky".ToUpper()));

            if (!File.Exists(MoviePath))
            {
                using (StreamWriter swMovies = new StreamWriter(MoviePath))
                {
                    foreach (var a in Movies)
                    {
                        swMovies.WriteLine(a.Name);
                    }
                }
            }

            string GameDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)))) + @"\Hangman\bin\Debug\Games.txt";

            string GamePath = new Uri(GameDir).LocalPath;

            List<_Games> Games = new List<_Games>();

            Games.Add(new _Games("WOW".ToUpper()));
            Games.Add(new _Games("LOL".ToUpper()));
            Games.Add(new _Games("Monster Hunter World".ToUpper()));
            Games.Add(new _Games("Dota 2".ToUpper()));


            if (!File.Exists(GamePath))
            {
                using (StreamWriter swGames = new StreamWriter(GamePath))
                {
                    foreach (var a in Games)
                    {
                        swGames.WriteLine(a.Name);
                    }
                }
            }

            Console.ReadLine();

        }
    }
}

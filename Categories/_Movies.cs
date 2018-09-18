using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Categories
{
    public class _Movies
    {
        public string Name { get; set; }

        private static string FileDir2 = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)))) + @"\Hangman\bin\Debug\Movies.txt";

        public static string MoviePath1 = new Uri(FileDir2).LocalPath;

        public string MoviePath
        {   get
            {
                return MoviePath1;
            }
            set
            {
                
            }
        }

        public _Movies()
        {
            
        }

        public _Movies(string name)
        {
            this.Name = name;
        }
    }
}

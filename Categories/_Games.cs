using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Categories
{
    public class _Games
    {
        public string Name { get; set; }

        private static string FileDir2 = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)))) + @"\Hangman\bin\Debug\Games.txt";

        public static string GamePath1 = new Uri(FileDir2).LocalPath;

        public string GamePath
        {
            get
            {
                return GamePath1;
            }
            set
            {

            }
        }

        public _Games()
        {
            
        }

        public _Games(string name)
        {
            this.Name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman
{
    public class ValidMethods
    {

        public bool isValid(string guess1) // Checks if the entered letter is valid. i.e a single letter or number
        {
            if (guess1.Length == 1)
            {
                if (Regex.IsMatch(guess1, @"^[A-Z0-9]+$"))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Enter only a single letter please");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Enter only a single letter please");
                return false;
            }
        }


        public void printWord(List<char> word)
        {
            Console.Write(Environment.NewLine + "Word: ");
            foreach (char letter in word)
            {
                Console.Write(letter + " ");
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Categories;

namespace Hangman
{
    class Program
    {


        static void Main(string[] args)
        {
            _Movies GetFileLocMovies = new _Movies();

            _Games GetFileLocGames = new _Games();

            ValidMethods GameEngine = new ValidMethods();

            int CategoryChosen = 0;
            int incorrectGuesses = 0;
            const int GameOver = 10;

            Random rand = new Random();


            List<char> playerGuesses = new List<char>();
            List<char> guessedWord = new List<char>();



            List<string> movieWord = new List<string>();
            List<char> MovieWordRandom = new List<char>();

            List<string> gameWord = new List<string>();
            List<char> GameWordRandom = new List<char>();



            string filedir3 = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)));

            using (StreamReader srMovies = new StreamReader(GetFileLocMovies.MoviePath)) // Read the txt file with the Movie names.
            {
                while (!srMovies.EndOfStream)
                {
                    movieWord.Add(srMovies.ReadLine());
                }
            }

            


            using (StreamReader srGames = new StreamReader(GetFileLocGames.GamePath))
            {
                while (!srGames.EndOfStream)
                {
                    gameWord.Add(srGames.ReadLine());
                }
            }


             


            void ChooseCategory(out int chosen)
            {
                chosen = 3;
                Console.WriteLine("Please choose a category out of Movies or Games");
                string CategoryChosing = Console.ReadLine().ToUpper();
                while (chosen > 2)
                {
                    if (CategoryChosing == "GAMES")
                    {
                        Console.WriteLine("You've chosen category Games");

                        GameWordRandom = gameWord.ElementAt(rand.Next(gameWord.Count)).ToList<char>(); // Gets a random word from the word list.

                        HideTheWord(GameWordRandom);


                        chosen = 1;
                        CategoryChosen = chosen;
                    }
                    else if (CategoryChosing == "MOVIES")
                    {
                        Console.WriteLine("You've chosen category Movies");

                        MovieWordRandom = movieWord.ElementAt(rand.Next(movieWord.Count)).ToList<char>(); //Gets a random word from the word list.

                        HideTheWord(MovieWordRandom);

                        chosen = 2;
                        CategoryChosen = chosen;
                    }
                    else
                    {
                        Console.WriteLine("Please choose either Games or Movies");

                        CategoryChosing = Console.ReadLine().ToUpper();

                        if (CategoryChosing == "GAMES")
                        {
                            Console.WriteLine("You've chosen category Games");

                            GameWordRandom = gameWord.ElementAt(rand.Next(gameWord.Count)).ToList<char>();

                            HideTheWord(GameWordRandom);


                            chosen = 1;
                            CategoryChosen = chosen;
                        }
                        else if (CategoryChosing == "MOVIES")
                        {
                            Console.WriteLine("You've chosen category Movies");

                            MovieWordRandom = movieWord.ElementAt(rand.Next(movieWord.Count)).ToList<char>();

                            HideTheWord(MovieWordRandom);

                            chosen = 2;
                            CategoryChosen = chosen;
                        }
                    }
                }


            }


            void HideTheWord(List<char> word)
            {
                for (int i = 0; i < word.Count; i++)
                {
                    if (word[i] == ' ')
                    {
                        guessedWord.Add(' ');
                    }
                    else
                    {
                        guessedWord.Add('_');
                    }
                }
            }

            void DoYouWishToContinueIfOver()
            {
                Console.WriteLine();



                bool restartFlag = false;

                while (!restartFlag == true)
                {
                    Console.WriteLine("Press Y if you wish to start a new game or press N to exit");

                    string playerInput = Console.ReadLine().ToUpper();
                    if (GameEngine.isValid(playerInput))
                    {
                        if (playerInput == "Y")
                        {
                            restartFlag = true;
                            NewGame();
                            TheGame();
                            
                        }
                        else if (playerInput == "N")
                        {
                            restartFlag = true;
                            Environment.Exit(0);
                        }
                        else
                        {
                            restartFlag = true;
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        restartFlag = false;
                    }
                }

            }
           
            void NewGame()
                {
                    playerGuesses.Clear();
                    guessedWord.Clear();
                    incorrectGuesses = 0;

                    
                    
                    ChooseCategory(out CategoryChosen);

                }

            void TheGame()
                {
                    while (guessedWord.Contains('_'))
                    {
                        Console.Clear();
                        GameEngine.printWord(guessedWord);

                        Console.WriteLine();
                        Console.WriteLine("Remaining attempts " + (GameOver - incorrectGuesses));

                        Console.WriteLine("\nPlease take a guess");
                        string PlayerGuess = Console.ReadLine().ToUpper();


                        if (GameEngine.isValid(PlayerGuess))
                        {
                            char guess = Convert.ToChar(PlayerGuess);
                            if (CategoryChosen == 1)
                            {
                                if (!playerGuesses.Contains(guess)) // Checks to see if the player has guessed that word already
                                {
                                    if (GameWordRandom.Contains(guess)) // Checks to see if the word contains the letter
                                    {
                                        playerGuesses.Add(guess);  // We add it to the list of guessed words.
                                        for (int i = 0; i < GameWordRandom.Count; i++) // Print the letter everytime it occurs in the  word
                                        {
                                            if (GameWordRandom[i] == guess)
                                            {
                                                guessedWord[i] = guess;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        incorrectGuesses++;
                                        Thread.Sleep(650);
                                        Console.WriteLine("Your incorrect guesses so far are " + incorrectGuesses);
                                        

                                        if (incorrectGuesses == 10)
                                        {
                                            Console.WriteLine("Game Over!");
                                            Console.WriteLine("\nThe word was ");
                                            foreach(var a in GameWordRandom)
                                            {
                                                Console.Write(a);
                                            }
                                            DoYouWishToContinueIfOver();

                                        }


                                    }
                                }
                                else
                                {
                                    Thread.Sleep(650);
                                    Console.WriteLine(Environment.NewLine + "You have already guessed that letter");
                                    
                                }
                            }
                            else
                            {
                                if (!playerGuesses.Contains(guess)) // Checks to see if the letter has been guessed before
                                {
                                    if (MovieWordRandom.Contains(guess))
                                    {
                                        playerGuesses.Add(guess);
                                        for (int i = 0; i < MovieWordRandom.Count; i++)
                                        {
                                            if (MovieWordRandom[i] == guess)
                                            {
                                                guessedWord[i] = guess;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        incorrectGuesses++;
                                        Thread.Sleep(650);
                                        Console.WriteLine("Your incorrect guesses so far are " + incorrectGuesses);
                                        if (incorrectGuesses == 10)
                                        {
                                            Console.WriteLine("Game Over!");
                                            Console.WriteLine("\nThe word was ");
                                            foreach (var a in MovieWordRandom)
                                            {
                                                Console.Write(a);
                                            }
                                            DoYouWishToContinueIfOver();
                                        }
                                    }
                                }
                                else
                                {
                                    Thread.Sleep(650);
                                    Console.WriteLine("You have already guessed that letter");
                                }
                            }


                        }
                    }

                    Console.Clear();
                    GameEngine.printWord(guessedWord);

                    Console.WriteLine("\nCongratulations, you win!");

                    DoYouWishToContinueIfOver();
            }

             NewGame();
             TheGame();





                //Console.Clear();
                //GameEngine.printWord(guessedWord);

                //Console.WriteLine("\nCongratulations, you win!");


                


            }
        }
    }


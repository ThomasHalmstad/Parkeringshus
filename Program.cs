using System;
using static System.Console;


namespace Parkeringshus
{
    class Program
    {
        static void Main(string[] args)
        {

            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                WriteLine("1. Register arrival");
                WriteLine("2. Register departure");
                WriteLine("3. Show parking register");
                WriteLine("4. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);

                Clear();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        shouldNotExit = false;

                        break;
                }

                Clear();
            }

        }
    }
}

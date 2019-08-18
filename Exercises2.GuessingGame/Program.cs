using System;

namespace Exercises2.GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            while (true)
            {
                int attempt = 0;
                Console.Clear();
                Console.WriteLine("Ho generato un numero... prova ad indovinare!");
                int number = random.Next(1, 100);

                while (true)
                {
                    Write("Indovina il mio numero (1 a 100): ");
                    string input = Console.ReadLine();

                    int value = 0;
                    bool isnumber = int.TryParse(input, out value);

                    if (!isnumber)
                    {
                        Write("Non hai immesso un numero valido!", ConsoleColor.Red);
                        continue;
                    }

                    if (value < 1 || value > 100)
                    {
                        Write("Il numero deve essere nell'intervallo 1-100!", ConsoleColor.Red);
                        continue;
                    }

                    var result = Math.Sign(number - value);
                    attempt++;

                    if (result == 0)
                    {
                        Write($"Bravo hai indovinato in {attempt} tentativi!!!", ConsoleColor.Green);
                        break;
                    }
                    else if (result < 0)
                    {
                        Write("Il numero è minore");
                        continue;
                    }
                    else if (result > 0)
                    {
                        Write("Il numero è maggiore");
                        continue;
                    }
                }
            }
        }

        private static void Write(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

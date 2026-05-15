using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = 0;
        int guessCount= 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            guessCount++;

            if (magicNumber > guess)
            {
               Console.WriteLine("Higher");
            }

            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }

            else
            {
                Console.WriteLine("Yay, you guessed it!");
            }


        }

        {
            Console.Write($"You made a total of {guessCount} guesses.");
        }

    }

}
        
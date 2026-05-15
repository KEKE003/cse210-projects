using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        float percent = float.Parse(grade);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";
        if (percent % 10 >= 7)
        {
            sign = "+";
        }

        else if (percent % 10 < 3)
        {
            sign = "-";
        }

        else
        {
            sign = "";
        }


        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percent >=70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else

        {
            Console.WriteLine("Sorry, you did not pass the class. Better luck next time!");
        }

    }


}
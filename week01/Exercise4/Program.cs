using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        
        List <int> numbers = new List <int>();
        int userNumber = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when done.");

        while (userNumber != 0)
        {
            Console.Write("Enter a number: ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
        
            if (userNumber != 0)
            {
               numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach(int number in numbers)
        {
           sum += number;
         }
         Console.WriteLine($"The sum is: {sum}.");
      

        double average = ((double)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach(int number in numbers)
        {
           if(number > max)
           {
              max = number;
           }

         }  
            Console.WriteLine($"The maximum number is: {max}.");

            int minPositive = int.MaxValue;
            foreach (int number in numbers)
      {
         if (number > 0 && number < minPositive)
         {
            minPositive = number;
         }

         if (minPositive != int.MaxValue)
         {
            Console.WriteLine($"The smallest positive number is: {minPositive}");
         }
      }
    }
        
}



  






using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int input = -1;

        List<int> numbers = [];

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);   
            }
        } while(input != 0);      

        int sum = numbers.Sum();
        double average = numbers.Average();
        int largest = numbers.Max();
        int smallest = numbers.Where(n => n > 0).Min();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");
        
        numbers.Sort();

        foreach(int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
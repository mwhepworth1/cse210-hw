using System;

class Program
{
    static void Main(string[] args)
    {
        List<double> x = new();

        double input = 1;
        while (input != 0)
        {
            Console.WriteLine("Enter something:");
            input = double.Parse(Console.ReadLine());
            x.Add(input);
        }

        double sum = 0;
        double max = 0;
        foreach (double number in x)
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
        }

        double average = sum / x.Count;
        
        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + max);

    }
}
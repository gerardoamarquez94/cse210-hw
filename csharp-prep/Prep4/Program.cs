using System;
using System.Collections.Generic;

class NumberProcessing
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
                break;
            numbers.Add(number);
        }

        int sum = 0, max = Int32.MinValue, smallestPositive = Int32.MaxValue;
        foreach (int num in numbers)
        {
            sum += num;
            if (num > max)
                max = num;
            if (num > 0 && num < smallestPositive)
                smallestPositive = num;
        }

        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        
        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}

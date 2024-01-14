using System;

class GradeCalculator
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        
        string letter = "";
        string sign = "";

        // Determine letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine sign for grades other than F
        if (letter != "F")
        {
            if (grade % 10 >= 7)
            {
                sign = "+";
            }
            else if (grade % 10 < 3)
            {
                sign = "-";
            }
        }

        // Ensure no A+ or F+/- grades
        if (letter == "A" && sign == "+") sign = "";
        if (letter == "F") sign = "";

        // Print out the grade and pass/fail message
        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying, you can improve next time.");
        }
    }
}

using System;
using System.Threading;

public abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void SetupActivity()
    {
        Console.WriteLine(Name + ": " + Description);
        Console.Write("Enter duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Prepare to begin...");
        PerformCountdown(3);
    }

    public abstract void Run();

    protected void PerformCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i + "...");
            Thread.Sleep(1000);
        }
    }

    protected void FinishActivity()
    {
        Console.WriteLine("Well done! You've completed the " + Name + " for " + Duration + " seconds.");
        PerformCountdown(3);
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through deep breathing exercises.")
    {
    }

    public override void Run()
    {
        SetupActivity();
        for (int i = 0; i < Duration / 5; i++)
        {
            Console.WriteLine("Breathe in...");
            PerformCountdown(2);
            Console.WriteLine("Breathe out...");
            PerformCountdown(3);
        }
        FinishActivity();
    }
}

public class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection Activity", "This activity guides you through a reflection on personal achievements or experiences.")
    {
    }

    public override void Run()
    {
        SetupActivity();
        Console.WriteLine("Think about a time when you felt proud of an achievement.");
        PerformCountdown(Duration);
        FinishActivity();
    }
}

public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing Activity", "This activity helps you list positive aspects or accomplishments in your life.")
    {
    }

    public override void Run()
    {
        SetupActivity();
        Console.WriteLine("List things you are grateful for:");
        PerformCountdown(Duration);
        FinishActivity();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Select an activity:\n1. Breathing\n2. Reflection\n3. Listing\n4. Exit");
            var choice = Console.ReadLine();
            Activity activity = null;

            if (choice == "1")
            {
                activity = new BreathingActivity();
            }
            else if (choice == "2")
            {
                activity = new ReflectionActivity();
            }
            else if (choice == "3")
            {
                activity = new ListingActivity();
            }
            else if (choice == "4")
            {
                break; // Exit the loop and program
            }

            if (activity != null)
            {
                activity.Run();
            }
        }
    }
}

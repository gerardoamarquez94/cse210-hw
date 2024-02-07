using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; protected set; }

    protected Goal(string description, int points)
    {
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordProgress();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string description, int points) : base(description, points) { }

    public override void RecordProgress()
    {
        IsCompleted = true;
        Console.WriteLine("Completed: " + Description + ". Gained " + Points + " points!");
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string description, int points) : base(description, points) { }

    public override void RecordProgress()
    {
        Console.WriteLine("Recorded: " + Description + ". Gained " + Points + " points!");
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    private int BonusPoints;

    public ChecklistGoal(string description, int points, int targetCount, int bonusPoints) : base(description, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordProgress()
    {
        CurrentCount++;
        if (CurrentCount >= TargetCount)
        {
            IsCompleted = true;
            Console.WriteLine("Completed " + Description + " " + CurrentCount + "/" + TargetCount + " times. Gained " + Points + " points, with a bonus of " + BonusPoints + " points!");
        }
        else
        {
            Console.WriteLine("Progress: " + Description + " " + CurrentCount + "/" + TargetCount + ". Gained " + Points + " points.");
        }
    }
}

public class QuestProgram
{
    private List<Goal> Goals = new List<Goal>();
    private int TotalScore = 0;

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Goal Progress");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordProgress();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        // Simplified for example purposes; actual implementation would prompt user for details
    }

    private void RecordProgress()
    {
        // Simplified for example purposes; actual implementation would update goal progress and TotalScore
    }

    private void ShowGoals()
    {
        // Simplified for example purposes; actual implementation would iterate over Goals and display them
    }

    private void ShowScore()
    {
        Console.WriteLine("Total Score: " + TotalScore);
    }

    public static void Main(string[] args)
    {
        QuestProgram program = new QuestProgram();
        program.Run();
    }
}

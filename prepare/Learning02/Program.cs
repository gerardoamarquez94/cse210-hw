using System;
using System.Collections.Generic;

public class Job
{
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    public override string ToString()
    {
        return $"{JobTitle} ({Company}) {StartYear}-{EndYear}";
    }
}

public class Resume
{
    public string Name { get; set; }
    public List<Job> Jobs { get; set; }

    public Resume()
    {
        Jobs = new List<Job>();
    }

    public void DisplayResume()
    {
        Console.WriteLine(Name);
        foreach (var job in Jobs)
        {
            Console.WriteLine(job.ToString());
        }
    }
}

public class Program
{
    public static void Main()
    {
        var job1 = new Job { Company = "Microsoft", JobTitle = "Software Engineer", StartYear = 2019, EndYear = 2022 };
        var job2 = new Job { Company = "Google", JobTitle = "Senior Software Engineer", StartYear = 2022, EndYear = 2024 };

        var resume = new Resume { Name = "John Doe" };
        resume.Jobs.Add(job1);
        resume.Jobs.Add(job2);

        resume.DisplayResume();
    }
}

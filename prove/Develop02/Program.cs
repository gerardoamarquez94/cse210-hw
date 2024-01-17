using System;
using System.Collections.Generic;
using System.IO;

public class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        // Use concatenation instead of string interpolation
        return "Date: " + Date + "\nPrompt: " + Prompt + "\nResponse: " + Response + "\n";
    }
}

public class Journal
{
    private List<JournalEntry> entries;
    private string[] prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
        // Add additional prompts as needed
    };

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry()
    {
        var random = new Random();
        int promptIndex = random.Next(prompts.Length);
        Console.WriteLine(prompts[promptIndex]);
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();
        entries.Add(new JournalEntry(date, prompts[promptIndex], response));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                // Use concatenation instead of string interpolation
                sw.WriteLine(entry.Date + "|" + entry.Prompt + "|" + entry.Response);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
                }
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

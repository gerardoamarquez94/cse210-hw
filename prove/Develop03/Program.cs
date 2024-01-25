using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Scripture scripture = new Scripture(new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, " +
            "that whoever believes in him shall not perish but have eternal life.");

        while (!scripture.IsFullyHidden())
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                // IOException caught when the console cannot be cleared.
            }

            Console.WriteLine(scripture);
            Console.WriteLine("\nPress enter to continue or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideRandomWord();
        }
    }
}

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWord()
    {
        var random = new Random();
        int index = random.Next(_words.Count);
        _words[index].Hide();
    }

    public bool IsFullyHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    public override string ToString()
    {
        return _reference.ToString() + " - " + string.Join(" ", _words.Select(w => w.ToString()));
    }
}

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
    }

    public override string ToString()
    {
        return _isHidden ? "___" : _text;
    }
}

public class Reference
{
    private string _book;
    private int _chapter;
    private int? _startVerse;
    private int? _endVerse; // Nullable for range

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        return _book + " " + _chapter.ToString() + ":" + _startVerse.ToString() + (_endVerse.HasValue ? "-" + _endVerse.Value.ToString() : "");
    }
}

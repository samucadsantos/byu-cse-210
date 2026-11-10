public class Entry
{
    public const string Separator = "~|~";

    private string _date;
    private string _mood;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string mood, string promptText, string entryText)
    {
        _date = date;
        _mood = mood;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }

    public string ToFileLine()
    {
        return string.Join(Separator, _date, _mood, _promptText, _entryText);
    }

    // Returns null when the line is not a valid entry.
    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split(Separator);
        if (parts.Length != 4)
        {
            return null;
        }
        return new Entry(parts[0], parts[1], parts[2], parts[3]);
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private bool _hasUnsavedChanges = false;

    public bool HasUnsavedChanges()
    {
        return _hasUnsavedChanges;
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
        _hasUnsavedChanges = true;
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileLine());
            }
        }
        _hasUnsavedChanges = false;
        Console.WriteLine($"Saved {_entries.Count} entries to {file}.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileLine(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        _hasUnsavedChanges = false;
        Console.WriteLine($"Loaded {_entries.Count} entries from {file}.");
    }
}

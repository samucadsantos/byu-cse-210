// Exceeding requirements:
// 1. Each entry also stores the user's mood (saved and loaded with the file).
// 2. The program warns before loading a file or quitting when there are
//    unsaved entries, so the user does not lose their writing by accident.
// 3. Loading checks that the file exists, and displaying an empty journal
//    shows a friendly message instead of nothing.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string entryText = Console.ReadLine();
                Console.Write("How are you feeling today? ");
                string mood = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                journal.AddEntry(new Entry(date, mood, prompt, entryText));
            }
            else if (choice == "2")
            {
                journal.DisplayEntries();
            }
            else if (choice == "3")
            {
                if (ConfirmDiscard(journal))
                {
                    Console.Write("What is the filename? ");
                    journal.LoadFromFile(Console.ReadLine());
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                journal.SaveToFile(Console.ReadLine());
            }
            else if (choice == "5")
            {
                if (ConfirmDiscard(journal))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }

    // Asks the user to confirm when there are unsaved entries.
    static bool ConfirmDiscard(Journal journal)
    {
        if (!journal.HasUnsavedChanges())
        {
            return true;
        }
        Console.Write("You have unsaved entries. Continue anyway? (y/n) ");
        return Console.ReadLine().Trim().ToLower() == "y";
    }
}

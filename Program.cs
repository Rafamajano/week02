// EXTRA FEATURE:
// I added a mood tracker to each journal entry. When writing an entry,
// the program asks the user to enter their mood on a scale from 1 to 10.
// This data is saved along with the entry and displayed when viewing entries.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string input = Console.ReadLine();
            int.TryParse(input, out choice);

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("How would you rate your mood today (1-10)? ");
                    int mood = int.Parse(Console.ReadLine());

                    Entry entry = new Entry
                    {
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        Prompt = prompt,
                        Response = response,
                        Mood = mood
                    };
                    journal.AddEntry(entry);
                    break;

                case 2:
                    Console.WriteLine("\nYour Journal Entries:");
                    journal.DisplayJournal();
                    break;

                case 3:
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case 4:
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.");
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
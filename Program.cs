using System;
using System.Text.Json;
using System.IO;

string filePath = "habits.json";

List<Habit> habits = new List<Habit>();
int nextId = 1;

LoadHabits();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Habits Tracker ===");
    Console.WriteLine("1. Add a new habit");
    Console.WriteLine("2. View habits");
    Console.WriteLine("3. Complete a habit");
    Console.WriteLine("4. Delete a habit");
    Console.WriteLine("5. Modify a habit");
    Console.WriteLine("6. Exit");
    Console.Write("Select an option: ");

    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddHabit();
            break;
        case "2":
            ViewHabits();
            break;
        case "3":
            CompleteHabit();
            break;
        case "4":
            DeleteHabit();
            break;
        case "5":
            ModifyHabit();
            break;
        case "6":
            SaveHabits();
            return;
        default:
            Console.WriteLine("Invalid option. Press any key to try again.");
            Console.ReadKey();
            break;
    }
}

void AddHabit()
{
    Console.Write("Enter habit name: ");
    string? name = Console.ReadLine();

    Console.Write("Enter habit description: ");
    string? description = Console.ReadLine();

    Console.Write("Enter frequency (times per week): ");
    int frequency = int.Parse(Console.ReadLine() ?? "0");

    DateTime startDate = DateTime.Now;

    Habit newHabit = new Habit(nextId++, name ?? "", description ?? "", frequency, startDate);
    habits.Add(newHabit);

    Console.WriteLine("Habit added successfully! Press any key to continue.");
    Console.ReadKey();
}

void ViewHabits()
{
    ListHabits();
    Console.WriteLine("Press any key to return to the main menu.");
    Console.ReadKey();
}

void CompleteHabit()
{
    ListHabits();
    Console.Write("Enter the number of the habit to mark as completed: ");
    int index = int.Parse(Console.ReadLine() ?? "0") - 1;

    if (index >= 0 && index < habits.Count)
    {
        habits[index].MarkAsCompleted();
        Console.WriteLine("Habit marked as completed! Press any key to continue.");
    }
    else
    {
        Console.WriteLine("Invalid habit number. Press any key to try again.");
    }
    Console.ReadKey();
}

void DeleteHabit()
{
    Console.Write("Enter the number of the habit to delete: ");
    int index = int.Parse(Console.ReadLine() ?? "0") - 1;

    if (index >= 0 && index < habits.Count)
    {
        habits.RemoveAt(index);
        Console.WriteLine("Habit deleted successfully! Press any key to continue.");
    }
    else
    {
        Console.WriteLine("Invalid habit number. Press any key to try again.");
    }
    Console.ReadKey();
}

void ListHabits()
{
    if (habits.Count == 0)
    {
        Console.WriteLine("No habits found.");
    }
    else
    {
        for (int i = 0; i < habits.Count; i++)
        {
            Habit habit = habits[i];
            Console.WriteLine($"{i + 1}. {habit.Name} - {habit.Description} - Frequency: {habit.Frequency} times/week - Completed: {habit.IsCompleted}");
        }
    }
}

void ModifyHabit()
{
    ListHabits();
    Console.Write("Enter the number of the habit to modify: ");
    int index = int.Parse(Console.ReadLine() ?? "0") - 1;

    if (index >= 0 && index < habits.Count)
    {
        Habit habit = habits[index];

        Console.Write($"Enter new name (current: {habit.Name}): ");
        string? newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            habit.Name = newName;
        }

        Console.Write($"Enter new description (current: {habit.Description}): ");
        string? newDescription = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newDescription))
        {
            habit.Description = newDescription;
        }

        Console.Write($"Enter new frequency (current: {habit.Frequency}): ");
        string? frequencyInput = Console.ReadLine();
        if (int.TryParse(frequencyInput, out int newFrequency))
        {
            habit.Frequency = newFrequency;
        }

        Console.WriteLine("Habit modified successfully! Press any key to continue.");
    }
    else
    {
        Console.WriteLine("Invalid habit number. Press any key to try again.");
    }
    Console.ReadKey();
}

void SaveHabits()
{
    // Implement saving habits to a file or database if needed
    string json = System.Text.Json.JsonSerializer.Serialize(habits);
    File.WriteAllText("habits.json", json);
    Console.WriteLine("Exiting the application. Goodbye!");

}

void LoadHabits()
{
    // Implement loading habits from a file or database if needed
    if (File.Exists("habits.json"))
    {
        string json = File.ReadAllText("habits.json");
        var loadedHabits = System.Text.Json.JsonSerializer.Deserialize<List<Habit>>(json);
        if (loadedHabits != null)
        {
            habits.AddRange(loadedHabits);
        }
    }

    nextId = habits.Count > 0
    ? habits.Max(h => h.Id) + 1
    : 1;
}
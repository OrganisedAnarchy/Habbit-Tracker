public class Habit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Frequency { get; set; } // e.g., number of times per week
    public DateTime StartDate { get; set; }
    public DateTime? Deadline { get; set; }
    public bool IsCompleted { get; set; }

    public Habit(int id, string name, string description, int frequency, DateTime startDate)
    {
        this.Id = id;
        Deadline = null;
        Name = name;
        Description = description;
        Frequency = frequency;
        StartDate = startDate;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}
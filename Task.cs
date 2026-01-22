namespace M3;

public class Task
{
    public string Id { get; set; }
    public DateTime DueDate { get; set; }
    public string Description { get; set; }

    public Task(string id, DateTime dueDate, string description)
    {
        Id = id;
        DueDate = dueDate;
        Description = description;
    }
}

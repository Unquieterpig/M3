namespace M3;

public class Blacksmith : Employee, ITaskPerformer
{
    private Person? _taskDelegate;
    private List<Task> _tasksToPerform = new List<Task>();

    public Blacksmith(string name, int age, string title) 
        : base(name, age, title)
    {
    }

    protected override decimal GetStartupStipend()
    {
        return 35000m;
    }

    public void PerformTask(Task task)
    {
        if (!IsAvailable && _taskDelegate != null)
        {
            if (_taskDelegate is ITaskPerformer performer)
            {
                performer.PerformTask(task);
                return;
            }
        }

        perform(task);
    }

    private void perform(Task task)
    {
        Console.WriteLine($"{Name} (Blacksmith) performs task {task.Id}: {task.Description}");
    }

    public void AddTask(Task task)
    {
        _tasksToPerform.Add(task);
    }

    public void PerformAllTasks()
    {
        foreach (var task in _tasksToPerform)
        {
            PerformTask(task);
        }
        _tasksToPerform.Clear();
    }

    public void SetTaskDelegate(Person? delegatePerson)
    {
        if (delegatePerson is Employee)
        {
            _taskDelegate = delegatePerson;
        }
        else
        {
            throw new ArgumentException("Task delegation can only be to an Employee.");
        }
    }
}

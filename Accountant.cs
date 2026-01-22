namespace M3;

public class Accountant : Employee, ISalaryUpdater, IMessageSender, ITaskPerformer
{
    private Person? _salaryUpdateDelegate;
    private Person? _additionalDutyDelegate;

    public Accountant(string name, int age, string title) 
        : base(name, age, title)
    {
    }

    protected override decimal GetStartupStipend()
    {
        return 45000m;
    }

    public void UpdateSalary(Employee employee, decimal amount)
    {
        if (!IsAvailable && _salaryUpdateDelegate != null)
        {
            if (_salaryUpdateDelegate is ISalaryUpdater updater)
            {
                updater.UpdateSalary(employee, amount);
                return;
            }
        }

        employee.UpdateSalaryInternal(amount);
        Console.WriteLine($"{Name} (Accountant) updates {employee.Name}'s salary by ${amount:F2}. New salary: ${employee.Salary:F2}");
    }

    public void SetSalaryUpdateDelegate(Person? delegatePerson)
    {
        if (delegatePerson is Accountant)
        {
            _salaryUpdateDelegate = delegatePerson;
        }
        else
        {
            throw new ArgumentException("Salary update delegation can only be to another Accountant.");
        }
    }

    // Additional duty: Message sending (delegated from Owner)
    public void SendMessage(string message, List<Employee> employees)
    {
        Console.WriteLine($"{Name} (Accountant) sends message on behalf: \"{message}\"");
        foreach (var employee in employees)
        {
            Console.WriteLine($"  -> To: {employee.Name} ({employee.Title})");
        }
    }

    // Additional duty: Task performance (helping another employee)
    public void PerformTask(Task task)
    {
        Console.WriteLine($"{Name} (Accountant) performs task {task.Id}: {task.Description}");
    }

    public void SetAdditionalDutyDelegate(Person? delegatePerson)
    {
        if (delegatePerson is Employee)
        {
            _additionalDutyDelegate = delegatePerson;
        }
        else
        {
            throw new ArgumentException("Additional duty delegation can only be to an Employee.");
        }
    }
}

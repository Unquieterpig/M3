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

    private void update(Employee employee, decimal amount)
    {
        employee.UpdateSalaryInternal(amount);
        Console.WriteLine($"{Name} (Accountant) updates {employee.Name}'s salary by ${amount:F2}. New salary: ${employee.Salary:F2}");
    }

    public void UpdateSalary(Employee employee, decimal amount)
    {
        if (TryDelegateTo<ISalaryUpdater>(_salaryUpdateDelegate, u => u.UpdateSalary(employee, amount)))
            return;
        update(employee, amount);
    }

    public void SetSalaryUpdateDelegate(Person? delegatePerson)
    {
        ValidateDelegate(delegatePerson, p => p is Accountant, "Salary update delegation can only be to another Accountant.");
        _salaryUpdateDelegate = delegatePerson;
    }

    public void SendMessage(string message, List<Employee> employees)
    {
        Console.WriteLine($"{Name} (Accountant) sends message on behalf: \"{message}\"");
        foreach (var employee in employees)
        {
            Console.WriteLine($"  -> To: {employee.Name} ({employee.Title})");
        }
    }

    public void PerformTask(Task task)
    {
        Console.WriteLine($"{Name} (Accountant) performs task {task.Id}: {task.Description}");
    }

    public void SetAdditionalDutyDelegate(Person? delegatePerson)
    {
        ValidateDelegate(delegatePerson, p => p is Employee, "Additional duty delegation can only be to an Employee.");
        _additionalDutyDelegate = delegatePerson;
    }
}

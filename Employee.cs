namespace M3;

public abstract class Employee : Person
{
    public decimal Salary { get; protected set; }

    protected Employee(string name, int age, string title) 
        : base(name, age, title)
    {
        Salary = GetStartupStipend();
    }

    protected abstract decimal GetStartupStipend();
    
    public void ViewSalary()
    {
        Console.WriteLine($"{Name}'s current salary: ${Salary:F2}");
    }

    internal void UpdateSalaryInternal(decimal amount)
    {
        Salary += amount;
    }
}

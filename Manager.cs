namespace M3;

public class Manager : Employee, IPerformanceEvaluator
{
    private Person? _evaluationDelegate;

    public Manager(string name, int age, string title) 
        : base(name, age, title)
    {
    }

    protected override decimal GetStartupStipend()
    {
        return 50000m;
    }

    public void Evaluate(Employee employee, int score)
    {
        if (score < 1 || score > 5)
            throw new ArgumentException("Evaluation score must be between 1 and 5.");

        if (TryDelegateTo<IPerformanceEvaluator>(_evaluationDelegate, e => e.Evaluate(employee, score)))
            return;

        if (employee is Accountant || employee is Blacksmith)
            evaluate(employee, score);
        else
            throw new ArgumentException("Managers can only evaluate Accountants or Blacksmiths.");
    }

    private void evaluate(Employee employee, int score)
    {
        Console.WriteLine($"{Name} (Manager) evaluates {employee.Name} ({employee.Title}) with a score of {score}");
    }

    public void SetEvaluationDelegate(Person? delegatePerson)
    {
        ValidateDelegate(delegatePerson, p => p is Owner || p is Manager, "Evaluation delegation can only be to Owner or another Manager.");
        _evaluationDelegate = delegatePerson;
    }
}

namespace M3;

public class Owner : Person, IMessageSender, IPerformanceEvaluator
{
    private Person? _messageDelegate;
    private Person? _evaluationDelegate;

    public Owner(string name, int age, string title) 
        : base(name, age, title)
    {
    }

    private void send(string message, List<Employee> employees)
    {
        Console.WriteLine($"{Name} (Owner) sends message: \"{message}\"");
        foreach (var employee in employees)
        {
            Console.WriteLine($"  -> To: {employee.Name} ({employee.Title})");
        }
    }

    public void SetMessageDelegate(Person? delegatePerson)
    {
        ValidateDelegate(delegatePerson, p => p is Manager || p is Accountant, "Message delegation can only be to a Manager or Accountant.");
        _messageDelegate = delegatePerson;
    }

    public void SendMessage(string message, List<Employee> employees)
    {
        if (TryDelegateTo<IMessageSender>(_messageDelegate, s => s.SendMessage(message, employees)))
            return;
        send(message, employees);
    }

    public void Evaluate(Employee employee, int score)
    {
        if (score < 1 || score > 5)
            throw new ArgumentException("Evaluation score must be between 1 and 5.");

        if (TryDelegateTo<IPerformanceEvaluator>(_evaluationDelegate, e => e.Evaluate(employee, score)))
            return;
        evaluate(employee, score);
    }

    private void evaluate(Employee employee, int score)
    {
        Console.WriteLine($"{Name} (Owner) evaluates {employee.Name} ({employee.Title}) with a score of {score}");
    }

    public void SetEvaluationDelegate(Person? delegatePerson)
    {
        ValidateDelegate(delegatePerson, p => p is Manager, "Evaluation delegation can only be to a Manager.");
        _evaluationDelegate = delegatePerson;
    }
}

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
        if (delegatePerson is Manager || delegatePerson is Accountant)
        {
            _messageDelegate = delegatePerson;
        }
        else
        {
            throw new ArgumentException("Message delegation can only be to a Manager or Accountant.");
        }
    }

    public void SendMessage(string message, List<Employee> employees)
    {
        if (!IsAvailable && _messageDelegate != null)
        {
            if (_messageDelegate is IMessageSender sender)
            {
                sender.SendMessage(message, employees);
                return;
            }
        }
        
        send(message, employees);
    }

    public void Evaluate(Employee employee, int score)
    {
        if (score < 1 || score > 5)
        {
            throw new ArgumentException("Evaluation score must be between 1 and 5.");
        }

        if (!IsAvailable && _evaluationDelegate != null)
        {
            if (_evaluationDelegate is IPerformanceEvaluator evaluator)
            {
                evaluator.Evaluate(employee, score);
                return;
            }
        }
        
        evaluate(employee, score);
    }

    private void evaluate(Employee employee, int score)
    {
        Console.WriteLine($"{Name} (Owner) evaluates {employee.Name} ({employee.Title}) with a score of {score}");
    }

    public void SetEvaluationDelegate(Person? delegatePerson)
    {
        if (delegatePerson is Manager)
        {
            _evaluationDelegate = delegatePerson;
        }
        else
        {
            throw new ArgumentException("Evaluation delegation can only be to a Manager.");
        }
    }
}

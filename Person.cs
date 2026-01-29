namespace M3;

public abstract class Person
{
    private string _name;
    private int _age;
    private string _title;

    public string Name => _name;
    public int Age => _age;
    public string Title => _title;
    
    public virtual bool IsAvailable { get; set; } = true;
    
    protected Person? Delegate { get; set; }

    protected Person(string name, int age, string title)
    {
        _name = name;
        _age = age;
        _title = title;
    }

    public void SetDelegate(Person? delegatePerson)
    {
        Delegate = delegatePerson;
    }

    protected bool TryDelegateTo<T>(Person? delegatePerson, Action<T> action) where T : class
    {
        if (IsAvailable || delegatePerson == null || delegatePerson is not T impl)
            return false;
        action(impl);
        return true;
    }

    protected static void ValidateDelegate(Person? delegatePerson, Func<Person, bool> isAllowed, string errorMessage)
    {
        if (delegatePerson != null && !isAllowed(delegatePerson))
            throw new ArgumentException(errorMessage);
    }
}

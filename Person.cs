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
}

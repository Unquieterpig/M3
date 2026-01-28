namespace M3;

public abstract class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Title { get; private set; }
    
    public virtual bool IsAvailable { get; set; } = true;
    
    protected Person? Delegate { get; set; }

    protected Person(string name, int age, string title)
    {
        Name = name;
        Age = age;
        Title = title;
    }

    public void SetDelegate(Person? delegatePerson)
    {
        Delegate = delegatePerson;
    }
}

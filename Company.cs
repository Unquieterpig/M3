namespace M3;

public class Company
{
    private readonly List<Person> _people = new List<Person>();

    public IReadOnlyCollection<Person> People => _people.AsReadOnly();

    public void AddPerson(Person person)
    {
        _people.Add(person);
    }
}


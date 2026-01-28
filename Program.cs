using M3;

namespace M3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== XYZ Company Employee Management System ===\n");

        // Create company container
        Company xyz = new Company();

        // Create all people
        Owner craig = new Owner("Craig", 50, "Owner");
        
        Manager john = new Manager("John", 35, "Manager");
        Manager mary = new Manager("Mary", 32, "Manager");
        
        Accountant jane = new Accountant("Jane", 28, "Accountant");
        Accountant joe = new Accountant("Joe", 30, "Accountant");
        
        Blacksmith jack = new Blacksmith("Jack", 25, "Blacksmith");
        Blacksmith katie = new Blacksmith("Katie", 27, "Blacksmith");
        Blacksmith amy = new Blacksmith("Amy", 26, "Blacksmith");
        Blacksmith lin = new Blacksmith("Lin", 24, "Blacksmith");
        Blacksmith greg = new Blacksmith("Greg", 29, "Blacksmith");

        xyz.AddPerson(craig);
        xyz.AddPerson(john);
        xyz.AddPerson(mary);
        xyz.AddPerson(jane);
        xyz.AddPerson(joe);
        xyz.AddPerson(jack);
        xyz.AddPerson(katie);
        xyz.AddPerson(amy);
        xyz.AddPerson(lin);
        xyz.AddPerson(greg);

        Console.WriteLine("=== Test Scenario 1: Craig sends message to John, Jane, and Jack ===");
        List<Employee> recipients1 = new List<Employee> { john, jane, jack };
        craig.SendMessage("Good Job", recipients1);
        Console.WriteLine();

        Console.WriteLine("=== Test Scenario 2: Greg performs t1 and helps Amy with t2 ===");
        Task t1 = new Task("t1", DateTime.Now.AddDays(5), "Greg's own task");
        Task t2 = new Task("t2", DateTime.Now.AddDays(3), "Amy's task");
        
        // Greg performs both tasks
        greg.AddTask(t1);
        greg.AddTask(t2);
        greg.PerformAllTasks();
        Console.WriteLine();

        Console.WriteLine("=== Test Scenario 3: Jane increases Greg's salary and helps Lin with t3 ===");
        // Jane increases Greg's salary by $1,000
        jane.UpdateSalary(greg, 1000m);
        
        // Jane helps Lin with task t3
        Task t3 = new Task("t3", DateTime.Now.AddDays(7), "Lin's task");
        jane.PerformTask(t3);
        Console.WriteLine();

        Console.WriteLine("=== Test Scenario 4: Normal evaluations ===");
        // John evaluates Jack with score 4
        john.Evaluate(jack, 4);
        
        // Mary evaluates Katie with score 5
        mary.Evaluate(katie, 5);
        Console.WriteLine();

        Console.WriteLine("=== Test Scenario 5: John delegates evaluation to Craig ===");
        // John goes out of town
        john.IsAvailable = false;
        
        // John sets Craig as delegate
        john.SetEvaluationDelegate(craig);
        
        // When John evaluates Jack, it should be delegated to Craig
        john.Evaluate(jack, 4);
        Console.WriteLine();

        Console.WriteLine("=== Final Salary Information ===");
        greg.ViewSalary();
        jack.ViewSalary();
        katie.ViewSalary();
    }
}

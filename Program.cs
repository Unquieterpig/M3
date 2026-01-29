using M3;

namespace M3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== XYZ Company Employee Management System ===\n");

        // Company container
        Company xyz = new Company();

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

        Console.WriteLine("=== Send Message ===");
        List<Employee> recipients1 = new List<Employee> { john, jane, jack };
        craig.SendMessage("Good Job", recipients1);
        Console.WriteLine();

        Console.WriteLine("=== Greg performs t1 and helps Amy with t2 ===");
        Task t1 = new Task("t1", DateTime.Now.AddDays(5), "Greg's own task");
        Task t2 = new Task("t2", DateTime.Now.AddDays(3), "Amy's task");
        
        greg.AddTask(t1);
        greg.AddTask(t2);
        greg.PerformAllTasks();
        Console.WriteLine();

        Console.WriteLine("=== Jane increases Greg's salary and helps Lin with t3 ===");
        jane.UpdateSalary(greg, 1000m);
        
        Task t3 = new Task("t3", DateTime.Now.AddDays(7), "Lin's task");
        jane.PerformTask(t3);
        Console.WriteLine();

        Console.WriteLine("=== Normal evaluations ===");
        john.Evaluate(jack, 4);
    
        mary.Evaluate(katie, 5);
        Console.WriteLine();

        Console.WriteLine("=== John delegates evaluation to Craig ===");
        john.IsAvailable = false;
        
        john.SetEvaluationDelegate(craig);
        
        john.Evaluate(jack, 4);
        Console.WriteLine();

        Console.WriteLine("=== Final Salary Information ===");
        greg.ViewSalary();
        jack.ViewSalary();
        katie.ViewSalary();
    }
}

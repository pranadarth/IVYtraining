 class Employee
{
    public delegate void trigger(string name);
    public List<string> list = new List<string>();

    Employee()
    {
        
        Console.WriteLine("Enter the top shortlisted Empl");
        for(int i = 0; i < 5; i++)
            list.Add(Console.ReadLine());
    }
    public void promotion(string name)
    {
        if (list.Contains(name))
            Console.WriteLine("Promotion is given to " + name);
        else
            Console.WriteLine("not in the list");
    }

    static void Main(string[] args)
    {
        Employee emp = new Employee();
        Console.WriteLine("Enter name to give Promotion : ");
        string name = Console.ReadLine();
        trigger t = new trigger(emp.promotion);
        t.Invoke(name);
    }
}

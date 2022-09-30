using System;
using System.Collections;

public class Person
{
    public string Name;
    public int Age;


    public  string ToString()
    {
        return Name + " - " + Age;
    }
}
public class Queues
{
    public static void Main(string[] args)
    {
        Queue q = new Queue();
        Console.Write("No. of data: ");
        int total = int.Parse(Console.ReadLine());

        for (int i = 0; i < total; i++)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            q.Enqueue(new Person()
            {
                Name = name,
                Age = age
            });
        }

        for (int i = 0; i < total; i++)
        {
            Person p = (Person)q.Dequeue();
            Console.WriteLine(p.ToString());
        }
    }

    
}

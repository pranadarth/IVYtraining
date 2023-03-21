using System;

public abstract class Bird
{
    private string Name;

    public void SetName(string name)
    {
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }

    public abstract void fly();
    public abstract void eat();
}
public class parrot : Bird
{
    public override void fly()
    {
        Console.WriteLine("{0} is flying", GetName());
    }
    public override void eat()
    {
        Console.WriteLine("{0} is Eating", GetName());
    }
}
public class AbstractClass
{
    public static void Main(string[] args)
    {
        parrot p = new parrot();
        Console.Write("Enter the name of the parrot: ");
        p.SetName(Console.ReadLine());
        Console.WriteLine(p.GetName());
        p.fly();
        p.eat();
    }

    
}
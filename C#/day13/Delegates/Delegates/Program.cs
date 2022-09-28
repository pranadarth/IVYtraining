using System;

public delegate void cal(int x);
class MyClass
{
    public void fibanocci(int n)
    {
        int n1 = 0, n2 = 1, n3;
        Console.Write("Enter the number of elements: ");
        Console.Write(n1 + " " + n2 + " "); //printing 0 and 1    
        for (int i = 2; i < n; ++i)
        {
            n3 = n1 + n2;
            Console.Write(n3 + " ");
            n1 = n2;
            n2 = n3;
        }
    }
    public void factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;
        }
        Console.Write("Factorial of " + n + " is: " + fact);
    }
    public void factor(int n)
    {
        Console.WriteLine("The Factors are : ");
        for (int x = 1; x <= n; x++)
        {
            if (n % x == 0)
            {
                Console.WriteLine(x);
            }
        }
    }
    public void table(int n)
    {
        Console.WriteLine("Table of the given number: " + (n));
        for (int x = 1; x <= 10; x++)
            Console.WriteLine("{0} X {1} = {2}", x, n, x * n);
    }
}

class MyClient
{
    public static void Main()
    {
        MyClass mc = new MyClass();
        cal c = new cal(mc.factorial);
        Console.Write("Give the number to find factorial: ");
        int i = int.Parse(Console.ReadLine());
        c.Invoke(i);
        string s = Console.ReadLine();
        Console.Clear();

        c = mc.fibanocci;
        Console.Write("\nGive the number to find fibanocci: ");
        i = int.Parse(Console.ReadLine());
        c.Invoke(i);
        s = Console.ReadLine();
        Console.Clear();

        c = mc.factor;
        Console.Write("\nGive the number to find factor: ");
        i = int.Parse(Console.ReadLine());
        c.Invoke(i);
        s = Console.ReadLine();
        Console.Clear();

        c = mc.table;
        Console.Write("\nGive the number to find its table: ");
        i = int.Parse(Console.ReadLine());
        c.Invoke(i);
        s = Console.ReadLine();
        Console.Clear();
    }
}
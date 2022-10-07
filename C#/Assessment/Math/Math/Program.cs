using System;
class Math
{
    public void table(int a)
    {
        for(int i = 1; i <= 10; i++)  
        Console.WriteLine("{0} X {1} = {2}",i,a,i*a);
        
    }
    public void factorial(int n)
    {
        long  fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact = fact * (long)i;
        }
        Console.WriteLine("Factorial of " + n + " is: " + fact);
    }
    public static void Main()
    {
        Math m = new Math();
        
        Console.Write("Give the number to find factorial: ");
        int i = int.Parse(Console.ReadLine());
        m.factorial(i);

        Console.Write("\nGive the number to display tables: ");
        i = int.Parse(Console.ReadLine());
        m.table(i);
        Console.ReadKey();
    }
}
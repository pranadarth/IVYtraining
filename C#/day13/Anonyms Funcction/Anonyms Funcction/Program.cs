using System;

public delegate void cal(float x, float y, float z);


class MyClient
{
    public static void Main()
    {
        cal c = delegate (float x, float y, float z)
        {
            float s = x * y * z / 100;
            Console.WriteLine("\nThe simple Interest: " + (s));
            Console.WriteLine("Total amount: " + (x + s));
        };
        Console.Write("principle: ");
        float p = float.Parse(Console.ReadLine());
        Console.Write("\nNo. of years: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("\nInterest: ");
        float r = float.Parse(Console.ReadLine());
        c.Invoke(p, n, r);
    }
}
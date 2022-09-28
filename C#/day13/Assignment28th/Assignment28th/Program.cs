using System;
using System.Security.Cryptography.X509Certificates;

public delegate int cal(int x);
public delegate int big(int x, int y);
public delegate void swap(int x, int y);
public delegate bool prime(int x);
public delegate void prime1(int x);
public delegate void array(int[] x);

class MyClient
{
    public static void Main()
    {
        cal c = (x) =>
        {
            int temp = 0;
            for (int i = 1; i <= x; i++)
                temp += i;
            return temp;
        }; Console.Write(" Enter the nth number: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Ans: " + c.Invoke(n));
        string s = Console.ReadLine();
        Console.Clear();

        big b = (x, y) => x > y ? x : y;
        Console.Write("Enter the value1: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter the value2: ");
        int a2 = int.Parse(Console.ReadLine());
        Console.WriteLine("largest value in the given is {0}", b.Invoke(a, a2));
        s = Console.ReadLine();
        Console.Clear();

        swap sw = (x, y) => Console.WriteLine(" After swapping value1 = {0} and value2 = {1}", x = (x ^ y ^ (y = x)), y);
        sw.Invoke(a, a2);
        s = Console.ReadLine();
        Console.Clear();

        prime p = delegate (int x)
        {
            int c = 0;
            for (int i = 1; i < x; i++)
                if (x % i == 0)
                    c++;
            if (c == 1) return true;
            else return false;
        };
        Console.WriteLine("Enter the num to check prime or not: ");
        a = int.Parse(Console.ReadLine());
        Console.WriteLine("Ans: " + p.Invoke(a));
        s = Console.ReadLine();
        Console.Clear();

        prime1 p1 = (n) => { if (p.Invoke(n)) Console.Write(n + " "); };
        Console.WriteLine("Enter the num to find prime number till then: ");
        a = int.Parse(Console.ReadLine());
        Console.WriteLine(" prime numbers till {0}: ", a);
        for (int i = 1; i < a; i++)
            p1.Invoke(i);
        s = Console.ReadLine();
        Console.Clear();

        array ar = (x) => Array.Sort(x);
        Console.Write(" Enter the array size: ");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Values now: ");
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = int.Parse(Console.ReadLine());
        ar.Invoke(arr);
        Console.WriteLine("\nAfter sorting: ");
        foreach (int i in arr) Console.Write(i + " ");


    }
}
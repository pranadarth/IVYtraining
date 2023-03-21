using System;
using System.Collections.Generic;
class students
{
    public static void Main(string[] args)
    {
        Dictionary<int, int> data = new Dictionary<int, int>();
        Console.WriteLine("Enter the data:");
        do
        {
            Console.Write("Student ID: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("Total Mark: ");
            int m = int.Parse(Console.ReadLine());
            data.Add(i, m);
            Console.WriteLine("Press 1 to add another data!");

        }while(int.Parse(Console.ReadLine()) != 0);
        Console.WriteLine("\nEntered data till now: ");
        Console.WriteLine("IDs  Marks");
        foreach (KeyValuePair<int,int> i in data)
        Console.WriteLine((i.Key)+" " + (i.Value));
        Console.WriteLine("\nThe Highest mark is "+ data.Values.Max());
    }
}
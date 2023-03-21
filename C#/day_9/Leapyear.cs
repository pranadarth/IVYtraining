using System;
class Assignment2
{
    static void Main()
    {
        Console.Write("Enter the year: ");
        var d = Convert.ToInt32(Console.ReadLine());
        if ((d % 4 == 0 && d % 100 != 0) || d % 400 == 0)
        {
            Console.WriteLine("Its leap year");
        }
        else
            Console.WriteLine("Not leap year");
    }
}
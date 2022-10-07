using System;
class Assignment2
{
    static void Main()
    {
        Console.Write("Enter the distance(in km): ");
        var d = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the time: ");
        var t = Convert.ToInt32(Console.ReadLine());
        var s = d / t;
        Console.WriteLine("Speed: {0}km/hr", s);
        double di = (double)d / 1.609;
        var m = di / t;
        Console.WriteLine("Speed: {0} miles/hr", m);
    }
}
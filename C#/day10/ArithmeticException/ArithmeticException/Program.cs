using System;
class expection
{
    public void calc(int n)
    {
        try
        {
            Console.WriteLine("Root of the given num:" + Math.Sqrt(n));
            Console.WriteLine("Square of the given num:" + Math.Pow(n,2));
            Console.WriteLine("Division of the given num from 5 :" );
            for(int i = 5; i >= 0; i--)
                Console.WriteLine("by {0} is {1}", i, n/i);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("The following error has been occured: " + e.Message);
        }
    }
    public static void Main(string[] args)
    {
        expection f = new expection();
        f.calc(18);
    }

}

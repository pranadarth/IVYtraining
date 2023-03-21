using System;
class expection
{
    public void disp(string v)
    {
        try
        {
            int age = int.Parse(v);
            Console.WriteLine("The voting age in India is "+ age);
        }
        catch(FormatException e)
        {
            Console.WriteLine("The following error has been occured: "+e.Message);
        }
    }
    public static void Main(string[] args)
    {
        expection f = new expection();
        f.disp("18.0");
    }

}

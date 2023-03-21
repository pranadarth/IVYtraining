using System;
class ThreadEg
{
    public static void callThread()
    {
        for(int i = 0; i < 5; i++)
        {
            Thread.Sleep(2000);
            Console.WriteLine(i);
        }
    }
}
class practice
{

    public static void Main(string[] args)
    { 
        Thread first = new Thread(new ThreadStart(ThreadEg.callThread));
        Thread second = new Thread(new ThreadStart(ThreadEg.callThread));
        Thread third = new Thread(new ThreadStart(ThreadEg.callThread));
        first.Start();
        first.Join();
        second.Start();
        third.Start();
        
        
    }
}
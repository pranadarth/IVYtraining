internal class Program
{
    static async void decoration()
    {
        Console.WriteLine("Decorations are Started.");
        await Task.Delay(1000);
        Console.WriteLine("Decorations are Completed.");
    }

    static async void pickup()
    {
        Console.WriteLine("Cheif guest is picked up.");
        await Task.Delay(4000);
        Console.WriteLine("Cheif guest is arrived.");
    }

    static void caterers()
    {
        Console.WriteLine("Food area is setup is completed.");
    }
    static async void gifts()
    {
        await Task.Delay(3000);
        Console.WriteLine("Gifts are distributed.");
    }
    static async void start()
    {
        await Task.Delay(6000);
        Console.WriteLine("Function is started.");
    }
    static async Task Main(string[] args)
    {
        decoration();
        pickup();
        caterers();
        gifts();
        start();
        Console.ReadKey();

    }
}

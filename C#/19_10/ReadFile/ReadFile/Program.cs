namespace readFile
{
    internal class Program
    {
                static async void firstfile()
                {
                    StreamReader sr = new StreamReader("C:\\Users\\suresh.pranadarth\\folder1\\file1.txt");
                    Console.WriteLine(sr.ReadToEnd());
                    Console.WriteLine("First task over");
                }



                static async void secondfile()
                {
                    Thread.Sleep(3000);
                    StreamReader sr1 = new StreamReader("C:\\Users\\suresh.pranadarth\\folder1\\file2.txt");
                    Console.WriteLine(sr1.ReadToEnd());
                    Console.WriteLine("Second task over");
                }
                static async Task Main(string[] args)
                {
                    firstfile();
                    Console.WriteLine();
                    secondfile();
                }
           
        
    }
}

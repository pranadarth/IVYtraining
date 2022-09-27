namespace directoryexc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] s = Directory.GetFiles("c:\\Test");
                FileStream fs = new FileStream(s[0], FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (DirectoryNotFoundException e) { Console.WriteLine(e.Message); }
            catch (FileNotFoundException e) { Console.WriteLine(e.Message); }
        }
    }
}
}
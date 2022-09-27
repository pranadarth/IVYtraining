namespace directoryexc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = "c:\\Test";
                //Directory.CreateDirectory(path);
                string[] s = Directory.GetFiles(path);
                FileStream fs = new FileStream(s[0], FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (DirectoryNotFoundException e) { Console.WriteLine("Following error occured: "+e.Message); }
            try
            {
                string path = "c:\\Test";
                Directory.CreateDirectory(path);
                FileStream fs = new FileStream(path+"text.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (FileNotFoundException e) { Console.WriteLine("Following error occured: " + e.Message); }
        }
    }
}

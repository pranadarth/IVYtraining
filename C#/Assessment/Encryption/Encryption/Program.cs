namespace filecopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\suresh.pranadarth\\folder1";
            Directory.CreateDirectory(path);
            FileStream fs = new FileStream(path + "\\file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Type \"END\" to complete the entry");
            string data = "";
            while((data = Console.ReadLine()) != "END")
              sw.WriteLine(data);
            sw.Close();
            fs.Close();
            FileStream fs1 = new FileStream(path + "\\file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs1);
            StreamWriter sw2 = new StreamWriter(path + "\\file2.txt");   
            string s = "";
             while((s = sr.ReadLine()) != null)
            {

                foreach (char c in s.ToCharArray())
                {
                    int temp = (int)c + 1;
                    sw2.Write((char)temp);
                }
                sw2.Write("\n");

            }
            fs1.Close();
            sr.Close();
            sw2.Close();
        }
    }
}
namespace filecopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\suresh.pranadarth\\folderReplace";
            Directory.CreateDirectory(path);
            FileStream fs = new FileStream(path + "\\file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Type \"END\" to complete the entry");
            string data = "";
            while ((data = Console.ReadLine()) != "END")
                sw.WriteLine(data);
            sw.Close();
            fs.Close();
            Console.Write("Old word: ");
            string old = Console.ReadLine();
            Console.Write("New word: ");
            string New = Console.ReadLine();
            FileStream fs1 = new FileStream(path + "\\file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs1);
            StreamWriter sw2 = new StreamWriter(path + "\\file2.txt");
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] word = s.Split(' ');
                foreach (string c in word)
                {
                    if (c == old)
                        sw2.Write(New+" ");
                       
                    else
                        sw2.Write(c+" ");
                }
                sw2.Write("\n");

            }
            fs1.Close();
            sr.Close();
            sw2.Close();
            File.Delete(path + "\\file1.txt");
            File.Move(path + "\\file2.txt", path + "\\file1.txt");
        }
    }
}
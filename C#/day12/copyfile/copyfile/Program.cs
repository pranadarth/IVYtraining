namespace filecopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\suresh.pranadarth\\folder1";
            Directory.CreateDirectory(path);
            FileStream fs = new FileStream(path+"\\file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Hello Everyone, We will copy these contents to another File and move it to another directory.");
            sw.Close();
            FileStream fs1 = new FileStream(path + "\\file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fs2 = new FileStream(path + "\\file2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs1.CopyTo(fs2);
            fs1.Close();
            fs2.Close();
            //Directory.Move(path, "C:\\folder1");
            Directory.CreateDirectory("C:\\foldercopy");
            File.Move(path + "\\file2.txt", "C:\\foldercopy\\filecopy.txt");
        }
    }
}
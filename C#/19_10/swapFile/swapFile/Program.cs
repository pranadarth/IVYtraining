namespace filecopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\suresh.pranadarth\\folderFirst";
            Directory.CreateDirectory(path);
            FileStream fs = new FileStream(path + "\\file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Hello Everyone,\n This is File1 contents \nWe will swap this File to another other directory ");
            sw.Close();
            fs.Close();
            path = "C:\\Users\\suresh.pranadarth\\folderSecond";
            Directory.CreateDirectory(path);
            fs = new FileStream(path + "\\file2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);
            sw.WriteLine("Hello Everyone,\n This is File2 contents \nWe will swap this File to another directory ");
            File.Encrypt("C:\\Users\\suresh.pranadarth\\folderFirst\\file1.txt");
            sw.Close();
            fs.Close();
            File.Move("C:\\Users\\suresh.pranadarth\\folderFirst\\file1.txt", "C:\\Users\\suresh.pranadarth\\folderSecond\\file1.txt");
           /* File.Delete("C:\\Users\\suresh.pranadarth\\folderFirst\\file1.txt");*/
            File.Move("C:\\Users\\suresh.pranadarth\\folderSecond\\file2.txt", "C:\\Users\\suresh.pranadarth\\folderFirst\\file2.txt");
            /*File.Delete("C:\\Users\\suresh.pranadarth\\folderSecond\\file2.txt");*/

        }
    }
}
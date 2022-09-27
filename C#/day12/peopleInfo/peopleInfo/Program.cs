namespace peopleInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("c:\\People Info");
            int i = 1;
            while (i <= 5)
            {
                Console.WriteLine("\nPerson info {0}",i);
                Console.Write("Enter your name : ");
                string name = Console.ReadLine();
                Console.Write("Enter your Age : ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your Place of Birth : ");
                string place_of_birth = Console.ReadLine();
                Console.Write("Enter the Languages you know : ");
                string lang_known = Console.ReadLine();

                string path = "c:\\People Info\\" + name + ".txt";
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.Close();
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("Name : " + name);
                sw.WriteLine("Age : " + age);
                sw.WriteLine("Place of Birth : " + place_of_birth);
                sw.WriteLine("Languages known : " + lang_known);
                sw.Close();
                i++;
            }
        }
    }
}
using System;
class append
{
    public static void Main(string[] args)
    {
        StreamWriter sw = File.AppendText("C:\\Users\\suresh.pranadarth\\source\\repos\\IVYtraining\\C#\\day11\\notepad.txt");
        Console.WriteLine("Enter data you want to add in note pad and type \"close\" to end the notepad");
        string data = "";
        while ((data = Console.ReadLine())!= "close")
        sw.WriteLine(data);
        sw.Close();
    }
}
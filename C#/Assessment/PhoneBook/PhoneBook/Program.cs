using System;
using System.Collections;

class PhoneBook
{
    public Hashtable student = new Hashtable();
    public Dictionary<string,string> Prof = new Dictionary<string,string>();
    public Hashtable citi = new Hashtable();

}
class Students : PhoneBook
{
    public void getvalue(string n, string a, string ph)
    {
        student.Add(n, a + " " + ph);
    }
    public void disp()
    {
        Console.WriteLine("\nStudents:");
        Console.WriteLine("Name  age  Phone");
        foreach (DictionaryEntry d in student)
        {
            Console.WriteLine(d.Key + " " + d.Value);
        }

    }
}
class Professionals : PhoneBook
{
    public void getvalue(string n, string a, string pr, string ph)
    {
        Prof.Add(n, a + " " + pr + " " + ph);
    }
    public void disp()
    {
        Console.WriteLine("\nService and Professionals:");
        Console.WriteLine("Name  age  Profession  Phone");
        foreach (KeyValuePair<string, string> p in Prof)
        {
            Console.WriteLine(p.Key + " " + p.Value);
        }

    }
}
    class Citizens : PhoneBook
{
    public void getvalue(string n, string a, string ph)
    {
        citi.Add(n, a + " " + ph);
    }
    public void disp()
    {
        Console.WriteLine("\nCitizens: ");
        Console.WriteLine("Name  age  Phone");
        foreach (DictionaryEntry d in citi)
        {
            Console.WriteLine(d.Key + " " + d.Value);
        }

    }
}

class main
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Phonebook!!");
        Students st = new Students();
        Professionals prof= new Professionals();
        Citizens cit = new Citizens();
        int f = 0;
        do
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            string age = Console.ReadLine();
            Console.Write("Profession: ");
            string pf = Console.ReadLine();
            Console.Write("phone: ");
            string ph = Console.ReadLine();
            if (pf == "" && int.Parse(age) <= 18)
                st.getvalue(name, age, ph);
            else if (pf != "")
                prof.getvalue(name, age, pf, ph);
            else
                cit.getvalue(name, age, ph);
            Console.Write("Press 1 to continue: ");
            f = int.Parse(Console.ReadLine());
        } while (f == 1);
        st.disp();
        prof.disp();
        cit.disp();
    }
}
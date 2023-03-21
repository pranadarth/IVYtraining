using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;

class People
{
    protected int ID;
    protected string bookname;

}
class student: People
{
    public void disp(int id,string bk,string s )
    {
        Console.WriteLine("\n\tStudents portal!!");
        Console.WriteLine("You have taken a {0} book today. Your due is in 7 days.", bk);
        Console.WriteLine("student with ID: {0} has been noted for attendance, You have 5 classes to attend", id);

    }
}
class teacher: student
{
    public void disp( string bk, string t, int id)
    {
        Console.WriteLine("\n\tStaff portal!!");
        Console.WriteLine("You have taken a {0} book today. Your due is in 30 days.", bk);
        Console.WriteLine("Staff ID: {0} has been noted for attendance, You have 5 classes to take today", id);

    }
}
class liberian : teacher
{
    public void disp( string s, int id, string bk)
    {
        Console.WriteLine("\n\tAdmin portal!!");
        Console.WriteLine(" {0} book has been add in the library list!", bk);
        Console.WriteLine(" ID: {0} has been noted for todays attendance", id);

    }
}
class main
{
  
    static void Main()
    {
        liberian l = new liberian();
        Console.WriteLine("Welcome to library: ");
        again:
        Console.Write("Enter ID: ");
        int ID = int.Parse(Console.ReadLine());

        Console.Write("Book: ");
        string book = Console.ReadLine();

        Console.Write("Designation: ");
        string s = Console.ReadLine();
        switch (s)
        {
            case "student":
                l.disp(ID, book, s);
                break;
            case "teacher":
                l.disp(book, s, ID);
                break;
            case "liberian":
                l.disp(s,ID, book);
                break;
            default:
                Console.WriteLine("\nPlease enter your designation correctly!");
                goto again;
                break;
;        }
    }
}

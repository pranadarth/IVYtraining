using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the 1st num: ");
      var d =  Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter the 2nd num: ");
      var t =  Convert.ToInt32(Console.ReadLine());
      if(d%2 == 0 && t%2 == 0 )
      {
          Console.WriteLine("True");
      }
    else
     Console.WriteLine("False");
  }
}
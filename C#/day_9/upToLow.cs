using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the string: ");
      var str =  Console.ReadLine();
      foreach( char c in str)
      {
          if(Char.IsUpper(c))
           Console.Write(Char.ToLower(c));
          else
           Console.Write(Char.ToUpper(c));
      }
  }
}
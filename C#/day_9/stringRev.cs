using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the string: ");
      var str =  Console.ReadLine();
      for(int i =1; i<=str.Length;i++)
       Console.Write(str[str.Length-i]);
  }
}
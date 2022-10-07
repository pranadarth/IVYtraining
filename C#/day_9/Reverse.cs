using System;
class HelloWorld {
  static void Main() {
      Console.Write("Enter the 1st letter: ");
      var c1 =  Console.ReadLine();
      Console.Write("Enter the 2nd letter: ");
      var c2 = Console.ReadLine();
      Console.Write("Enter the 3rd letter: ");
      var c3 = Console.ReadLine();
    Console.WriteLine("Reversed: {2}{1}{0}",c1,c2,c3);
  }
}
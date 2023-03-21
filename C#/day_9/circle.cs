using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the Radius: ");
      var r =  Convert.ToInt32(Console.ReadLine());
      var p = 2*r*3.14;
      var a = 3.14*r*r;
    Console.WriteLine("Area: {0}, Perimeter: {1}",a,p);
  }
}
using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the side1: ");
      var s1 =  Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter the side2: ");
      var s2 =  Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter the side3: ");
      var s3 =  Convert.ToInt32(Console.ReadLine());
      if(s1==s2 && s2==s3 )
      {
          Console.WriteLine("Equilateral!");
      }
      else if(s1!=s2 && s2!=s3 && s3!=s1)
      {
          Console.WriteLine("Scalene");
      }
    else
     Console.WriteLine("isosceles");
  }
}
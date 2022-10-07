using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the Maths mark: ");
      var m =  Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter the Physics mark: ");
      var p =  Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter the Chemistry mark: ");
      var c =  Convert.ToInt32(Console.ReadLine());
      var t = p+c+m;
      if(p>54 && c>49 && m> 65 && t>179 )
      {
          Console.WriteLine("Eligible!!");
      }
      else if(p+m > 139 || c+m > 139 )
      {
          Console.WriteLine("Eligible");
      }
    else
     Console.WriteLine("Not Eligible");
  }
}

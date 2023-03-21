using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the height(in cm): ");
      var d =  Convert.ToInt32(Console.ReadLine());
      if(d<135 )
      {
          Console.WriteLine("Short!!");
      }
      else if(d<180 )
      {
          Console.WriteLine("Average!!");
      }
    else
     Console.WriteLine("Tall");
  }
}
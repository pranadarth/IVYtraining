using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the size of array: ");
      var s1 =  Convert.ToInt32(Console.ReadLine());
      int[] s = new int[s1];
       Console.Write("Enter the values: ");
      for(int i = 0; i<s1;i++)
       s[i] =  Convert.ToInt32(Console.ReadLine());
     Console.WriteLine("Now entered values in array1: ");
      for(int i = 0; i<s1;i++)
      Console.Write(s[i]);
    int[] c = s;
     Console.WriteLine("\nCopied array: ");
     for(int i = 0; i<s1;i++)
      Console.Write(c[i]);
  }
}
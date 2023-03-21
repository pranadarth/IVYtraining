using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the size of array: ");
      var s1 =  Convert.ToInt32(Console.ReadLine());
      int[] s = new int[s1];
      int[] c = new int[s1];
       Console.Write("Enter the values: ");
      for(int i = 0; i<s1;i++)
       s[i] =  Convert.ToInt32(Console.ReadLine());
     Console.WriteLine("Now enter values of array2: ");
      for(int i = 0; i<s1;i++)
      c[i] =  Convert.ToInt32(Console.ReadLine());
    int[] a = new int[s1*2];
    for(int i = 0; i<s1;i++)
     a[i] = s[i];
    for(int i = s1; i<(s1*2); i++)
      a[i] = c[(i-s1)];
     Console.WriteLine("\nnew array: ");
     for(int i = 0; i<s1*2;i++)
      Console.Write(a[i]);
  }
}
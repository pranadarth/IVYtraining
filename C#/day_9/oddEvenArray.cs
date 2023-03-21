using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the size of array: ");
      var s1 =  Convert.ToInt32(Console.ReadLine());
      int[] e = new int[s1];
      int[] o = new int[s1];
      int e1=0,o1=0;
       Console.WriteLine("Enter the values: ");
      for(int i = 0; i<s1;i++)
      {
       int x =  Convert.ToInt32(Console.ReadLine());
       if(x%2 == 0)
        e[e1++] = x;
       else
        o[o1++] = x;
      }
    Console.WriteLine("Even array: ");
    for(int i = 0; i<e1; i++)
      Console.Write(" "+(e[i]));
     Console.WriteLine("\nOdd array: ");
     for(int i = 0; i<o1;i++)
      Console.Write(" "+(o[i]));
  }
}
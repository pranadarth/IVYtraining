using System;
class Assignment2{
  static void Main() {
      Console.Write("Enter the string: ");
      var str =  Console.ReadLine();
      string ans ="";
      if(str[0]!=str[1])
           ans += str[0];
      for(int i=1; i<str.Length-1;i++)
      {
          int j = i+1;
          int k = i-1;
          if(str[i]!=str[j] && str[i]!=str[k])
           ans += str[i];
          else
           continue;
          
      }
      if(str[str.Length-1]!=str[str.Length-2])
           ans += str[str.Length-1];
      Console.Write("Longest length of the String: "+ (ans.Length));
  }
}
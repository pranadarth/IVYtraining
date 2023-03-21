using System;

class array
{
    
    public static void Main(string[] args)
    {
        Console.Write("Enter the Size of the array: ");
        int s = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the values: ");
        int[] arr = new int[s];
        for(int i = 0; i < s; i++)
            arr[i] = int.Parse(Console.ReadLine());
        Array.Sort(arr);
        Console.WriteLine("The largest value in the array: " + (arr[s - 1]));
        Console.WriteLine("The smallest value in the array: "+ (arr[0]));
    }
}
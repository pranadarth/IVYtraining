using System;
public interface Ivehicles
{
     public void drive();
   public  bool refuel(int v);

}
public class Car : Ivehicles
{
    public int fuel { get; set; }
    public Car(int v)
    {
        fuel = v;
    }
    public void drive()
    {
        if (fuel > 0)
            Console.WriteLine("Car started");
        else
            Console.WriteLine("Refuel the Car");
    }
    public bool refuel(int x)
    {
        if (fuel > 0)
        {
            Console.WriteLine("fuel is there");
            return false;
        }
        else
        {
            fuel += x;
            return true;
        }

    }
}
class main
{
    public static void Main()
    {
        Ivehicles car = new Car(0);
        car.drive();
        Console.Write("Enter the amount of the fuel: ");
       int i  = int.Parse(Console.ReadLine());
        if (car.refuel(i))
        {
            car.drive();
        }

    }
}

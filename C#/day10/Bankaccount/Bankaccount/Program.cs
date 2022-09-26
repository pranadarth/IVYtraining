abstract class bankaccount
{
    protected double aadhaarnumber, bankaccnum;
    public abstract void aadhaar();
}


class Sample : bankaccount
{
    public void get()
    {
        Console.Write("Enter the Aadhaar number : ");
        aadhaarnumber = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the Bank Account number : ");
        bankaccnum = Convert.ToDouble(Console.ReadLine());
    }
 
    public override void aadhaar()
    {
        get();
        Console.WriteLine("Bank Account Number " + bankaccnum + " has been linked with Aadhaar " + aadhaarnumber);
    }

}
class main
{
    static void Main(string[] args)
    {
        Sample s = new Sample();
       
        s.aadhaar();
    }
}
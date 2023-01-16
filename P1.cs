// See https://aka.ms/new-console-template for more information
class P1
{



    public static void Main(string[] args)
    {

        JumpPrime myObj = new JumpPrime(4389);

        while (myObj.IsActive())
        {
            Console.WriteLine("myObj.up() = " + myObj.up());
            Console.WriteLine("myObj.up() = " + myObj.up());
            Console.WriteLine("myObj.down() = " + myObj.down());
        }
        Console.WriteLine("myObj.up() = " + myObj.up());
        Console.WriteLine("myObj.down() = " + myObj.down());




    }
}

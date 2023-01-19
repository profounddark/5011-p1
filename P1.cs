using System;

class P1
{

    static Random randomRoller = new Random();

    public static JumpPrime getNewJumper()
    {
        uint initValue = 1000 + (uint)(randomRoller.Next() % 9000);
        JumpPrime returnJumper = new JumpPrime(initValue);
        return returnJumper;
    }

    public static void randomJumpTest()
    {

        Console.WriteLine("Testing new JumpPrime object:");
        JumpPrime newJumper = getNewJumper();
        uint currentValue;
        int activeCounter = 0;


        while (newJumper.IsActive())
        {
            currentValue = newJumper.GetCurrentValue();
            Console.WriteLine("Current object value: " + currentValue);

            int queryCounter = 0;

            while (newJumper.GetCurrentValue() == currentValue)
            {
                if (queryCounter % 2 == 0)
                {
                    newJumper.up();
                }
                else
                {
                    newJumper.down();
                }
                queryCounter++;
                activeCounter++;
            }

            Console.WriteLine("Queries until jump: " + queryCounter);
        }

        Console.WriteLine("Queries until object deactivated: " + activeCounter);

    }



    public static void Main(string[] args)
    {

        randomJumpTest();

        /*
                JumpPrime myObj = new JumpPrime(2488);

                while (myObj.IsActive())
                {
                    Console.WriteLine("myObj.up() = " + myObj.up());
                    Console.WriteLine("myObj.up() = " + myObj.up());
                    Console.WriteLine("myObj.down() = " + myObj.down());
                }
                Console.WriteLine("myObj.up() = " + myObj.up());
                Console.WriteLine("myObj.down() = " + myObj.down());

                Console.WriteLine("myObj is active: " + myObj.IsActive());

                Console.WriteLine("Reviving myObj: " + (myObj.Revive() ? "Successful" : "Failed"));
                Console.WriteLine("myObj is active: " + myObj.IsActive());


                while (myObj.IsActive())
                {
                    Console.WriteLine("myObj.up() = " + myObj.up());
                    Console.WriteLine("myObj.up() = " + myObj.up());
                    Console.WriteLine("myObj.down() = " + myObj.down());
                }

                Console.WriteLine("myObj.up() = " + myObj.up());
                Console.WriteLine("myObj.down() = " + myObj.down());
                Console.WriteLine("myObj is active: " + myObj.IsActive());
        */







    }
}
